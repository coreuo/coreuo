namespace Launcher.Domain
{
    public class Target :
        Shard.Message.Domain.ITarget,
        Shard.Server.Domain.ITarget
    {
        // ReSharper disable once UnusedMember.Global
        public int Id { get; set; }

        public Map Map { get; } = new();

        public ushort LocationX { get; set; } = 3500;

        public ushort LocationY { get; set; } = 2575;

        public sbyte LocationZ { get; set; } = 14;
    }
}
