using System.Collections.Generic;
using System.Linq;

namespace Shard.Message.Domain.Incoming
{
    public interface IAttributesQuery
    {
        List<int> AttributesQuerySerialList { get; set; }

        internal int OnReadAttributesQuery(IData data)
        {
            var size = data.OnReadShort(1);

            AttributesQuerySerialList = Enumerable.Range(0, (size - 3) / 4).Select(i => data.OnReadInt(3 + i * 4)).ToList();

            return size;
        }
    }
}
