namespace Launcher.Domain
{
    using Property = Shard.Server.Validation.Handlers<Validation>;

    public class MapPatch : Shard.Message.Extended.Domain.Outgoing.IMapPatch
    {
        public int StaticBlocks
        {
            get => Property.Get<int>(this, nameof(StaticBlocks));
            set => Property.Set(this, nameof(StaticBlocks), value);
        }

        public int LandBlocks
        {
            get => Property.Get<int>(this, nameof(LandBlocks));
            set => Property.Set(this, nameof(LandBlocks), value);
        }

        public MapPatch()
        {
            StaticBlocks = default;
            LandBlocks = default;
        }
    }
}
