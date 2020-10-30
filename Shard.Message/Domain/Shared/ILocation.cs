namespace Shard.Message.Domain.Shared
{
    public interface ILocation
    {
        public ushort LocationX { get; set; }

        public ushort LocationY { get; set; }

        public byte LocationZ { get; set; }
    }
}
