using Shard.Message.Domain.Shared;

namespace Shard.Message.Domain.Outgoing
{
    public interface IItemWorld :
        ISerialGet,
        IAmount,
        IGraphics,
        IDirection,
        ILocation,
        IHue
    {
        public byte ItemFlags { get; }

        internal void WriteItemWorld(IData data)
        {
            var amount = Amount > 0;

            data.Write(3, Serial | (amount ? 1 << 31 : 0));

            data.Write(7, Graphic);

            if(amount) data.Write(9, Amount);

            var direction = Direction > 0;

            data.Write(9 + (amount ? 2 : 0), (ushort) (LocationX | (direction ? 1 << 15 : 0)));

            var hue = Hue > 0;

            var flags = ItemFlags > 0;

            data.Write(11 + (amount ? 2 : 0), (ushort) (LocationY | (hue ? 1 << 15 : 0) | (flags ? 1 << 14 : 0)));

            if(direction) data.Write(13 + (amount ? 2 : 0), Direction);

            data.Write(13 + (amount ? 2 : 0) + (direction ? 1 : 0), LocationZ);

            if(hue) data.Write(14 + (amount ? 2 : 0) + (direction ? 1 : 0), Hue);

            if(flags) data.Write(14 + (amount ? 2 : 0) + (direction ? 1 : 0) + (hue ? 2 : 0), Hue);
        }
    }
}
