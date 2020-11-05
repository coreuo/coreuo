namespace Shard.Server.Domain
{
    public interface ITarget
    {
        public ushort LocationX { get; set; }

        public ushort LocationY { get; set; }

        public sbyte LocationZ { get; set; }
    }
}
