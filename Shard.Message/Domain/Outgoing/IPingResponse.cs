namespace Shard.Message.Domain.Outgoing
{
    public interface IPingResponse
    {
        byte PingNumber { get; set; }

        internal void WritePingResponse(IData data)
        {
            data.Write(1, PingNumber);
        }
    }
}