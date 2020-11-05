namespace Shard.Mobiles.Domain
{
    public interface IEntity<TItem>
        where TItem : IItem<TItem>
    {
    }
}
