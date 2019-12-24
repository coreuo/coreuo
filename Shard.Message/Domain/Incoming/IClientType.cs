namespace Shard.Message.Domain.Incoming
{
    public interface IClientType
    {
        public short UnknownClientTypeFirst { get; set; }

        public int ClientType { get; set; }

        internal int ReadClientType(IData data)
        {
            UnknownClientTypeFirst = data.ReadShort(3);

            ClientType = data.ReadInt(5);

            return 9;
        }
    }
}
