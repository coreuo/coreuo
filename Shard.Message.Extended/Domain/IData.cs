using System.Text;

namespace Shard.Message.Extended.Domain
{
    public interface IData
    {
        public byte[] Value { get; }

        public int ExtendedOffset { get; set; }

        public int ExtendedLength { get; set; }

        internal short ReadExtendedShort(int offset)
        {
            return (short)((Value[ExtendedOffset + offset] << 8) | Value[ExtendedOffset + offset + 1]);
        }

        internal int ReadExtendedInt(int offset)
        {
            return (Value[ExtendedOffset + offset] << 24) |
                   (Value[ExtendedOffset + offset + 1] << 16) |
                   (Value[ExtendedOffset + offset + 2] << 8) |
                   Value[ExtendedOffset + offset + 3];
        }

        internal string ReadExtendedString(int offset, int length)
        {
            return Encoding.ASCII.GetString(Value, ExtendedOffset + offset, length).Replace("\0", "");
        }

        internal void WriteExtended(int offset, byte value)
        {
            Value[ExtendedOffset + offset] = value;
        }

        internal void WriteExtended(int offset, short value)
        {
            Value[ExtendedOffset + offset] = (byte)(value >> 8);
            Value[ExtendedOffset + offset + 1] = (byte)value;
        }

        internal void WriteExtended(int offset, int value)
        {
            Value[ExtendedOffset + offset] = (byte)(value >> 24);
            Value[ExtendedOffset + offset + 1] = (byte)(value >> 16);
            Value[ExtendedOffset + offset + 2] = (byte)(value >> 8);
            Value[ExtendedOffset + offset + 3] = (byte)value;
        }
    }
}
