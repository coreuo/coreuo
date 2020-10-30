using Shard.Message.Domain.Shared;

namespace Shard.Message.Domain.Outgoing
{
    public interface IMoveResponse : IMove
    {
        internal void WriteMoveResponse(IData data)
        {
            data.Write(1, MoveNumber);
        }
    }
}
