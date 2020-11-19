// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace Launcher.Domain
{
    public sealed record TileArt :
        Game.Data.Domain.ITileArt
    {
        public ushort Graphic { get; init; }

        public string Name { get; init; }

        public ulong Flags { get; init; }

        public ushort Weight { get; init; }

        public int Height { get; init; }

        public byte Layer { get; init; }
    }
}
