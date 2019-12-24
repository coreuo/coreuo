using System;
using System.Text;
using Shard.Message.Domain.Incoming;

namespace Shard.Message.Domain
{
    public interface IData : IExtendedData
    {
        public byte[] Value { get; }

        public int Offset { get; set; }

        public int Length { get; set; }

        internal byte ReadByte(int offset)
        {
            return Value[Offset + offset];
        }

        internal byte[] ReadByteArray(int offset, int length)
        {
            var result = new byte[length];

            Array.Copy(Value, Offset + offset, result, 0, length);

            return result;
        }

        internal short ReadShort(int offset)
        {
            return (short)((Value[Offset + offset] << 8) | Value[Offset + offset + 1]);
        }

        internal int ReadInt(int offset)
        {
            return (Value[Offset + offset] << 24) |
                   (Value[Offset + offset + 1] << 16) |
                   (Value[Offset + offset + 2] << 8) |
                   Value[Offset + offset + 3];
        }

        internal string ReadString(int offset, int length)
        {
            return Encoding.ASCII.GetString(Value, Offset + offset, length).Replace("\0", "");
        }

        internal void Write(int offset, byte value)
        {
            Value[Offset + offset] = value;
        }

        internal void Write(int offset, byte[] value)
        {
            value.CopyTo(Value, Offset + offset);
        }

        internal void Write(int offset, short value)
        {
            Value[Offset + offset] = (byte)(value >> 8);
            Value[Offset + offset + 1] = (byte)(value);
        }

        internal void Write(int offset, ushort value)
        {
            Value[Offset + offset] = (byte)(value >> 8);
            Value[Offset + offset + 1] = (byte)(value);
        }

        internal void Write(int offset, int value)
        {
            Value[Offset + offset] = (byte)(value >> 24);
            Value[Offset + offset + 1] = (byte)(value >> 16);
            Value[Offset + offset + 2] = (byte)(value >> 8);
            Value[Offset + offset + 3] = (byte)(value);
        }

        internal void Write(int offset, string text)
        {
            Encoding.ASCII.GetBytes(text).CopyTo(Value, Offset + offset);
        }

        internal void Compare(byte[] target)
        {
            for (var i = 0; i < Math.Min(Length, target.Length); i++)
            {
                var sourceByte = $"{i}:0x{Value[Offset + i]:X2} ";

                var targetByte = $"{i}:0x{target[i]:X2} ";

                Console.ForegroundColor = sourceByte == targetByte ? ConsoleColor.Gray : ConsoleColor.Red;

                Console.Write(sourceByte);
            }

            Console.ForegroundColor = ConsoleColor.Gray;

            Console.Write("\n");
        }
    }
}
