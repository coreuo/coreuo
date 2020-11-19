namespace Shard.Mobile.Race.Domain
{
    public interface IState
    {
        byte Race { get; }

        byte Gender { get; }

        ushort HairGraphic { get; }

        ushort BeardGraphic { get; }

        ushort FaceGraphic { get; }
    }
}
