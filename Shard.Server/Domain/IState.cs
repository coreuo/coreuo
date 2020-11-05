using System.Collections.Generic;

namespace Shard.Server.Domain
{
    public interface IState<TMobile, TItem, TEntity, in TTarget>
        where TMobile : IMobile<TItem, TEntity>
        where TItem : IItem<TItem, TEntity>
        where TEntity : class, IEntity<TItem, TEntity>
        where TTarget : ITarget
    {
        List<TMobile> Characters { get; set; }

        TMobile Mobile { get; set; }

        public byte MobileQueryType { get; set; }

        public int Serial { get; set; }

        int ParentSerial { get; set; }

        List<int> SerialList { get; set; }

        byte ProfileRequestMode { get; set; }

        ushort SoundId { get; set; }

        ushort LocationX { get; set; }

        ushort LocationY { get; set; }

        sbyte LocationZ { get; set; }

        byte GridIndex { get; set; }

        internal void TransferLocation(TTarget target)
        {
            target.LocationX = LocationX;

            target.LocationY = LocationY;

            target.LocationZ = LocationZ;
        }
    }
}
