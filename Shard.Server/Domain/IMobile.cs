namespace Shard.Server.Domain
{
    public interface IMobile<TItem, TEntity> : 
        IEntity<TItem, TEntity>
        where TItem : IItem<TItem, TEntity>
        where TEntity : IEntity<TItem, TEntity>
    {
        public string Name { get; set; }
    }
}
