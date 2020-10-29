using Shard.Message.Domain.Outgoing;

namespace Shard.Message.Domain
{
    public interface IEntity<TAttribute> :
        IAttributeList<TAttribute>
        where TAttribute : IAttribute
    {
    }
}
