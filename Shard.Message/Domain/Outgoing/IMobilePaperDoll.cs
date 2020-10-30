using Shard.Message.Domain.Shared;

namespace Shard.Message.Domain.Outgoing
{
    public interface IMobilePaperDoll :
        ISerial,
        IName
    {
        internal void WriteMobilePaperDoll(IData data)
        {
            data.Write(1, Serial);

            data.WriteAscii(5, Name + ", Legendary Alchemist", 60);
        }
    }
}
