namespace Shard.Message.Extended.Domain.Incoming
{
    public interface IClientLanguage
    {
        public string ClientLanguage { get; set; }

        internal int ReadClientLanguage(IData data)
        {
            ClientLanguage = data.ReadString(2, 3);

            return 3;
        }
    }
}
