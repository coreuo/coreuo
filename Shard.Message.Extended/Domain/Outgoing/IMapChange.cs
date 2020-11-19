namespace Shard.Message.Extended.Domain.Outgoing
{
    public interface IMapChange
    {
        byte MapId { get; }

        internal void WriteMapChange(IData data)
        {
            data.WriteExtended(2, MapId);
        }
    }
}
