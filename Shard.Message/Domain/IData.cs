using Shard.Message.Domain.Incoming;

namespace Shard.Message.Domain
{
    public interface IData : IExtendedData
    {
        public int Offset { get; set; }

        public int Length { get; set; }

        byte ReadByte(int offset);

        sbyte ReadSByte(int offset);

        byte[] ReadByteArray(int offset, int length);

        short ReadShort(int offset);

        ushort ReadUShort(int offset);

        int ReadInt(int offset);

        string ReadAscii(int offset, int length);

        string ReadUnicode(int offset, int length);

        string ReadUtf8Terminated(int offset, int length);

        void Clear(int offset, int length);

        void Write(int offset, byte value);

        void Write(int offset, sbyte value);

        void Write(int offset, byte[] value);

        void Write(int offset, short value);

        void Write(int offset, ushort value);

        void Write(int offset, int value);

        int WriteAscii(int offset, string text, int? size = null);

        int WriteAsciiTerminated(int offset, string text);

        int WriteUnicode(int offset, string text, int? size = null);

        int WriteBigUnicodeTerminated(int offset, string text);
    }
}
