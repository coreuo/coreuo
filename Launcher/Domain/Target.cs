namespace Launcher.Domain
{
    public class Target :
        Shard.Message.Domain.ITarget,
        Shard.Server.Domain.ITarget
    {
        public int Id { get; set; }

        public Map Map { get; set; } = new Map();

        public ushort LocationX { get; set; }

        public ushort LocationY { get; set; }

        public sbyte LocationZ { get; set; }
    }
}
