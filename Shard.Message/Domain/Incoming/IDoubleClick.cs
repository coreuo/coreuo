namespace Shard.Message.Domain.Incoming
{
    public interface IDoubleClick
    {
        int DoubleClickSerial { get; set; }

        internal int ReadDoubleClick(IData data)
        {
            DoubleClickSerial = data.ReadInt(1);

            return 5;
        }
    }
}
