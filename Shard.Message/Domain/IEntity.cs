using Shard.Message.Domain.Outgoing;

namespace Shard.Message.Domain
{
    public interface IEntity<TProperty> :
        IPropertyList<TProperty>
        where TProperty : IProperty
    {
    }
}
