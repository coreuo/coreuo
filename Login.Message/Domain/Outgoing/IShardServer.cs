using System.Net;

namespace Login.Message.Domain.Outgoing
{
    public interface IShardServer
    {
        string IpAddress { get; }

        int Port { get; }

        int AuthorizationId { get; }

        internal void WriteShardServer(IData data)
        {
            IPAddress.Parse(IpAddress).GetAddressBytes().CopyTo(data.Value, 1);

            data.Write(5, (short)Port);

            data.Write(7, AuthorizationId);
        }
    }
}
