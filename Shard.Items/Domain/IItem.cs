namespace Shard.Items.Domain
{
    public interface IItem
    {
        ushort ItemId { get; set; }

        byte Layer { get; set; }

        short EntityDisplayId { get; set; }

        short Hue { get; set; }
    }
}
