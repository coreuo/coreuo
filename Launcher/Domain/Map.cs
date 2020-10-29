using System.Collections.Generic;

namespace Launcher.Domain
{
    using Property = Shard.Server.Validation.Handlers<Validation>;

    public class Map :
        Shard.Message.Extended.Domain.IMap<MapPatch>,
        Shard.Message.Domain.IMap
    {
        public byte Id
        {
            get => Property.OnGet<byte>(this, nameof(Id));
            set => Property.OnSet(this, nameof(Id), value, () => 2);
        }

        public short MinimumX
        {
            get => Property.OnGet<short>(this, nameof(MinimumX));
            set => Property.OnSet(this, nameof(MinimumX), value, () => 0);
        }

        public short MinimumY
        {
            get => Property.OnGet<short>(this, nameof(MinimumY));
            set => Property.OnSet(this, nameof(MinimumY), value, () => 0);
        }

        public short MaximumX
        {
            get => Property.OnGet<short>(this, nameof(MaximumX));
            set => Property.OnSet(this, nameof(MaximumX), value, () => 7168);
        }

        public short MaximumY
        {
            get => Property.OnGet<short>(this, nameof(MaximumY));
            set => Property.OnSet(this, nameof(MaximumY), value, () => 4096);
        }

        public List<MapPatch> Patches
        {
            get => Property.OnGet<List<MapPatch>>(this, nameof(Patches));
            set => Property.OnSet(this, nameof(Patches), value, () => new List<MapPatch> {new MapPatch(), new MapPatch(), new MapPatch(), new MapPatch()});
        }

        public Map()
        {
            Id = default;
            MinimumX = default;
            MinimumY = default;
            MaximumX = default;
            MaximumY = default;
            Patches = default;
        }
    }
}
