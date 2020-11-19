using Shard.Message.Domain.Shared;

namespace Shard.Message.Domain.Incoming
{
    public interface IItemPick :
        ISerialSet,
        IAmount
    {
        internal int ReadItemPick(IData data)
        {
            Serial = data.ReadInt(1);

            Amount = data.ReadUShort(5);

            return 7;
        }
    }
}
