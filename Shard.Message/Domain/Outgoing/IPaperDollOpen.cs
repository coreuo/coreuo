namespace Shard.Message.Domain.Outgoing
{
    public interface IPaperDollOpen
    {
        byte PaperDollFlags { get; set; }

        internal void WritePaperDollOpen(IData data)
        {
            data.Write(65, PaperDollFlags);
        }
    }
}
