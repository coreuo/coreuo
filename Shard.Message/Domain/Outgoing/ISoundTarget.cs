using Shard.Message.Domain.Shared;

namespace Shard.Message.Domain.Outgoing
{
    public interface ISoundTarget :
        ILocation
    {
        internal void WriteSoundTarget(IData data)
        {
            data.Write(6, LocationX);

            data.Write(8, LocationY);

            data.Write(10, (ushort)LocationZ);
        }
    }
}
