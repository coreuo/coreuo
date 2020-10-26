namespace Shard.Message.Domain.Incoming
{
    public interface IClientType
    {
        public short UnknownClientTypeFirst { get; set; }

        public int ClientType { get; set; }

        internal int OnReadClientType(IData data)
        {
            UnknownClientTypeFirst = data.OnReadShort(3);

            ClientType = data.OnReadInt(5);

            return 9;
        }
    }
}
