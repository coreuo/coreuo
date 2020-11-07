namespace Shard.Message.Domain.Outgoing
{
    public interface IWarModeResponse
    {
        byte WarMode { get; set; }

        internal void WriteWarModeResponse(IData data)
        {
            data.Write(1, WarMode);

            data.Write(2, (byte) 0x00);

            data.Write(3, (byte) 0x32);

            data.Write(4, (byte) 0x00);
        }
    }
}