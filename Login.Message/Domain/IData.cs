using System.Text;

namespace Login.Message.Domain
{
    public interface IData
    {
        public byte[] Value { get; }

        public int Offset { get; set; }

        public int Length { get; set; }

        internal byte OnReadByte(int offset)
        {
            return Value[Offset + offset];
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

        internal void OnWrite(int offset, short value)
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

        internal void OnWriteString(int offset, string text)
        {
            Encoding.ASCII.GetBytes(text).CopyTo(Value, Offset + offset);
        }

    }
}
