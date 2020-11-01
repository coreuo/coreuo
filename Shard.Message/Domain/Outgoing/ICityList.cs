using System.Collections.Generic;
using System.Linq;

namespace Shard.Message.Domain.Outgoing
{
    public interface ICityList<TCity>
        where TCity : ICityInfo
    {
        public List<TCity> Cities { get; }

        internal void WriteCityList(int characterListSize, IData data)
        {
            data.Write(4 + characterListSize, (byte)Cities.Count);

            foreach (var (city, index) in Cities.Select((c, i) => (c, i))) city.WriteCity(characterListSize, index, data);
        }
    }
}
