namespace Shard.Message.Domain.Outgoing
{
    public interface IMobileUpdate
    {
        int Serial { get; set; }

        short Body { get; set; }

        byte UnknownMobileUpdateFirst { get; set; }

        short Hue { get; set; }

        byte StatusFlags { get; set; }

        ushort LocationX { get; set; }

        ushort LocationY { get; set; }

        short UnknownMobileUpdateSecond { get; set; }

        byte Direction { get; set; }

        byte LocationZ { get; set; }

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