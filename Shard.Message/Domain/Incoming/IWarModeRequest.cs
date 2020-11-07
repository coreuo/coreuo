namespace Shard.Message.Domain.Incoming
{
    public interface IWarModeRequest
    {
        byte WarMode { get; set; }

        internal int ReadWarModeRequest(IData data)
        {
            WarMode = data.ReadByte(1);

            return 5;
        }
    }
}
