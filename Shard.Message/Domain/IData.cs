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

        internal byte OnReadByte(int offset)
        {
            return Value[Offset + offset];
        }

        internal byte[] OnReadByteArray(int offset, int length)
        {
            var result = new byte[length];

            Array.Copy(Value, Offset + offset, result, 0, length);

            return result;
        }

        internal short OnReadShort(int offset)
        {
            return (short)((Value[Offset + offset] << 8) | Value[Offset + offset + 1]);
        }

        internal int OnReadInt(int offset)
        {
            return (Value[Offset + offset] << 24) |
                   (Value[Offset + offset + 1] << 16) |
                   (Value[Offset + offset + 2] << 8) |
                   Value[Offset + offset + 3];
        }

        internal string OnReadString(int offset, int length)
        {
            return Encoding.ASCII.GetString(Value, Offset + offset, length).Replace("\0", "");
        }

        internal void OnWrite(int offset, byte value)
        {
            Value[Offset + offset] = value;
        }

        internal void OnWrite(int offset, byte[] value)
        {
            value.CopyTo(Value, Offset + offset);
        }

        internal void OnWrite(int offset, short value)
        {
            Value[Offset + offset] = (byte)(value >> 8);
            Value[Offset + offset + 1] = (byte)value;
        }

        internal void OnWrite(int offset, ushort value)
        {
            Value[Offset + offset] = (byte)(value >> 8);
            Value[Offset + offset + 1] = (byte)value;
        }

        internal void OnWrite(int offset, int value)
        {
            Value[Offset + offset] = (byte)(value >> 24);
            Value[Offset + offset + 1] = (byte)(value >> 16);
            Value[Offset + offset + 2] = (byte)(value >> 8);
            Value[Offset + offset + 3] = (byte)value;
        }

        internal void OnWrite(int offset, string text, int? size = null)
        {
            Encoding.ASCII.GetBytes(text, 0, text.Length, Value, Offset + offset);

            for (var i = text.Length; i < (size ?? text.Length); i++) Value[Offset + offset + i] = 0;
        }

        internal int OnWriteUnicode(int offset, string text, int? size = null)
        {
            var length = Encoding.Unicode.GetBytes(text, 0, text.Length, Value, Offset + offset);

            for (var i = text.Length; i < (size ?? text.Length); i++) Value[Offset + offset + i] = 0;

            return length;
        }
    }
}
