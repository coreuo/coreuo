using Shard.Message.Domain.Outgoing;

namespace Shard.Message.Domain
{
    public interface IItem<TAttribute, TItem, out TEntity> : 
        IMobileItem,
        IEntityContentItem<TEntity>,
        IItemWorld,
        IItemWearUpdate<TEntity>
        where TAttribute : IAttribute
        where TItem : IItem<TAttribute, TItem, TEntity>
        where TEntity : IEntity<TAttribute, TItem, TEntity>
    {
    }
}
