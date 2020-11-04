using System.Collections.Generic;

namespace Shard.Server.Domain
{
    public interface IItem<TItem> : 
        IEntity
        where TItem : IItem<TItem>
    {
        ushort ItemId { get; }

        List<TItem> Items { get; set; }

        byte GridIndex { get; set; }
    }
}
