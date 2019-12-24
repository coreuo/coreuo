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
            var slotCount = Math.Max(Characters.Count, 7);

            data.Write(3, (byte) slotCount);

            Enumerable.Range(0, Characters.Count).ToList().ForEach(i => Characters[i].WriteCharacter(i, data));
        }
    }
}