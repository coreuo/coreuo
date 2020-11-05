using Shard.Message.Domain.Outgoing;

namespace Shard.Message.Domain
{
    public interface IEntity<TAttribute, TItem, TEntity> :
        IEntityAttributes<TAttribute>,
        IEntityDisplay,
        IEntityContent<TItem, TEntity>,
        IEntityRemove
        where TAttribute : IAttribute
        where TItem : IEntityContentItem<TEntity>
        where TEntity : IEntity<TAttribute, TItem, TEntity>
    {
    }
}
