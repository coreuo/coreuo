namespace Shard.Message.Domain.Incoming
{
    public interface IMobileQuery
    {
        public int UnknownMobileQueryFirst { get; set; }

        public byte MobileQueryType { get; set; }

        public int MobileQuerySerial { get; set; }

        internal int OnReadMobileQuery(IData data)
        {
            UnknownMobileQueryFirst = data.OnReadInt(1);

            MobileQueryType = data.OnReadByte(5);

            MobileQuerySerial = data.OnReadInt(6);

            return 10;
        }
    }
}
