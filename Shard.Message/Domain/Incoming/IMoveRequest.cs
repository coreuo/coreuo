namespace Shard.Message.Domain.Incoming
{
    public interface IMoveRequest
    {
        public byte MoveDirection { get; set; }

        public byte MoveNumber { get; set; }

        public int MoveKey { get; set; }

        internal int ReadMoveRequest(IData data)
        {
            MoveDirection = data.ReadByte(1);

            MoveNumber = data.ReadByte(2);

            MoveKey = data.ReadInt(3);

            return 7;
        }
    }
}
