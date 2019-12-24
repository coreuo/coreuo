using Shard.Message.Extended.Domain.Outgoing;

namespace Shard.Message.Extended.Domain
{
    public interface IMobile<TMap, TMapPatch>
        where TMap : IMap<TMapPatch>
        where TMapPatch : IMapPatch
    {
        TMap Map { get; }
    }
}
