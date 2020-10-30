using Shard.Message.Extended.Domain.Outgoing;

namespace Shard.Message.Extended.Domain
{
    public interface IMobile<out TMap, TMapPatch>
        where TMap : IMap<TMapPatch>
        where TMapPatch : IMapPatch
    {
        public TMap Map { get; }
    }
}
