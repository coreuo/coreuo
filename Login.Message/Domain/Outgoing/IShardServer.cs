using System;
using System.Net;

namespace Login.Message.Domain.Outgoing
{
    public interface IShardServer
    {
        string IpAddress { get; }

        int? Port { get; }

        int AuthorizationId { get; }

        internal void WriteShardServer(IData data)
        {
            if (IpAddress == null || Port == null) throw new InvalidOperationException($"Unknown ip address ({IpAddress}) or port ({Port}) for shard server.");

            IPAddress.Parse(IpAddress).GetAddressBytes().CopyTo(data.Value, 1);

            data.Write(5, (short)Port);

            data.Write(7, AuthorizationId);
        }
    }
}
