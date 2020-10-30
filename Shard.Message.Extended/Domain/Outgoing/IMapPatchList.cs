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
            var length = Patches.Count;

            data.Write(2, length);

            Enumerable.Range(0, length).ToList().ForEach(i => Patches[i].WriteMapPatch(i, data));
        }
    }
}
