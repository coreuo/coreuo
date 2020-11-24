using System;
using System.Collections.Generic;

namespace Shard.Mobile.Race.Domain
{
    public interface IServer<TItem, in TEntity, TIdentity> where TItem : IItem
        where TEntity : IEntity<TIdentity>
    {
        Dictionary<HashSet<TIdentity>, List<Range>> GraphicRanges { get; }

        TItem CreateItem(ushort? graphic, ushort? hue, params TIdentity[] identities);

        void SetItemParent(TEntity entity, TItem item);

        Random Random { get; }

        TIdentity Male { get;}

        TIdentity Female { get; }

        TIdentity Human { get; }

        TIdentity Elf { get; }

        TIdentity Hair { get; }

        TIdentity Face { get; }

        TIdentity Beard { get; }
    }
}
