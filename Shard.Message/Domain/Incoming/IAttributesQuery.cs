using System.Collections.Generic;
using System.Linq;

namespace Shard.Message.Domain.Incoming
{
    public interface IAttributesQuery
    {
        List<int> AttributesQuerySerialList { get; set; }

        internal int ReadAttributesQuery(IData data)
        {
            var size = data.ReadShort(1);

            AttributesQuerySerialList = Enumerable.Range(0, (size - 3) / 4).Select(i => data.ReadInt(3 + i * 4)).ToList();

            return size;
        }
    }
}
