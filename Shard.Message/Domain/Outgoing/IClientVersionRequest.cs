namespace Shard.Message.Domain.Outgoing
{
    public interface IClientVersionRequest
    {
        internal void OnWriteClientVersionRequest(IData data)
        {
        }
    }
}
