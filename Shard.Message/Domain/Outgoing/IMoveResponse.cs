using Shard.Message.Domain.Shared;

namespace Shard.Message.Domain.Outgoing
{
    public interface IMoveResponse : IMove
    {
        internal void OnWriteMoveResponse(IData data)
        {
            data.OnWrite(1, MoveNumber);
        }
    }
}
