using System.Collections.Generic;

namespace Shard.Server.Domain
{
    public interface IEntity<TItem, TEntity, in TIdentity> :
        ITarget
        where TItem : IItem<TItem, TEntity, TIdentity>
        where TEntity : class, IEntity<TItem, TEntity, TIdentity>
    {
        int Serial { get; init; }

        ushort Hue { get; }

        List<TItem> Items { get; }

        bool Is(params TIdentity[] identities);

        void Assign(params TIdentity[] identities);

        void Assign(IEnumerable<TIdentity> identities);
    }
}
