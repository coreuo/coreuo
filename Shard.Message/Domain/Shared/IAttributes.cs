using System.Collections.Generic;

namespace Shard.Message.Domain.Shared
{
    public interface IAttributes<TAttribute>
    {
        List<TAttribute> Attributes { get; set; }
    }
}
