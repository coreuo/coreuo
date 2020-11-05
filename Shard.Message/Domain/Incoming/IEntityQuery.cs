using System.Collections.Generic;
using System.Linq;

namespace Shard.Message.Domain.Incoming
{
    public interface IEntityQuery
    {
        List<int> EntityQuerySerialList { get; set; }

        internal int ReadEntityQuery(IData data)
        {
            var size = data.ReadShort(1);

            EntityQuerySerialList = Enumerable.Range(0, (size - 3) / 4).Select(i => data.ReadInt(3 + i * 4)).ToList();

            return size;
        }
    }
}
