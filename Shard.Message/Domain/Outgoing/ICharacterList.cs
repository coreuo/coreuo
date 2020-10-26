using System;
using System.Collections.Generic;
using System.Linq;

namespace Shard.Message.Domain.Outgoing
{
    public interface ICharacterList<TCharacter>
        where TCharacter : ICharacterInfo
    {
        List<TCharacter> Characters { get; }

        internal void OnWriteCharacterList(IData data)
        {
            var slotCount = Math.Max(Characters.Count, 7);

            data.OnWrite(3, (byte) slotCount);

            Enumerable.Range(0, Characters.Count).ToList().ForEach(i => Characters[i].OnWriteCharacter(i, data));
        }
    }
}