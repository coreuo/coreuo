namespace Shard.Entity.Items.Domain
{
    public interface IEntity<in TIdentity>
    {
        bool Is(params TIdentity[] identity);
    }
}
