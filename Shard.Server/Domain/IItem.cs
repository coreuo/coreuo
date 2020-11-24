namespace Shard.Server.Domain
{
    public interface IItem<TItem, TEntity, in TIdentity> : 
        IEntity<TItem, TEntity, TIdentity>
        where TItem : IItem<TItem, TEntity, TIdentity>
        where TEntity : class, IEntity<TItem, TEntity, TIdentity>
    {
        byte GridIndex { get; set; }

        TEntity Parent { get; set; }

        byte Layer { get; }
    }
}
