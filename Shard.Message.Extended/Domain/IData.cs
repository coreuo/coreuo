namespace Shard.Message.Extended.Domain
{
    public interface IData
    {
        public int ExtendedOffset { get; set; }

        public int ExtendedLength { get; set; }

        short ReadShort(int offset);

        string ReadAscii(int offset, int length);

        void Write(int offset, byte value);

        void Write(int offset, sbyte value);

        void Write(int offset, byte[] value);

        void Write(int offset, short value);

        void Write(int offset, ushort value);

        void Write(int offset, int value);
    }
}
