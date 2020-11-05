using System;

namespace Shard.Mobiles.Domain
{
    public interface IServer<TServer, TItem, in TEntity>
        where TServer : IServer<TServer, TItem, TEntity>
        where TItem : IItem<TItem>
        where TEntity : IEntity<TItem>
    {
        TItem CreateItem(params Action<TServer, TItem>[] types);

        void SetItemParent(TEntity parent, params TItem[] items);

        Action<TServer, TItem> Backpack { get; }

        Action<TServer, TItem> LeatherChest { get; }

        Action<TServer, TItem> Robe { get; }

        Action<TServer, TItem> Shirt { get; }

        Action<TServer, TItem> ShortPants { get; }

        Action<TServer, TItem> Shoes { get; }

        Action<TServer, TItem> FirstFace { get; }
    }
}
