namespace Shard.Message.Domain
{
    public interface IAttribute
    {
        int Number { get; }

        string Arguments { get; }
    }
}
