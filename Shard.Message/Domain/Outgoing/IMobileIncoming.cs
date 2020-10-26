using System.Collections.Generic;
using System.Linq;
using Shard.Message.Domain.Shared;

namespace Shard.Message.Domain.Outgoing
{
    public interface IMobileIncoming<TMobileEquip> :
        ISerial,
        IBody,
        ILocation,
        IDirection,
        IHue,
        IStatusFlags,
        INotoriety
        where TMobileEquip : IMobileEquip
    {
        List<TMobileEquip> Equipment { get; set; }

        internal void OnWriteMobileIncoming(IData data)
        {
            data.OnWrite(3, Serial);

            data.OnWrite(7, Body);

            data.OnWrite(9, LocationX);

            data.OnWrite(11, LocationY);

            data.OnWrite(13, LocationZ);

            data.OnWrite(14, Direction);

            data.OnWrite(15, Hue);

            data.OnWrite(17, StatusFlags);

            data.OnWrite(18, Notoriety);

            Enumerable.Range(0, Equipment.Count).ToList().ForEach(i => Equipment[i].OnWriteMobileEquipment(OnEquipmentSize(i), data));

            data.OnWrite(19 + OnEquipmentSize() , 0);
        }

        internal int OnEquipmentSize(int? index = null)
        {
            var filtered = index == null ? Equipment : Equipment.Take(index.Value);

            return filtered.Sum(e => e.OnHasHue() ? 9 : 7);
        }
    }
}
