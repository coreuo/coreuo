using System.Collections.Generic;

namespace Shard.Server.Domain
{
    public interface IMobile<TItem> : 
        IEntity
        where TItem : IItem<TItem>
    {
        public string Name { get; set; }

        public List<TItem> Items { get; }
    }
}
