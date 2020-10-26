using System.Collections.Generic;
using System.Linq;

namespace Shard.Message.Domain.Incoming
{
    public interface IPropertiesQuery
    {
        List<int> PropertiesQuerySerialList { get; set; }

        internal int OnReadPropertiesQuery(IData data)
        {
            var size = data.OnReadShort(1);

            PropertiesQuerySerialList = Enumerable.Range(0, (size - 3) / 4).Select(i => data.OnReadInt(3 + i * 4)).ToList();

            return size;
        }
    }
}
