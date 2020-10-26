namespace Launcher.Domain
{
    public class Property : 
        Shard.Message.Domain.IProperty
    {
        public int Number { get; set; }

        public string Arguments { get; set; }
    }
}
