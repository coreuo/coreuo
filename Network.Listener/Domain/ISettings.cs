using System;

namespace Network.Listener.Domain
{
    public interface ISettings
    {
        string Identity { get; set; }

        string IpAddress { get; set; }

        int Port { get; set; }

        Action<string> Output { get; }
    }
}
