namespace Shard.Message.Domain.Outgoing
{
    public interface IOpenPaperDoll
    {
        byte PaperDollFlags { get; set; }

        internal void OnWriteOpenPaperDoll(IData data)
        {
            data.OnWrite(65, PaperDollFlags);
        }
    }
}
