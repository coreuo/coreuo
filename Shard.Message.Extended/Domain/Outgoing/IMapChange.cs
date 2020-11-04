namespace Shard.Message.Extended.Domain.Outgoing
{
    public interface IMapChange
    {
        byte MapId { get; set; }

        internal void WriteMapChange(IData data)
        {
            data.Write(2, MapId);
        }
    }
}
