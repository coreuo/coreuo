using Shard.Message.Domain.Shared;

namespace Shard.Message.Domain.Outgoing
{
    public interface ICharacterInfo :
        IName
    {
        internal void OnWriteCharacter(int index, IData data)
        {
            data.OnWrite(4 + index * 60, Name, 30);
        }
    }
}
