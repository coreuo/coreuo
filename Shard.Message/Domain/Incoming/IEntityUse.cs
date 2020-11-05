namespace Shard.Message.Domain.Incoming
{
    public interface IEntityUse
    {
        int EntityUseSerial { get; set; }

        internal int ReadEntityUse(IData data)
        {
            EntityUseSerial = data.ReadInt(1);

            return 5;
        }
    }
}
