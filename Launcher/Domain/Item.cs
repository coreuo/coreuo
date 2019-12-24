namespace Launcher.Domain
{
    public class Item : Shard.Message.Domain.IItem
    {
        public int Serial { get; set; }

        public ushort ItemId { get; set; }

        public byte Layer { get; set; }

        public short Hue { get; set; }
    }
}
