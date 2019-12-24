using System;

namespace Network.State.Domain
{
    public interface ISettings
    {
        string IpAddress { get; set; }

        int Port { get; set; }

        Action<string> Output { get; }
    }
}
