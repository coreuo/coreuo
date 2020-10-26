namespace Shard.Message.Domain.Shared
{
    public interface ILocation
    {
        ushort LocationX { get; set; }

        ushort LocationY { get; set; }

        byte LocationZ { get; set; }
    }
}
