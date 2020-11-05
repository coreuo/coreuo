using Shard.Message.Domain.Shared;

namespace Shard.Message.Domain.Outgoing
{
    public interface IPingResponse :
        INumber
    {
        internal void WritePingResponse(IData data)
        {
            data.Write(1, Number);
        }
    }
}