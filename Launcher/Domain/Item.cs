using System.ComponentModel.DataAnnotations.Schema;

namespace Launcher.Domain
{
    public class Item : Entity,
        Shard.Message.Domain.IItem,
        Shard.Items.Domain.IItem,
        Shard.Server.Domain.IItem<Item>,
        Shard.Mobiles.Domain.IItem
    {
        public ushort ItemId { get; set; }

        public byte Layer { get; set; }

        public short Hue { get; set; }

        public ushort Amount { get; set; }

        public ushort LocationX { get; set; }

        public ushort LocationY { get; set; }

        public byte LocationZ { get; set; }

        public byte GridIndex { get; set; }

        [NotMapped] public new Access<Item> Access { get; set; }

        public Item(ShardSave save) : base(save)
        {
            Access = save.DerivedEntity(this).Flush();
        }
    }
}
