namespace Shard.Message.Domain
{
    public interface IAttribute
    {
        int Number { get; set; }

        string Arguments { get; set; }
    }
}
