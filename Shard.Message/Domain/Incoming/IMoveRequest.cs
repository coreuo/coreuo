using Shard.Message.Domain.Shared;

namespace Shard.Message.Domain.Incoming
{
    public interface IMoveRequest : INumber
    {
        public byte Direction { set; }

        public int MoveKey { set; }

        internal int ReadMoveRequest(IData data)
        {
            Direction = data.ReadByte(1);

            Number = data.ReadByte(2);

            MoveKey = data.ReadInt(3);

            return 7;
        }
    }
}
