using Shard.Message.Domain.Shared;

namespace Shard.Message.Domain.Outgoing
{
    public interface IEntityRemove :
        ISerialGet
    {
        internal void WriteEntityRemove(IData data)
        {
            data.Write(1, Serial);
        }
    }
}
