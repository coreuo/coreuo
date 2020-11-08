using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Launcher.Domain
{
    [NotMapped]
    public class Data :
        Network.State.Domain.IData,
        Network.Server.Domain.IData,
        Login.Message.Domain.IData,
        Login.Encryption.Domain.IData,
        Shard.Message.Domain.IData,
        Shard.Message.Extended.Domain.IData,
        Shard.Message.Compression.Domain.IData
    {
        public byte[] Value { get; } = new byte[2048];

        public int Offset { get; set; }

        public int Length { get; set; }

        public int ExtendedOffset { get; set; }

        public int ExtendedLength { get; set; }

        public byte ReadByte(int offset)
        {
            return Value[Offset + offset];
        }

        public sbyte ReadSByte(int offset)
        {
            return (sbyte)Value[Offset + offset];
        }

        public byte[] ReadByteArray(int offset, int length)
        {
            var result = new byte[length];

            Array.Copy(Value, Offset + offset, result, 0, length);

            return result;
        }

        public short ReadShort(int offset)
        {
            return (short)((Value[Offset + offset] << 8) | Value[Offset + offset + 1]);
        }

        public ushort ReadUShort(int offset)
        {
            return (ushort)((Value[Offset + offset] << 8) | Value[Offset + offset + 1]);
        }

        public int ReadInt(int offset)
        {
            return (Value[Offset + offset] << 24) |
                   (Value[Offset + offset + 1] << 16) |
                   (Value[Offset + offset + 2] << 8) |
                   Value[Offset + offset + 3];
        }

        public string ReadAscii(int offset, int length)
        {
            return Encoding.ASCII.GetString(Value, Offset + offset, length).Replace("\0", "");
        }

        public string ReadUnicode(int offset, int length)
        {
            return Encoding.BigEndianUnicode.GetString(Value, Offset + offset, length).Replace("\0", "");
        }

        public string ReadUtf8Terminated(int offset, int length)
        {
            return Encoding.UTF8.GetString(Value, Offset + offset, Array.IndexOf(Value, (byte)0, Offset + offset, length) - Offset - offset);
        }

        public void Clear(int offset, int length)
        {
            for (var i = 0; i < length; i++) Value[Offset + offset + i] = 0;
        }

        public void Write(int offset, byte value)
        {
            Value[Offset + offset] = value;
        }

        public void Write(int offset, sbyte value)
        {
            Value[Offset + offset] = (byte)value;
        }

        public void Write(int offset, byte[] value)
        {
            value.CopyTo(Value, Offset + offset);
        }

        public void Write(int offset, short value)
        {
            Value[Offset + offset] = (byte)(value >> 8);
            Value[Offset + offset + 1] = (byte)value;
        }

        public void Write(int offset, ushort value)
        {
            Value[Offset + offset] = (byte)(value >> 8);
            Value[Offset + offset + 1] = (byte)value;
        }

        public void Write(int offset, int value)
        {
            Value[Offset + offset] = (byte)(value >> 24);
            Value[Offset + offset + 1] = (byte)(value >> 16);
            Value[Offset + offset + 2] = (byte)(value >> 8);
            Value[Offset + offset + 3] = (byte)value;
        }

        public int WriteAscii(int offset, string text, int? size = null)
        {
            return WriteText(Encoding.ASCII, offset, text, size);
        }

        public int WriteAsciiTerminated(int offset, string text)
        {
            return WriteText(Encoding.ASCII, offset, text, terminated: 1);
        }

        public int WriteUnicode(int offset, string text, int? size = null)
        {
            return WriteText(Encoding.Unicode, offset, text, size);
        }

        public int WriteBigUnicodeTerminated(int offset, string text)
        {
            return WriteText(Encoding.BigEndianUnicode, offset, text, terminated: 2);
        }

        public int WriteText(Encoding encoding, int offset, string text, int? size = null, int terminated = 0)
        {
            var length = encoding.GetBytes(text, 0, text.Length, Value, Offset + offset);

            var next = size ?? length + terminated;

            for (var i = length; i < next; i++) Value[Offset + offset + i] = 0;

            return next;
        }
    }
}
