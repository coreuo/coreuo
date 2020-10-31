using Shard.Message.Domain.Outgoing;

namespace Shard.Message.Domain
{
    public interface IEntity<TAttribute, TItem> :
        IAttributeList<TAttribute>,
        IEntityDisplay,
        IEntityContent<TItem>
        where TAttribute : IAttribute
        where TItem : IEntityContentItem
    {
    }
}
