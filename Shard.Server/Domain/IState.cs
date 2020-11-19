using System;
using System.Collections.Generic;

namespace Shard.Server.Domain
{
    public interface IState<TMobile, TItem, TEntity, TIdentity, in TTarget>
        where TMobile : IMobile<TItem, TEntity, TIdentity>
        where TItem : IItem<TItem, TEntity, TIdentity>
        where TEntity : class, IEntity<TItem, TEntity, TIdentity>
        where TTarget : ITarget
    {
        List<TMobile> Characters { get; set; }

        TMobile Mobile { get; set; }

        public byte MobileQueryType { get; }

        public int Serial { get; }

        int ParentSerial { get; }

        List<int> SerialList { get; }

        byte ProfileRequestMode { get; }

        ushort SoundId { set; }

        ushort LocationX { get; }

        ushort LocationY { get; }

        sbyte LocationZ { get; }

        byte GridIndex { get; }

        byte WarMode { get; }

        byte Direction { get; }

        string SpeechText { get; }

        int Slot { get; }

        ushort Hue { get; }

        string Name { get; }

        ushort FaceHue { get; }

        ushort FaceGraphic { get; }

        ushort HairHue { get; }

        ushort HairGraphic { get; }

        ushort BeardGraphic { get; }

        ushort BeardHue { get; }

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
