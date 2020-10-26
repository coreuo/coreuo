using Shard.Message.Domain.Shared;

namespace Shard.Message.Domain.Outgoing
{
    public interface ILoginConfirm :
        ISerial,
        IBody,
        ILocation,
        IDirection
    {
        int LoginUnknownFirst { get; set; }

        byte LoginUnknownSecond { get; set; }

        int LoginUnknownThird { get; set; }

        int LoginUnknownFourth { get; set; }

        byte LoginUnknownFifth { get; set; }

        ushort BoundaryWidth { get; set; }

        ushort BoundaryHeight { get; set; }

        ushort LoginUnknownSixth { get; set; }

        int LoginUnknownSeventh { get; set; }

        internal void OnWriteLoginConfirm(IData data)
        {
            data.OnWrite(1, Serial);

            data.OnWrite(5, LoginUnknownFirst);

            data.OnWrite(9, Body);

            data.OnWrite(11, LocationX);

            data.OnWrite(13, LocationY);

            data.OnWrite(15, LoginUnknownSecond);

            data.OnWrite(16, LocationZ);

            data.OnWrite(17, Direction);

            data.OnWrite(18, LoginUnknownThird);

            data.OnWrite(22, LoginUnknownFourth);

            data.OnWrite(26, LoginUnknownFifth);

            data.OnWrite(27, BoundaryWidth);

            data.OnWrite(29, BoundaryHeight);

            data.OnWrite(31, LoginUnknownSixth);

            data.OnWrite(33, LoginUnknownSeventh);

        }
    }
}