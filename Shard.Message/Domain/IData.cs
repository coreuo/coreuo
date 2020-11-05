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

        internal sbyte ReadSByte(int offset)
        {
            return (sbyte)Value[Offset + offset];
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

        internal ushort ReadUShort(int offset)
        {
            return (ushort)((Value[Offset + offset] << 8) | Value[Offset + offset + 1]);
        }

        internal int ReadInt(int offset)
        {
            return (Value[Offset + offset] << 24) |
                   (Value[Offset + offset + 1] << 16) |
                   (Value[Offset + offset + 2] << 8) |
                   Value[Offset + offset + 3];
        }

        internal string ReadAscii(int offset, int length)
        {
            return Encoding.ASCII.GetString(Value, Offset + offset, length).Replace("\0", "");
        }

        internal string ReadUnicode(int offset, int length)
        {
            return Encoding.Unicode.GetString(Value, Offset + offset, length).Replace("\0", "");
        }

        internal void Write(int offset, byte value)
        {
            Value[Offset + offset] = value;
        }

        internal void Write(int offset, sbyte value)
        {
            Value[Offset + offset] = (byte)value;
        }

        internal void Write(int offset, byte[] value)
        {
            value.CopyTo(Value, Offset + offset);
        }

        internal void Write(int offset, short value)
        {
            Value[Offset + offset] = (byte)(value >> 8);
            Value[Offset + offset + 1] = (byte)value;
        }

        internal void Write(int offset, ushort value)
        {
            Value[Offset + offset] = (byte)(value >> 8);
            Value[Offset + offset + 1] = (byte)value;
        }

        internal void Write(int offset, int value)
        {
            Value[Offset + offset] = (byte)(value >> 24);
            Value[Offset + offset + 1] = (byte)(value >> 16);
            Value[Offset + offset + 2] = (byte)(value >> 8);
            Value[Offset + offset + 3] = (byte)value;
        }

        internal int WriteAscii(int offset, string text, int? size = null)
        {
            return WriteText(Encoding.ASCII, offset, text, size);
        }

        internal int WriteAsciiTerminated(int offset, string text)
        {
            return WriteText(Encoding.ASCII, offset, text, terminated: 1);
        }

        internal int WriteUnicode(int offset, string text, int? size = null)
        {
            return WriteText(Encoding.Unicode, offset, text, size);
        }

        internal int WriteBigUnicodeTerminated(int offset, string text)
        {
            return WriteText(Encoding.BigEndianUnicode, offset, text, terminated: 2);
        }

        internal int WriteText(Encoding encoding, int offset, string text, int? size = null, int terminated = 0)
        {
            var length = encoding.GetBytes(text, 0, text.Length, Value, Offset + offset);

            var next = size ?? length + terminated;

            for (var i = length; i < next; i++) Value[Offset + offset + i] = 0;

            return next;
        }
    }
}
