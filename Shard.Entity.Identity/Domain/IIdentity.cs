using System;

namespace Shard.Entity.Identity.Domain
{
    public interface IIdentity
    {
        public Guid Guid { get; init; }

        public string Name { get; init; }
    }
}
