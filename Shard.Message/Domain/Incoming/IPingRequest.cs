namespace Shard.Message.Domain.Incoming
{
    public interface IPingRequest
    {
        public byte Number { get; set; }

        internal int ReadPingRequest(IData data)
        {
            Number = data.ReadByte(1);

            return 2;
        }
    }
}
