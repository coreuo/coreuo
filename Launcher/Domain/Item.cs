namespace Launcher.Domain
{
    using Property = Shard.Validation.Handlers<Validation>;

    public class Item : Entity,
        Shard.Message.Domain.IItem,
        Shard.Items.Domain.IItem,
        Shard.Server.Domain.IItem,
        Shard.Mobiles.Domain.IItem
    {
        public ushort ItemId
        {
            get => Property.Get<ushort>(this, nameof(ItemId));
            set => Property.Set(this, nameof(ItemId), value);
        }

        public byte Layer
        {
            get => Property.Get<byte>(this, nameof(Layer));
            set => Property.Set(this, nameof(Layer), value);
        }

        public short Hue
        {
            get => Property.Get<short>(this, nameof(Hue));
            set => Property.Set(this, nameof(Hue), value);
        }

        public Item()
        {
            ItemId = default;
            Layer = default;
            Hue = default;
        }
    }
}
