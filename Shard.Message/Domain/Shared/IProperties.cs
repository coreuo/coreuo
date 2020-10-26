using System.Collections.Generic;

namespace Shard.Message.Domain.Shared
{
    public interface IProperties<TProperty>
    {
        List<TProperty> Properties { get; set; }
    }
}
