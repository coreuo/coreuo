namespace Shard.Message.Domain.Outgoing
{
    public interface ILoginConfirm
    {
        int Serial { get; set; }

        int LoginUnknownFirst { get; set; }

        short Body { get; set; }

        ushort LocationX { get; set; }

        ushort LocationY { get; set; }

        byte LoginUnknownSecond { get; set; }

        byte LocationZ { get; set; }

        byte Direction { get; set; }

        int LoginUnknownThird { get; set; }

        int LoginUnknownFourth { get; set; }

        byte LoginUnknownFifth { get; set; }

        ushort BoundaryWidth { get; set; }

        ushort BoundaryHeight { get; set; }

        ushort LoginUnknownSixth { get; set; }

        int LoginUnknownSeventh { get; set; }

        internal void WriteLoginConfirm(IData data)
        {
            data.Write(1, Serial);

            data.Write(5, LoginUnknownFirst);

            data.Write(9, Body);

            data.Write(11, LocationX);

            data.Write(13, LocationY);

            data.Write(15, LoginUnknownSecond);

            data.Write(16, LocationZ);

            data.Write(17, Direction);

            data.Write(18, LoginUnknownThird);

            data.Write(22, LoginUnknownFourth);

            data.Write(26, LoginUnknownFifth);

            data.Write(27, BoundaryWidth);

            data.Write(29, BoundaryHeight);

            data.Write(31, LoginUnknownSixth);

            data.Write(33, LoginUnknownSeventh);

        }
    }
}