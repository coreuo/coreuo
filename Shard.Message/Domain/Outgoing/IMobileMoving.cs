using Shard.Message.Domain.Shared;

namespace Shard.Message.Domain.Outgoing
{
    public interface IMobileMoving :
        ISerialGet,
        IGraphics,
        ILocation,
        IDirection,
        IHue,
        IStatusFlags,
        INotoriety
    {
        internal void WriteMobileMoving(IData data)
        {
            data.Write(1, Serial);

            data.Write(5, Graphic);

            data.Write(7, LocationX);

            data.Write(9, LocationY);

            data.Write(11, LocationZ);

            data.Write(12, Direction);

            data.Write(13, Hue);

            data.Write(15, StatusFlags);

            data.Write(16, Notoriety);
        }
    }
}
