namespace Shard.Message.Domain.Shared
{
    public interface IMap<TMap>
        where TMap : IMap
    {
        TMap Map { get; set; }
    }
}
