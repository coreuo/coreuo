namespace Shard.Server.Domain
{
    public interface IItem<TItem, TEntity> : 
        IEntity<TItem, TEntity>
        where TItem : IItem<TItem, TEntity>
        where TEntity : class, IEntity<TItem, TEntity>
    {
        ushort ItemId { get; }

        byte GridIndex { get; set; }

        TEntity Parent { get; set; }

        byte Layer { get; set; }
    }
}
