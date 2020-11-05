namespace Launcher.Domain
{
    public class Item : Entity,
        Shard.Message.Domain.IItem<Attribute, Item, Entity>,
        Shard.Items.Domain.IItem,
        Shard.Server.Domain.IItem<Item, Entity>,
        Shard.Mobiles.Domain.IItem<Item>
    {
        public Entity Parent { get; set; }

        public ushort ItemId { get; set; }

        public byte Layer { get; set; }

        public ushort Hue { get; set; }

        public ushort Amount { get; set; }

        public byte GridIndex { get; set; }

        public byte ItemFlags { get; set; }
    }
}
