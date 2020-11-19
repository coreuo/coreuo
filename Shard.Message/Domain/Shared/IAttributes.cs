using System.Collections.Generic;

namespace Shard.Message.Domain.Shared
{
    public interface IAttributes<TAttribute>
    {
        public List<TAttribute> Attributes { get; }
    }
}
