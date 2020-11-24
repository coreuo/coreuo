namespace Shard.Mobile.Race.Domain
{
    public interface IState
    {
        byte Race { get; }

        byte Gender { get; }

        ushort HairGraphic { get; }

        ushort HairHue { get; }

        ushort BeardGraphic { get; }

        ushort BeardHue { get; }

        ushort FaceGraphic { get; }

        ushort FaceHue { get; }
    }
}
