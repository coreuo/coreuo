using System;

namespace Launcher.Domain
{
    public class Identity :
        Shard.Entity.Identity.Domain.IIdentity
    {
        public Guid Guid { get; init; }

        public string Name { get; init; }

        public override string ToString() => Name;
    }
}
