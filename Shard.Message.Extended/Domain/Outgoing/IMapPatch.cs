namespace Shard.Message.Extended.Domain.Outgoing
{
    public interface IMapPatch
    {
        int StaticBlocks { get; set; }

        int LandBlocks { get; set; }

        internal void OnWriteMapPatch(int index, IData data)
        {
            data.OnWrite(6 + index * 8, StaticBlocks);

            data.OnWrite(6 + index * 8 + 4, LandBlocks);
        }
    }
}