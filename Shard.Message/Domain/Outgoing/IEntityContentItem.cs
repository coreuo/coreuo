using Shard.Message.Domain.Shared;

namespace Shard.Message.Domain.Outgoing
{
    public interface IEntityContentItem<out TEntity> :
        ISerial,
        IItemId,
        IAmount,
        ITarget,
        IHue,
        IGridIndex,
        IParent<TEntity>
        where TEntity : ISerial
    {
        internal void WriteEntityContentItem(int offset, int currentSize, IData data)
        {
            data.Write(offset + currentSize, Serial);

            data.Write(offset + currentSize + 4, ItemId);

            data.Write(offset + currentSize + 6, (byte)0);

            data.Write(offset + currentSize + 7, Amount);

            data.Write(offset + currentSize + 9, LocationX);

            data.Write(offset + currentSize + 11, LocationY);

            data.Write(offset + currentSize + 13, GridIndex);

            data.Write(offset + currentSize + 14, Parent.Serial);

            data.Write(offset + currentSize + 18, Hue);
        }
    }
}
