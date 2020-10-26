using System.Collections.Generic;
using System.Linq;

namespace Shard.Message.Domain.Outgoing
{
    public interface ICityList<TCity>
        where TCity : ICityInfo
    {
        public List<TCity> Cities { get; }

        internal void OnWriteCityList(int characterListSize, IData data)
        {
            var cityCount = Cities.Count;

            data.OnWrite(4 + characterListSize, (byte)cityCount);

            Enumerable.Range(0, cityCount).ToList().ForEach(i => Cities[i].OnWriteCity(characterListSize, i, data));
        }
    }
}
