namespace Shard.Message.Extended.Domain.Incoming
{
    public interface IClientLanguage
    {
        public string ClientLanguage { get; set; }

        internal int OnReadClientLanguage(IData data)
        {
            ClientLanguage = data.OnReadString(2, 3);

            return 3;
        }
    }
}
