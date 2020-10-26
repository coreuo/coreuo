namespace Shard.Message.Extended.Domain.Outgoing
{
    public interface IMapChange
    {
        byte Id { get; set; }

        internal void OnWriteMapChange(IData data)
        {
            data.OnWrite(2, Id);
        }
    }
}
