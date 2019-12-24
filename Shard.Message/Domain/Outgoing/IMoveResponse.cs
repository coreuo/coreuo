namespace Shard.Message.Domain.Outgoing
{
    public interface IMoveResponse<TCharacter>
        where TCharacter : IMoveNotoriety
    {
        TCharacter Mobile { get; }

        byte MoveNumber { get; set; }

        internal void WriteMoveResponse(IData data)
        {
            data.Write(1, MoveNumber);

            Mobile.WriteMoveNotoriety(data);
        }
    }
}
