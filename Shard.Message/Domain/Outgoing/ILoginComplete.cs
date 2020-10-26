namespace Shard.Message.Domain.Outgoing
{
    public interface ILoginComplete
    {
        internal void OnLoginComplete(IData data)
        {
        }
    }
}
