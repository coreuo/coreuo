using System.Collections.Generic;
using System.Linq;

namespace Shard.Message.Extended.Domain.Outgoing
{
    public interface IMapPatchList<TMapPatch> : IMapChange
        where TMapPatch : IMapPatch
    {
        List<TMapPatch> Patches { get; }

        internal void OnWriteMapPatchList(IData data)
        {
            var length = Patches.Count;

            data.OnWrite(2, length);

            Enumerable.Range(0, length).ToList().ForEach(i => Patches[i].OnWriteMapPatch(i, data));
        }
    }
}
