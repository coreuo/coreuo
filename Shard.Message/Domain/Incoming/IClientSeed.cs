namespace Shard.Message.Domain.Incoming
{
    public interface IClientSeed
    {
        public int Seed { get; set; }

        internal int ReadClientSeed(IData data)
        {
            Seed = data.ReadInt(0);

            return 4;
        }
    }
}
