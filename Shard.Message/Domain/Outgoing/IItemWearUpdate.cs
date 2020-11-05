using Shard.Message.Domain.Shared;

namespace Shard.Message.Domain.Outgoing
{
    public interface IItemWearUpdate<out TEntity> :
        ISerial,
        IItemId,
        ILayer,
        IHue,
        IParent<TEntity>
        where TEntity : ISerial
    {
        internal void WriteItemWearUpdate(IData data)
        {
            data.Write(1, Serial);

            data.Write(5, ItemId);

            data.Write(7, (byte)0);

            data.Write(8, Layer);

            data.Write(9, Parent.Serial);

            data.Write(13, Hue);
        }
    }
}
