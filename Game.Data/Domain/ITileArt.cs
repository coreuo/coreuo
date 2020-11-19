namespace Game.Data.Domain
{
    public interface ITileArt
    {
        ushort Graphic { init; }

        string Name { get; init; }

        ulong Flags { init; }

        ushort Weight { init; }

        int Height { init; }

        byte Layer { get; init; }
    }
}
