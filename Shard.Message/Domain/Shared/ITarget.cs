namespace Shard.Message.Domain.Shared
{
    public interface ITarget
    {
        int TargetId { get; set; }

        byte TargetMode { get; set; }

        byte TargetType { get; set; }
    }
}
