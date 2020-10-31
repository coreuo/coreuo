using Shard.Message.Domain.Shared;

namespace Shard.Message.Domain.Outgoing
{
    public interface IEntityContentItem :
        ISerial,
        IItemId,
        IAmount,
        ILocation,
        IHue
    {
        byte GridIndex { get; }

        internal void WriteEntityContentItem(int entitySerial, int currentSize, IData data)
        {
            data.Write(5 + currentSize, Serial);

            data.Write(5 + currentSize + 4, ItemId);

            data.Write(5 + currentSize + 6, (byte)0);

            data.Write(5 + currentSize + 7, Amount);

            data.Write(5 + currentSize + 9, LocationX);

            data.Write(5 + currentSize + 11, LocationY);

            data.Write(5 + currentSize + 13, GridIndex);

            data.Write(5 + currentSize + 14, entitySerial);

            data.Write(5 + currentSize + 18, Hue);
        }
    }
}
