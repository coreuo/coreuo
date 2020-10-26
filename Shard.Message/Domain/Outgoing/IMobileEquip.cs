using Shard.Message.Domain.Shared;

namespace Shard.Message.Domain.Outgoing
{
    public interface IMobileEquip :
        ISerial,
        IHue
    {
        ushort ItemId { get; set; }

        byte Layer { get; set; }

        internal bool OnHasHue() => (ItemId & 0x8000) > 0;

        internal void OnWriteMobileEquipment(int currentSize, IData data)
        {
            data.OnWrite(19 + currentSize, Serial);

            data.OnWrite(19 + currentSize + 4, ItemId);

            data.OnWrite(19 + currentSize + 4 + 2, Layer);

            if (OnHasHue()) data.OnWrite(19 + currentSize + 4 + 2 + 1, Hue);
        }
    }
}