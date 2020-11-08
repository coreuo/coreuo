namespace Shard.Message.Domain.Outgoing
{
    public interface ITargetRequest :
        Shared.ITarget
    {
        internal void WriteTargetRequest(IData data)
        {
            data.Write(1, TargetMode);

            data.Write(2, TargetId);

            data.Write(6, TargetType);

            data.Clear(7, 12);
        }
    }
}
