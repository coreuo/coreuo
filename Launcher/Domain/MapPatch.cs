using System.ComponentModel.DataAnnotations.Schema;

namespace Launcher.Domain
{
    [NotMapped]
    public class MapPatch : Shard.Message.Extended.Domain.Outgoing.IMapPatch
    {
        public int StaticBlocks { get; } = 0;

        public int LandBlocks { get; } = 0;
    }
}
