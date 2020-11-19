using Shard.Message.Domain.Shared;

namespace Shard.Message.Domain.Incoming
{
    public interface IMobileQuery :
        ISerialSet
    {
        public int UnknownMobileQueryFirst { set; }

        public byte MobileQueryType { set; }

        internal int ReadMobileQuery(IData data)
        {
            UnknownMobileQueryFirst = data.ReadInt(1);

            MobileQueryType = data.ReadByte(5);

            Serial = data.ReadInt(6);

            return 10;
        }
    }
}
