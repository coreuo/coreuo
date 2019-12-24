namespace Launcher.Domain
{
    public class MapPatch : Shard.Message.Extended.Domain.Outgoing.IMapPatch
    {
        public int StaticBlocks { get; set; }

        public int LandBlocks { get; set; }
    }
}
