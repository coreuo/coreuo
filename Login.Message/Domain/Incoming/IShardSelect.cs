namespace Login.Message.Domain.Incoming
{
    public interface IShardSelect
    {
        public int ShardIndex { get; set; }

        internal int ReadShardSelect(IData data)
        {
            ShardIndex = data.ReadShort(1);

            return 3;
        }
    }
}
