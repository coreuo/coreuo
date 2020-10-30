namespace Shard.Message.Domain.Incoming
{
    public interface IRequestProfile
    {
        byte RequestProfileMode { get; set; }

        int RequestProfileSerial { get; set; }

        short RequestProfileEditType { get; set; }

        string RequestProfileEditText { get; set; }

        internal int ReadRequestProfile(IData data)
        {
            var length = data.ReadShort(1);

            RequestProfileMode = data.ReadByte(3);

            RequestProfileSerial = data.ReadInt(4);

            if (RequestProfileMode == 0) return length;

            RequestProfileEditType = data.ReadShort(8);

            var textLength = data.ReadShort(10);

            RequestProfileEditText = data.ReadUnicode(12, textLength);

            return length;
        }
    }
}
