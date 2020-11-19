using Shard.Message.Domain.Shared;

namespace Shard.Message.Domain.Outgoing
{
    public interface IMobileItem :
        ISerialGet,
        IGraphics,
        ILayer,
        IHue
    {
        internal void WriteMobileItem(int currentSize, IData data)
        {
            var hue = Hue > 0;

            data.Write(19 + currentSize, Serial);

            var huedGraphics = (ushort)(hue ? Graphic | 0x8000 : Graphic);

            data.Write(19 + currentSize + 4, huedGraphics);

            data.Write(19 + currentSize + 4 + 2, Layer);

            if (hue) data.Write(19 + currentSize + 4 + 2 + 1, Hue);
        }
    }
}