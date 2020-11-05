using Shard.Message.Domain.Shared;

namespace Shard.Message.Domain.Outgoing
{
    public interface ILoginConfirm :
        ISerial,
        IBody,
        ITarget,
        IDirection
    {
        public int LoginUnknownFirst { get; set; }

        public byte LoginUnknownSecond { get; set; }

        public int LoginUnknownThird { get; set; }

        public int LoginUnknownFourth { get; set; }

        public byte LoginUnknownFifth { get; set; }

        public ushort BoundaryWidth { get; set; }

        public ushort BoundaryHeight { get; set; }

        public ushort LoginUnknownSixth { get; set; }

        public int LoginUnknownSeventh { get; set; }

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