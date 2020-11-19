using Shard.Message.Domain.Shared;

namespace Shard.Message.Domain.Outgoing
{
    public interface IMobilePaperDoll :
        ISerialGet,
        IName
    {
        internal void WriteMobilePaperDoll(IData data)
        {
            data.Write(1, Serial);

            data.WriteAscii(5, Name, 60);
        }
    }
}
