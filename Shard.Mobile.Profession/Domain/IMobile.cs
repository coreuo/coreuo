using System.Collections.Generic;

namespace Shard.Mobile.Profession.Domain
{
    public interface IMobile<in TIdentity>
        where TIdentity : class
    {
        bool Is(IEnumerable<TIdentity> identity);
    }
}
