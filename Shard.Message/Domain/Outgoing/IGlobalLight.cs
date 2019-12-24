namespace Shard.Message.Domain.Outgoing
{
    public interface IGlobalLight
    {
        byte LightLevel { get; }

        internal void WriteGlobalLight(IData data)
        {
            data.Write(1, LightLevel);
        }
    }
}
