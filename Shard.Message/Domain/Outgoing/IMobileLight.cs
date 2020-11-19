using Shard.Message.Domain.Shared;

namespace Shard.Message.Domain.Outgoing
{
    public interface IMobileLight :
        ISerialGet
    {
        public byte LightLevel { get; }

        internal void WriteMobileLight(IData data)
        {
            data.Write(1, Serial);

            data.Write(5, LightLevel);
        }
    }
}