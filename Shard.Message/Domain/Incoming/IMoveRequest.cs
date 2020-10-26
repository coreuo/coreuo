using Shard.Message.Domain.Shared;

namespace Shard.Message.Domain.Incoming
{
    public interface IMoveRequest : IMove
    {
        public byte MoveDirection { get; set; }

        public int MoveKey { get; set; }

        internal int OnReadMoveRequest(IData data)
        {
            MoveDirection = data.OnReadByte(1);

            MoveNumber = data.OnReadByte(2);

            MoveKey = data.OnReadInt(3);

            return 7;
        }
    }
}
