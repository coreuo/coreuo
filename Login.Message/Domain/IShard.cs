namespace Login.Message.Domain
{
    public interface IShard
    {
        string Identity { get; set; }

        int Percentage { get; set; }

        int TimeZone { get; set; }

        string IpAddress { get; set; }
    }
}
