namespace Shard.Message.Domain.Incoming
{
    public interface IExtendedData
    {
        public int ExtendedOffset { set; }

        public int ExtendedLength { set; }

        internal int ReadExtendedData(IData data)
        {
            var size = data.ReadShort(1);

            ExtendedOffset = data.Offset + 3;

            ExtendedLength = size - 3;

            return size;
        }
    }
}
