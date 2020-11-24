namespace Network.State.Domain
{
    public interface ISettings
    {
        string IpAddress { get; }

        int? Port { get; }

        void Output(string text);
    }
}
