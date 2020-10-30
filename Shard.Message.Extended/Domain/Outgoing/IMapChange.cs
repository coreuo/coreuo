namespace Shard.Message.Extended.Domain.Outgoing
{
    public interface IMapChange
    {
        byte Id { get; set; }

        internal void WriteMapChange(IData data)
        {
            data.Write(2, Id);
        }
    }
}
