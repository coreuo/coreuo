using System.Collections.Generic;

namespace Shard.Server.Domain
{
    public interface IItem<TItem> : 
        IEntity
        where TItem : IItem<TItem>
    {
        Dictionary<int,TItem> Items { get; set; }

        byte GridIndex { get; set; }
    }
}
