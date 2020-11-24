using System;
using Shard.Message.Domain.Shared;

namespace Shard.Message.Domain.Outgoing
{
    public interface ICharacterInfo :
        IName
    {
        internal void WriteCharacter(int index, IData data)
        {
            if (Name == null) throw new InvalidOperationException("Unknown character name.");

            data.WriteAscii(4 + index * 60, Name, 30);
        }
    }
}
