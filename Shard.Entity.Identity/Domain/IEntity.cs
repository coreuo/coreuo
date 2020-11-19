using System;
using System.Collections.Generic;

namespace Shard.Entity.Identity.Domain
{
    public interface IEntity<TIdentity>
        where TIdentity : IIdentity
    {
        HashSet<Guid> GuidIdentities { get; set; }

        HashSet<TIdentity> Identities { get; set; }
    }
}
