namespace Login.Message.Domain
{
    public interface IShard
    {
        string Identity { get; }

        int Percentage { get; }

        int TimeZone { get; }

        string IpAddress { get; }
    }
}
