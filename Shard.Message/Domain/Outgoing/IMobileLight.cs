namespace Shard.Message.Domain.Outgoing
{
    public interface IMobileLight
    {
        int Serial { get; set; }

        byte LightLevel { get; set; }

        internal void WriteMobileLight(IData data)
        {
            data.Write(1, Serial);

            data.Write(5, LightLevel);
        }
    }
}