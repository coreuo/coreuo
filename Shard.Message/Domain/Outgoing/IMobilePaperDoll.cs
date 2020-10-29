using Shard.Message.Domain.Shared;

namespace Shard.Message.Domain.Outgoing
{
    public interface IMobilePaperDoll :
        ISerial,
        IName
    {
        internal void OnWriteMobilePaperDoll(IData data)
        {
            data.OnWrite(1, Serial);

            data.OnWriteAscii(5, Name + ", Legendary Alchemist", 60);
        }
    }
}
