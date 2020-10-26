namespace Shard.Message.Domain.Incoming
{
    public interface IPingRequest
    {
        public byte Number { get; set; }

        internal int OnReadPingRequest(IData data)
        {
            Number = data.OnReadByte(1);

            return 2;
        }
    }
}
