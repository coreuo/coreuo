namespace Shard.Message.Extended.Domain.Outgoing
{
    public interface IMapPatch
    {
        int StaticBlocks { get; }

        int LandBlocks { get; }

        internal void WriteMapPatch(int index, IData data)
        {
            data.WriteExtended(6 + index * 8, StaticBlocks);

            data.WriteExtended(6 + index * 8 + 4, LandBlocks);
        }
    }
}