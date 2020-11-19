using Shard.Message.Domain.Shared;

namespace Shard.Message.Domain.Incoming
{
    public interface IAccountLogin :
        IName,
        IPassword
    {
        int AuthorizationId { set; }

        internal int ReadAccountLogin(IData data)
        {
            AuthorizationId = data.ReadInt(1);

            Name = data.ReadAscii(5, 30);

            Password = data.ReadAscii(35, 30);

            return 65;
        }
    }
}
