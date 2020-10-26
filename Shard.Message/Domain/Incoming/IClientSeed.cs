namespace Shard.Message.Domain.Incoming
{
    public interface IClientSeed
    {
        public int Seed { get; set; }

        internal int OnReadClientSeed(IData data)
        {
            Seed = data.OnReadInt(0);

            return 4;
        }
    }
}
