namespace Launcher.Domain
{
    public class Item : Entity,
        Shard.Message.Domain.IItem<Attribute, Item, Entity>,
        Shard.Server.Domain.IItem<Item, Entity, Identity>,
        Shard.Entity.Items.Domain.IItem,
        Shard.Mobile.Race.Domain.IItem,
        Game.Data.Domain.IItem
    {
        public Entity Parent { get; set; }

        public ulong TileArtFlags { get; set; }

        public int Weight { get; set; }

        public int Height { get; set; }

        public byte Layer { get; set; }

        public ushort Amount { get; set; }

        public byte GridIndex { get; set; }

        public byte ItemFlags { get; } = 0;
    }
}
