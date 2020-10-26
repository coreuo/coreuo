using Shard.Message.Domain.Shared;

namespace Shard.Message.Domain.Outgoing
{
    public interface IMobileLight :
        ISerial
    {
        byte LightLevel { get; set; }

        internal void OnWriteMobileLight(IData data)
        {
            data.OnWrite(1, Serial);

            data.OnWrite(5, LightLevel);
        }
    }
}