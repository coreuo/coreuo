using Shard.Message.Domain.Shared;

namespace Shard.Message.Domain.Incoming
{
    public interface IPingRequest :
        INumber
    {
        internal int ReadPingRequest(IData data)
        {
            Number = data.ReadByte(1);

            return 2;
        }
    }
}
