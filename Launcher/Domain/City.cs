namespace Launcher.Domain
{
    public class City : Shard.Message.Domain.Outgoing.ICityInfo
    {
        public string Name { get; set; }

        public string Town { get; set; }
    }
}