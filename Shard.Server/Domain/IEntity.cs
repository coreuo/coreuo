using System.Collections.Generic;

namespace Shard.Server.Domain
{
    public interface IEntity<TItem, TEntity>
        where TItem : IItem<TItem, TEntity>
        where TEntity : IEntity<TItem, TEntity>
    {
        public int Serial { get; set; }

        List<TItem> Items { get; set; }
    }
}
