using Shard.Message.Domain.Shared;

namespace Shard.Message.Domain.Incoming
{
    public interface IMobileQuery :
        ISerial
    {
        public int UnknownMobileQueryFirst { get; set; }

        public byte MobileQueryType { get; set; }

        internal int ReadMobileQuery(IData data)
        {
            UnknownMobileQueryFirst = data.ReadInt(1);

            MobileQueryType = data.ReadByte(5);

            Serial = data.ReadInt(6);

            return 10;
        }
    }
}
