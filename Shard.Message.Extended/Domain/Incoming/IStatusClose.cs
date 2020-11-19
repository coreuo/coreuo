namespace Shard.Message.Extended.Domain.Incoming
{
    public interface IStatusClose
    {
        public int Serial { set; }

        internal int ReadStatusClose(IData data)
        {
            Serial = data.ReadExtendedInt(2);

            return 6;
        }
    }
}
