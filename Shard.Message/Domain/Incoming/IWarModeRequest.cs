namespace Shard.Message.Domain.Incoming
{
    public interface IWarModeRequest
    {
        byte WarMode { set; }

        internal int ReadWarModeRequest(IData data)
        {
            WarMode = data.ReadByte(1);

            return 5;
        }
    }
}
