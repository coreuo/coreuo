using System;

namespace Shard.Mobiles.Domain
{
    public interface IServer<TServer, TItem>
        where TServer : IServer<TServer, TItem>
        where TItem : IItem
    {
        TItem CreateItem(params Action<TServer, TItem>[] types);

        void AddItem(TItem parent, TItem child);

        Action<TServer, TItem> Backpack { get; }

        Action<TServer, TItem> LeatherChest { get; }

        Action<TServer, TItem> Robe { get; }

        Action<TServer, TItem> Shirt { get; }

        Action<TServer, TItem> ShortPants { get; }

        Action<TServer, TItem> Shoes { get; }

        Action<TServer, TItem> FirstFace { get; }
    }
}
