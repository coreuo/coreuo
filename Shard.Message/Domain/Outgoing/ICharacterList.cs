using System;
using System.Collections.Generic;
using System.Linq;

namespace Shard.Message.Domain.Outgoing
{
    public interface ICharacterList<TCharacter>
        where TCharacter : ICharacterInfo
    {
        List<TCharacter> Characters { get; }

        internal void WriteCharacterList(IData data)
        {
            data.Write(3, (byte)Math.Max(Characters.Count, 7));

            foreach (var (character, index) in Characters.Select((c, i) => (c, i))) character.WriteCharacter(index, data);
        }
    }
}