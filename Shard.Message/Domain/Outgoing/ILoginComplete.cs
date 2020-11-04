namespace Shard.Message.Domain.Outgoing
{
    public interface ILoginComplete
    {
        internal void WriteLoginComplete(IData data)
        {
        }
    }
}
