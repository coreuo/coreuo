using Shard.Message.Domain.Shared;

namespace Shard.Message.Domain.Outgoing
{
    public interface IMobileUpdate :
        ISerial,
        IBody,
        IHue,
        IStatusFlags,
        ITarget,
        IDirection
    {
        public byte UnknownMobileUpdateFirst { get; set; }

        public short UnknownMobileUpdateSecond { get; set; }

        internal void WriteMobileUpdate(IData data)
        {
            data.Write(1, Serial);

            data.Write(5, Body);

            data.Write(7, UnknownMobileUpdateFirst);

            data.Write(8, Hue);

            data.Write(10, StatusFlags);

            data.Write(11, LocationX);

            data.Write(13, LocationY);

            data.Write(15, UnknownMobileUpdateSecond);

            data.Write(17, Direction);

            data.Write(18, LocationZ);
        }
    }
}