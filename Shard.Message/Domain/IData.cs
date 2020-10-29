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

        internal string OnReadAscii(int offset, int length)
        {
            return Encoding.ASCII.GetString(Value, Offset + offset, length).Replace("\0", "");
        }

        internal string OnReadUnicode(int offset, int length)
        {
            return Encoding.Unicode.GetString(Value, Offset + offset, length).Replace("\0", "");
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

        internal int OnWriteAscii(int offset, string text, int? size = null)
        {
            return OnWriteText(Encoding.ASCII, offset, text, size);
        }

        internal int OnWriteAsciiTerminated(int offset, string text)
        {
            return OnWriteText(Encoding.ASCII, offset, text, terminated: 1);
        }

        internal int OnWriteUnicode(int offset, string text, int? size = null)
        {
            return OnWriteText(Encoding.Unicode, offset, text, size);
        }

        internal int OnWriteBigUnicodeTerminated(int offset, string text)
        {
            return OnWriteText(Encoding.BigEndianUnicode, offset, text, terminated: 2);
        }

        internal int OnWriteText(Encoding encoding, int offset, string text, int? size = null, int terminated = 0)
        {
            var length = encoding.GetBytes(text, 0, text.Length, Value, Offset + offset);

            var next = size ?? length + terminated;

            for (var i = length; i < next; i++) Value[Offset + offset + i] = 0;

            return next;
        }
    }
}
