namespace Shard.Message.Domain.Incoming
{
    public interface IMobileQuery
    {
        public int UnknownMobileQueryFirst { get; set; }

        public byte MobileQueryType { get; set; }

        public int MobileQuerySerial { get; set; }

        internal int ReadMobileQuery(IData data)
        {
            UnknownMobileQueryFirst = data.ReadInt(1);

            MobileQueryType = data.ReadByte(5);

            MobileQuerySerial = data.ReadInt(6);

            return 10;
        }
    }
}
