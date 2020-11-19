using Shard.Message.Domain.Shared;

namespace Shard.Message.Domain.Incoming
{
    public interface IItemWear :
        ISerialSet,
        IParentSerial,
        ILayer
    {
        internal int ReadItemWear(IData data)
        {
            Serial = data.ReadInt(1);

            Layer = data.ReadByte(5);

            ParentSerial = data.ReadInt(6);

            return 10;
        }
    }
}
