using System.Net;

namespace Login.Message.Domain.Outgoing
{
    public interface IShardServer
    {
        string IpAddress { get; set; }

        int Port { get; set; }

        int AuthorizationId { get; set; }

        internal void OnWriteShardServer(IData data)
        {
            IPAddress.Parse(IpAddress).GetAddressBytes().CopyTo(data.Value, 1);

            data.OnWrite(5, (short)Port);

            data.OnWrite(7, AuthorizationId);
        }
    }
}
