using System.Text;

namespace Login.Message.Domain
{
    public interface IData
    {
        public byte[] Value { get; }

        public int Offset { get; set; }

        public int Length { get; set; }

        internal byte ReadByte(int offset)
        {
            return Value[Offset + offset];
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

        internal void Write(int offset, short value)
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

        internal void WriteString(int offset, string text)
        {
            Encoding.ASCII.GetBytes(text).CopyTo(Value, Offset + offset);
        }

    }
}
