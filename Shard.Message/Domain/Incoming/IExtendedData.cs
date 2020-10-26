namespace Shard.Message.Domain.Incoming
{
    public interface IExtendedData
    {
        public int ExtendedOffset { get; set; }

        public int ExtendedLength { get; set; }

        internal int OnReadExtendedData(IData data)
        {
            var size = data.OnReadShort(1);

            ExtendedOffset = data.Offset + 3;

            ExtendedLength = size - 3;

            return size;
        }
    }
}
