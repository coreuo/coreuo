namespace Shard.Message.Domain.Incoming
{
    public interface IRequestProfile
    {
        byte RequestProfileMode { get; set; }

        int RequestProfileSerial { get; set; }

        short RequestProfileEditType { get; set; }

        string RequestProfileEditText { get; set; }

        internal int OnReadRequestProfile(IData data)
        {
            var length = data.OnReadShort(1);

            RequestProfileMode = data.OnReadByte(3);

            RequestProfileSerial = data.OnReadInt(4);

            if (RequestProfileMode == 0) return length;

            RequestProfileEditType = data.OnReadShort(8);

            var textLength = data.OnReadShort(10);

            RequestProfileEditText = data.OnReadUnicode(12, textLength);

            return length;
        }
    }
}
