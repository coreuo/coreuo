using Shard.Message.Domain.Shared;

namespace Shard.Message.Domain.Outgoing
{
    public interface IMoveResponse : INumber
    {
        internal void WriteMoveResponse(IData data)
        {
            data.Write(1, Number);
        }
    }
}
