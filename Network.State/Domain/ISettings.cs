using System;

namespace Network.State.Domain
{
    public interface ISettings
    {
        string IpAddress { get; }

        int Port { get; }

        Action<string> Output { get; }
    }
}
