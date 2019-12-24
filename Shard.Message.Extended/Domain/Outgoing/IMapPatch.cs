namespace Shard.Message.Extended.Domain.Outgoing
{
    public interface IMapPatch
    {
        int StaticBlocks { get; set; }

        int LandBlocks { get; set; }

        internal void WriteMapPatch(int index, IData data)
        {
            data.Write(6 + index * 8, StaticBlocks);

            data.Write(6 + index * 8 + 4, LandBlocks);
        }
    }
}