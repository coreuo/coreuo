namespace Launcher.Domain
{
    using Property = Shard.Server.Validation.Handlers<Validation>;

    public class MapPatch : Shard.Message.Extended.Domain.Outgoing.IMapPatch
    {
        public int StaticBlocks
        {
            get => Property.OnGet<int>(this, nameof(StaticBlocks));
            set => Property.OnSet(this, nameof(StaticBlocks), value);
        }

        public int LandBlocks
        {
            get => Property.OnGet<int>(this, nameof(LandBlocks));
            set => Property.OnSet(this, nameof(LandBlocks), value);
        }

        public MapPatch()
        {
            StaticBlocks = default;
            LandBlocks = default;
        }
    }
}
