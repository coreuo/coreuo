namespace Launcher.Domain
{
    public class Attribute : 
        Shard.Message.Domain.IAttribute
    {
        public int Number { get; set; }

        public string Arguments { get; set; }
    }
}
