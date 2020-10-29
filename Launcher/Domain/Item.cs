namespace Launcher.Domain
{
    using Property = Shard.Server.Validation.Handlers<Validation>;

    public class Item : Entity,
        Shard.Message.Domain.IItem
    {
        public ushort ItemId
        {
            get => Property.OnGet<ushort>(this, nameof(ItemId));
            set => Property.OnSet(this, nameof(ItemId), value);
        }

        public byte Layer
        {
            get => Property.OnGet<byte>(this, nameof(Layer));
            set => Property.OnSet(this, nameof(Layer), value);
        }

        public short Hue
        {
            get => Property.OnGet<short>(this, nameof(Hue));
            set => Property.OnSet(this, nameof(Hue), value);
        }

        public Item()
        {
            ItemId = default;
            Layer = default;
            Hue = default;
        }
    }
}
