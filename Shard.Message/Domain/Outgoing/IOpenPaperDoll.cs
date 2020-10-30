namespace Shard.Message.Domain.Outgoing
{
    public interface IOpenPaperDoll
    {
        byte PaperDollFlags { get; set; }

        internal void WriteOpenPaperDoll(IData data)
        {
            data.Write(65, PaperDollFlags);
        }
    }
}
