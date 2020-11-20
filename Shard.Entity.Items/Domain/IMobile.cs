namespace Shard.Entity.Items.Domain
{
    public interface IMobile<in TItem>
    {
        TItem Backpack { set; }
    }
}
