namespace Shard.Message.Domain.Outgoing
{
    public interface IPingResponse
    {
        byte PingNumber { get; set; }

        internal void OnWritePingResponse(IData data)
        {
            data.OnWrite(1, PingNumber);
        }
    }
}