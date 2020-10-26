namespace Login.Message.Domain.Incoming
{
    public interface IShardSelect
    {
        public int ShardIndex { get; set; }

        internal int OnReadShardSelect(IData data)
        {
            ShardIndex = data.OnReadShort(1);

            return 3;
        }
    }
}
