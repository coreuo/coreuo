namespace Shard.Message.Domain.Incoming
{
    public interface IDoubleClick
    {
        int DoubleClickSerial { get; set; }

        internal int OnReadDoubleClick(IData data)
        {
            DoubleClickSerial = data.OnReadInt(1);

            return 5;
        }
    }
}
