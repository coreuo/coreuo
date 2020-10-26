namespace Shard.Message.Domain.Outgoing
{
    public interface ICharacterFeatures
    {
        int CharacterFlags { get; }

        internal void OnWriteCharacterFeatures(int characterListSize, int cityListSize, IData data)
        {
            data.OnWrite(4 + characterListSize + cityListSize, CharacterFlags);
        }
    }
}
