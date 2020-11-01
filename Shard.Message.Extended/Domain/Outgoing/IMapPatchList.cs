using System.Collections.Generic;
using System.Linq;

namespace Shard.Message.Extended.Domain.Outgoing
{
    public interface IMapPatchList<TMapPatch> : IMapChange
        where TMapPatch : IMapPatch
    {
        List<TMapPatch> Patches { get; }

        internal void WriteMapPatchList(IData data)
        {
            data.Write(2, Patches.Count);

            foreach (var (mapPatch, index) in Patches.Select((p, i) => (p, i))) mapPatch.WriteMapPatch(index, data);
        }
    }
}
