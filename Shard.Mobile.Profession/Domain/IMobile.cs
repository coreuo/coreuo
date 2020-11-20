using System.Collections.Generic;

namespace Shard.Mobile.Profession.Domain
{
    public interface IMobile<in TIdentity>
    {
        bool Is(IEnumerable<TIdentity> identity);
    }
}
