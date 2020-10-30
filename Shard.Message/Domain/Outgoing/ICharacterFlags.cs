namespace Shard.Message.Domain.Outgoing
{
    public interface ICharacterFeatures
    {
        int CharacterFlags { get; }

        internal void WriteCharacterFeatures(int characterListSize, int cityListSize, IData data)
        {
            data.Write(4 + characterListSize + cityListSize, CharacterFlags);
        }
    }
}
