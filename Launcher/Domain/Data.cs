using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
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

        private static Action<string> Debug => null; //Console.WriteLine;

        public byte ReadByte(int offset)
        {
            var value =  Value[Offset + offset];

            Debug?.Invoke($"{offset:D3} BYTE    {value}");

            return value;
        }

        public sbyte ReadSByte(int offset)
        {
            var value = (sbyte)Value[Offset + offset];

            Debug?.Invoke($"{offset:D3} SBYTE   {value}");

            return value;
        }

        public byte[] ReadByteArray(int offset, int length)
        {
            var result = new byte[length];

            Array.Copy(Value, Offset + offset, result, 0, length);

            Debug?.Invoke($"{offset:D3} ARRAY   {string.Join(" ", result.Select(v => $"{v:X2}"))}");

            return result;
        }

        public short ReadShort(int offset)
        {
            var value = (short)((Value[Offset + offset] << 8) | Value[Offset + offset + 1]);

            Debug?.Invoke($"{offset:D3} SHORT   {value}");

            return value;
        }

        public ushort ReadUShort(int offset)
        {
            var value = (ushort)((Value[Offset + offset] << 8) | Value[Offset + offset + 1]);

            Debug?.Invoke($"{offset:D3} USHORT  {value}");

            return value;
        }

        public int ReadInt(int offset)
        {
            var value = (Value[Offset + offset] << 24) |
                   (Value[Offset + offset + 1] << 16) |
                   (Value[Offset + offset + 2] << 8) |
                   Value[Offset + offset + 3];

            Debug?.Invoke($"{offset:D3} INT     {value}");

            return value;
        }

        public string ReadAscii(int offset, int length)
        {
            var value = Encoding.ASCII.GetString(Value, Offset + offset, length).Replace("\0", "");

            Debug?.Invoke($"{offset:D3} ASCII   {value}");

            return value;
        }

        public string ReadUnicode(int offset, int length)
        {
            var value = Encoding.BigEndianUnicode.GetString(Value, Offset + offset, length).Replace("\0", "");

            Debug?.Invoke($"{offset:D3} UNICODE {value}");

            return value;
        }

        public string ReadUtf8Terminated(int offset, int length)
        {
            var value = Encoding.UTF8.GetString(Value, Offset + offset, Array.IndexOf(Value, (byte)0, Offset + offset, length) - Offset - offset);

            Debug?.Invoke($"{offset:D3} UNICODE {value}");

            return value;
        }

        public void Clear(int offset, int length)
        {
            for (var i = 0; i < length; i++) Value[Offset + offset + i] = 0;
        }

        public void Write(int offset, byte value)
        {
            Debug?.Invoke($"{offset:D3} BYTE    {value}");

            Value[Offset + offset] = value;
        }

        public void Write(int offset, sbyte value)
        {
            Debug?.Invoke($"{offset:D3} SBYTE   {value}");

            Value[Offset + offset] = (byte)value;
        }

        public void Write(int offset, byte[] value)
        {
            Debug?.Invoke($"{offset:D3} ARRAY   {string.Join(" ", value.Select(v => $"{v:X2}"))}");

            value.CopyTo(Value, Offset + offset);
        }

        public void Write(int offset, short value)
        {
            Debug?.Invoke($"{offset:D3} SHORT   {value}");

            Value[Offset + offset] = (byte)(value >> 8);
            Value[Offset + offset + 1] = (byte)value;
        }

        public void Write(int offset, ushort value)
        {
            Debug?.Invoke($"{offset:D3} USHORT  {value}");

            Value[Offset + offset] = (byte)(value >> 8);
            Value[Offset + offset + 1] = (byte)value;
        }

        public void Write(int offset, int value)
        {
            Debug?.Invoke($"{offset:D3} INT     {value}");

            Value[Offset + offset] = (byte)(value >> 24);
            Value[Offset + offset + 1] = (byte)(value >> 16);
            Value[Offset + offset + 2] = (byte)(value >> 8);
            Value[Offset + offset + 3] = (byte)value;
        }

        public void WriteAscii(int offset, string text, int size)
        {
            Debug?.Invoke($"{offset:D3} ASCII   {text}");

            WriteText(Encoding.ASCII, offset, text, size);
        }

        public int WriteAsciiTerminated(int offset, string text)
        {
            Debug?.Invoke($"{offset:D3} ASCII   {text}");

            return WriteText(Encoding.ASCII, offset, text, terminated: 1);
        }

        public int WriteUnicode(int offset, string text, int? size = null)
        {
            Debug?.Invoke($"{offset:D3} UNICODE {text}");

            return WriteText(Encoding.Unicode, offset, text, size);
        }

        public int WriteBigUnicodeTerminated(int offset, string text)
        {
            Debug?.Invoke($"{offset:D3} UNICODE {text}");

            return WriteText(Encoding.BigEndianUnicode, offset, text, terminated: 2);
        }

        private int WriteText(Encoding encoding, int offset, string text, int? size = null, int terminated = 0)
        {
            var length = encoding.GetBytes(text, 0, text.Length, Value, Offset + offset);

            var next = size ?? length + terminated;

            for (var i = length; i < next; i++) Value[Offset + offset + i] = 0;

            return next;
        }
    }
}
