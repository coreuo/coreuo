using Shard.Message.Domain.Shared;

namespace Shard.Message.Domain.Outgoing
{
    public interface IMoveNotoriety :
        INotoriety
    {
        internal void OnWriteMoveNotoriety(IData data)
        {
            data.OnWrite(2, Notoriety);
        }
    }
}
