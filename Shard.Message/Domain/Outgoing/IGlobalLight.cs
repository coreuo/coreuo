namespace Shard.Message.Domain.Outgoing
{
    public interface IGlobalLight
    {
        byte LightLevel { get; }

        internal void OnWriteGlobalLight(IData data)
        {
            data.OnWrite(1, LightLevel);
        }
    }
}
