using Shard.Message.Domain.Shared;

namespace Shard.Message.Domain.Outgoing
{
    public interface IMobileUpdate :
        ISerial,
        IBody,
        IHue,
        IStatusFlags,
        ILocation,
        IDirection
    {
        byte UnknownMobileUpdateFirst { get; set; }

        short UnknownMobileUpdateSecond { get; set; }

        internal void OnWriteMobileUpdate(IData data)
        {
            data.OnWrite(1, Serial);

            data.OnWrite(5, Body);

            data.OnWrite(7, UnknownMobileUpdateFirst);

            data.OnWrite(8, Hue);

            data.OnWrite(10, StatusFlags);

            data.OnWrite(11, LocationX);

            data.OnWrite(13, LocationY);

            data.OnWrite(15, UnknownMobileUpdateSecond);

            data.OnWrite(17, Direction);

            data.OnWrite(18, LocationZ);
        }
    }
}