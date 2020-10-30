using System.Collections.Generic;

namespace Launcher.Domain
{
    using Property = Shard.Validation.Handlers<Validation>;

    public class Map :
        Shard.Message.Extended.Domain.IMap<MapPatch>,
        Shard.Message.Domain.IMap
    {
        public byte Id
        {
            get => Property.Get<byte>(this, nameof(Id));
            set => Property.Set(this, nameof(Id), value, () => 2);
        }

        public short MinimumX
        {
            get => Property.Get<short>(this, nameof(MinimumX));
            set => Property.Set(this, nameof(MinimumX), value, () => 0);
        }

        public short MinimumY
        {
            get => Property.Get<short>(this, nameof(MinimumY));
            set => Property.Set(this, nameof(MinimumY), value, () => 0);
        }

        public short MaximumX
        {
            get => Property.Get<short>(this, nameof(MaximumX));
            set => Property.Set(this, nameof(MaximumX), value, () => 7168);
        }

        public short MaximumY
        {
            get => Property.Get<short>(this, nameof(MaximumY));
            set => Property.Set(this, nameof(MaximumY), value, () => 4096);
        }

        public List<MapPatch> Patches
        {
            get => Property.Get<List<MapPatch>>(this, nameof(Patches));
            set => Property.Set(this, nameof(Patches), value, () => new List<MapPatch> {new MapPatch(), new MapPatch(), new MapPatch(), new MapPatch()});
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
