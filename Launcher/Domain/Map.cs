using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Launcher.Domain
{
    public class Map :
        Shard.Message.Extended.Domain.IMap<MapPatch>,
        Shard.Message.Domain.IMap
    {
        // ReSharper disable once UnusedMember.Global
        public int Id { get; set; }

        public byte MapId { get; } = 1;

        /*public short MinimumX { get; set; } = 0;

        public short MinimumY { get; set; } = 0;

        public short MaximumX { get; set; } = 7168;

        public short MaximumY { get; set; } = 4096;*/

        [NotMapped]
        public List<MapPatch> Patches { get; } = new()
        {
            new MapPatch(),
            new MapPatch(),
            new MapPatch(),
            new MapPatch()
        };
    }
}
