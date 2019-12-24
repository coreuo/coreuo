namespace Shard.Message.Domain.Outgoing
{
    public interface IMoveNotoriety
    {
        byte Notoriety { get; }

        internal void WriteMoveNotoriety(IData data)
        {
            data.Write(2, Notoriety);
        }
    }
}
