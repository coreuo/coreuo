using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Launcher.Domain
{
    public class Map :
        Shard.Message.Extended.Domain.IMap<MapPatch>,
        Shard.Message.Domain.IMap
    {
        public int Id { get; set; }

        public byte MapId { get; set; } = 2;

        /*public short MinimumX { get; set; } = 0;

        public short MinimumY { get; set; } = 0;

        public short MaximumX { get; set; } = 7168;

        public short MaximumY { get; set; } = 4096;*/

        [NotMapped]
        public List<MapPatch> Patches { get; } = new List<MapPatch>
        {
            new MapPatch(),
            new MapPatch(),
            new MapPatch(),
            new MapPatch()
        };
    }
}
