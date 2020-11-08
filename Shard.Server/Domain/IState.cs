using System;
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

        byte WarMode { get; set; }

        byte Direction { get; set; }

        string SpeechText { get; set; }

        internal void TransferMove(TMobile mobile)
        {
            Action action = (Direction & 0xF) switch
            {
                var move when move != (mobile.Direction & 0xF) => () => { },
                0x00 => () => mobile.Move(0, -1, 0),
                0x01 => () => mobile.Move(+1, -1, 0),
                0x02 => () => mobile.Move(+1, 0, 0),
                0x03 => () => mobile.Move(+1, +1, 0),
                0x04 => () => mobile.Move(0, +1, 0),
                0x05 => () => mobile.Move(-1, +1, 0),
                0x06 => () => mobile.Move(-1, 0, 0),
                0x07 => () => mobile.Move(-1, -1, 0),
                _ => throw new InvalidOperationException($"Unknown direction {Direction}.")
            };

            mobile.Direction = Direction;

            action();
        }

        internal void TransferLocation(TTarget target)
        {
            target.LocationX = LocationX;

            target.LocationY = LocationY;

            target.LocationZ = LocationZ;
        }

        internal void TransferWarMode(TMobile mobile)
        {
            mobile.WarMode = WarMode;

            if (WarMode > 0) mobile.StatusFlags |= 1 << 6;
            else mobile.StatusFlags &= ~(1 << 6) & 0xFF;
        }
    }
}
