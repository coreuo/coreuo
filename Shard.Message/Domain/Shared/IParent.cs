namespace Shard.Message.Domain.Shared
{
    public interface IParent<out TEntity>
    {
        TEntity Parent { get; }
    }
}
