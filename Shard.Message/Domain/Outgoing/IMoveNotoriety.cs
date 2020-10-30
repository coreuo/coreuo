using Shard.Message.Domain.Shared;

namespace Shard.Message.Domain.Outgoing
{
    public interface IMoveNotoriety :
        INotoriety
    {
        internal void WriteMoveNotoriety(IData data)
        {
            data.Write(2, Notoriety);
        }
    }
}
