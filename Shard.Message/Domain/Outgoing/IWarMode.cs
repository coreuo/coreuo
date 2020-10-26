namespace Shard.Message.Domain.Outgoing
{
    public interface IWarMode
    {
        byte WarMode { get; set; }

        internal void OnWriteWarMode(IData data)
        {
            data.OnWrite(1, WarMode);

            data.OnWrite(2, (byte) 0x00);

            data.OnWrite(3, (byte) 0x32);

            data.OnWrite(4, (byte) 0x00);
        }
    }
}