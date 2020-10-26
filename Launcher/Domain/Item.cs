namespace Launcher.Domain
{
    public class Item : Entity,
        Shard.Message.Domain.IItem
    {
        public ushort ItemId { get; set; }

        public byte Layer { get; set; }

        public short Hue { get; set; }
    }
}
