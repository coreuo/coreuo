namespace Shard.Message.Domain.Outgoing
{
    public interface IMobileEquip
    {
        int Serial { get; set; }

        ushort ItemId { get; set; }

        byte Layer { get; set; }

        short Hue { get; set; }

        internal bool HasHue() => (ItemId & 0x8000) > 0;

        internal void WriteMobileEquipment(int currentSize, IData data)
        {
            data.Write(19 + currentSize, Serial);

            data.Write(19 + currentSize + 4, ItemId);

            data.Write(19 + currentSize + 4 + 2, Layer);

            if (HasHue()) data.Write(19 + currentSize + 4 + 2 + 1, Hue);
        }
    }
}