using Shard.Message.Domain.Outgoing;

namespace Shard.Message.Domain
{
    public interface IEntity<TAttribute> :
        IAttributeList<TAttribute>,
        IEntityDisplay
        where TAttribute : IAttribute
    {
    }
}
