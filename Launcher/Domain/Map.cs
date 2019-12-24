using System.Collections.Generic;

namespace Launcher.Domain
{
    public class Map : Shard.Message.Extended.Domain.IMap<MapPatch>
    {
        public byte Id { get; set; } = 2;

        public List<MapPatch> Patches { get; } = new List<MapPatch>
        {
            new MapPatch(),
            new MapPatch(),
            new MapPatch(),
            new MapPatch()
        };
    }
}
