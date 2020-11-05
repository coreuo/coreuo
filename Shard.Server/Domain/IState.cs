using System.Collections.Generic;

namespace Shard.Server.Domain
{
    public interface IState<TMobile, TItem, TEntity>
        where TMobile : IMobile<TItem, TEntity>
        where TItem : IItem<TItem, TEntity>
        where TEntity : IEntity<TItem, TEntity>
    {
        List<TMobile> Characters { get; set; }

        TMobile Mobile { get; set; }

        public byte MobileQueryType { get; set; }

        public int MobileQuerySerial { get; set; }

        List<int> EntityQuerySerialList { get; set; }

        int EntityUseSerial { get; set; }

        byte ProfileRequestMode { get; set; }

        int ProfileRequestSerial { get; set; }

        int ItemPickSerial { get; set; }

        ushort SoundId { get; set; }

        ushort ItemPlaceLocationX { get; set; }

        ushort ItemPlaceLocationY { get; set; }

        sbyte ItemPlaceLocationZ { get; set; }

        byte ItemPlaceGridIndex { get; set; }

        int ItemPlaceContainerSerial { get; set; }

        int ItemWearSerial { get; set; }

        int ItemWearParentSerial { get; set; }
    }
}
