namespace Shard.Mobile.Race.Domain
{
    public interface IEntity<in TIdentity>
    {
        bool Is(params TIdentity[] identity);
    }
}
