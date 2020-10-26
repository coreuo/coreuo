namespace Shard.Message.Domain
{
    public interface IProperty
    {
        int Number { get; set; }

        string Arguments { get; set; }
    }
}
