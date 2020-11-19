namespace Shard.Message.Domain.Incoming
{
    public interface IClientType
    {
        public short UnknownClientTypeFirst { set; }

        public int ClientType { set; }

        internal int ReadClientType(IData data)
        {
            UnknownClientTypeFirst = data.ReadShort(3);

            ClientType = data.ReadInt(5);

            return 9;
        }
    }
}
