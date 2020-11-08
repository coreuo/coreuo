namespace Login.Message.Domain
{
    public interface IData
    {
        public byte[] Value { get; }

        public int Offset { get; set; }

        public int Length { get; set; }

        byte ReadByte(int offset);

        short ReadShort(int offset);

        int ReadInt(int offset);

        string ReadAscii(int offset, int length);

        void Write(int offset, byte value);

        void Write(int offset, sbyte value);

        void Write(int offset, byte[] value);

        void Write(int offset, short value);

        void Write(int offset, ushort value);

        void Write(int offset, int value);

        int WriteAscii(int offset, string text, int? size = null);
    }
}
