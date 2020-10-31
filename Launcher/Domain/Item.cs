namespace Launcher.Domain
{
    using Property = Shard.Validation.Handlers<Validation>;

    public class Item : Entity,
        Shard.Message.Domain.IItem,
        Shard.Items.Domain.IItem,
        Shard.Server.Domain.IItem<Item>,
        Shard.Mobiles.Domain.IItem
    {
        public Item()
        {
            ItemId = default;
            Layer = default;
            Hue = default;
            Amount = default;
            LocationX = default;
            LocationY = default;
            LocationZ = default;
            GridIndex = default;
        }

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

        public ushort Amount
        {
            get => Property.Get<ushort>(this, nameof(Amount));
            set => Property.Set(this, nameof(Amount), value);
        }

        public ushort LocationX
        {
            get => Property.Get<ushort>(this, nameof(LocationX));
            set => Property.Set(this, nameof(LocationX), value);
        }

        public ushort LocationY
        {
            get => Property.Get<ushort>(this, nameof(LocationY));
            set => Property.Set(this, nameof(LocationY), value);
        }

        public byte LocationZ
        {
            get => Property.Get<byte>(this, nameof(LocationZ));
            set => Property.Set(this, nameof(LocationZ), value);
        }

        public byte GridIndex
        {
            get => Property.Get<byte>(this, nameof(GridIndex));
            set => Property.Set(this, nameof(GridIndex), value);
        }
    }
}
