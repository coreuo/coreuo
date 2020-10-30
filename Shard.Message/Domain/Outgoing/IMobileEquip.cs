using Shard.Message.Domain.Shared;

namespace Shard.Message.Domain.Outgoing
{
    public interface IMobileEquip :
        ISerial,
        IHue
    {
        ushort ItemId { get; set; }

        byte Layer { get; set; }

        internal bool HasHue() => Hue > 0;

        internal void WriteMobileEquipment(int currentSize, IData data)
        {
            data.Write(19 + currentSize, Serial);

            var huedItemId = (ushort)(HasHue() ? ItemId | 0x8000 : ItemId);

            data.Write(19 + currentSize + 4, huedItemId);

            data.Write(19 + currentSize + 4 + 2, Layer);

            if (HasHue()) data.Write(19 + currentSize + 4 + 2 + 1, Hue);
        }
    }
}