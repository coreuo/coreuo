using Shard.Message.Domain.Shared;

namespace Shard.Message.Domain.Incoming
{
    public interface IItemPlace : 
        ISerialSet,
        ILocation,
        IGridIndex,
        IParentSerial
    {
        internal int ReadItemPlace(IData data)
        {
            Serial = data.ReadInt(1);

            LocationX = data.ReadUShort(5);

            LocationY = data.ReadUShort(7);

            LocationZ = data.ReadSByte(9);

            GridIndex = data.ReadByte(10);

            ParentSerial = data.ReadInt(11);

            return 15;
        }
    }
}
