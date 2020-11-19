using Shard.Message.Domain.Shared;

namespace Shard.Message.Domain.Outgoing
{
    public interface ILoginConfirm :
        ISerialGet,
        IGraphics,
        ITarget,
        IDirection
    {
        public int LoginUnknownFirst { get; }

        public byte LoginUnknownSecond { get; }

        public int LoginUnknownThird { get; }

        public int LoginUnknownFourth { get; }

        public byte LoginUnknownFifth { get; }

        public ushort BoundaryWidth { get; }

        public ushort BoundaryHeight { get; }

        public ushort LoginUnknownSixth { get; }

        public int LoginUnknownSeventh { get; }

        internal void WriteLoginConfirm(IData data)
        {
            data.Write(1, Serial);

            data.Write(5, LoginUnknownFirst);

            data.Write(9, Graphic);

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