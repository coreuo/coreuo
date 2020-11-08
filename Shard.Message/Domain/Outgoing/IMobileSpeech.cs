using Shard.Message.Domain.Shared;

namespace Shard.Message.Domain.Outgoing
{
    public interface IMobileSpeech :
        ISerial,
        IName
    {
        internal void WriteMobileSpeech(IData data)
        {
            data.Write(3, Serial);

            data.WriteAscii(18, Name, 30);
        }
    }
}
