using Shard.Message.Domain.Shared;

namespace Shard.Message.Domain.Outgoing
{
    public interface IMobileItem :
        ISerial,
        IItemId,
        ILayer,
        IHue
    {
        internal void WriteMobileItem(int currentSize, IData data)
        {
            var hue = Hue > 0;

            data.Write(19 + currentSize, Serial);

            var huedItemId = (ushort)(hue ? ItemId | 0x8000 : ItemId);

            data.Write(19 + currentSize + 4, huedItemId);

            data.Write(19 + currentSize + 4 + 2, Layer);

            if (hue) data.Write(19 + currentSize + 4 + 2 + 1, Hue);
        }
    }
}