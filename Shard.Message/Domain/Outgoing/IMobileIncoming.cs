using System.Collections.Generic;
using System.Linq;

namespace Shard.Message.Domain.Outgoing
{
    public interface IMobileIncoming<TMobileEquip>
        where TMobileEquip : IMobileEquip
    {
        int Serial { get; set; }

        short Body { get; set; }

        ushort LocationX { get; set; }

        ushort LocationY { get; set; }

        byte LocationZ { get; set; }

        byte Direction { get; set; }

        short Hue { get; set; }

        byte StatusFlags { get; set; }

        byte Notoriety { get; set; }

        List<TMobileEquip> Equipment { get; set; }

        internal void WriteMobileIncoming(IData data)
        {
            data.Write(3, Serial);

            data.Write(7, Body);

            data.Write(9, LocationX);

            data.Write(11, LocationY);

            data.Write(13, LocationZ);

            data.Write(14, Direction);

            data.Write(15, Hue);

            data.Write(17, StatusFlags);

            data.Write(18, Notoriety);

            Enumerable.Range(0, Equipment.Count).ToList().ForEach(i => Equipment[i].WriteMobileEquipment(EquipmentSize(i), data));

            data.Write(19 + EquipmentSize() , 0);
        }

        internal int EquipmentSize(int? index = null)
        {
            var filtered = index == null ? Equipment : Equipment.Take(index.Value);

            return filtered.Sum(e => e.HasHue() ? 9 : 7);
        }
    }
}
