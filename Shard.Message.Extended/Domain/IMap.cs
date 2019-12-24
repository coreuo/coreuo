using Shard.Message.Extended.Domain.Outgoing;

namespace Shard.Message.Extended.Domain
{
    public interface IMap<TMapPatch> : IMapPatchList<TMapPatch>
        where TMapPatch : IMapPatch
    {
    }
}
