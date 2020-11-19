using Shard.Message.Domain.Shared;

namespace Shard.Message.Domain.Incoming
{
    public interface ITargetResponse :
        Shared.ITarget,
        ISerialSet,
        ILocation
    {
        ushort Graphic { set; }

        internal int ReadTargetResponse(IData data)
        {
            TargetMode = data.ReadByte(1);

            TargetId = data.ReadInt(2);

            TargetType = data.ReadByte(6);

            Serial = data.ReadInt(7);

            LocationX = data.ReadUShort(11);

            LocationY = data.ReadUShort(13);

            LocationZ = data.ReadSByte(16);

            Graphic = data.ReadUShort(17);

            return 19;
        }
    }
}
