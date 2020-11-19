namespace Shard.Message.Extended.Domain.Incoming
{
    public interface IClientLanguage
    {
        public string ClientLanguage { set; }

        internal int ReadClientLanguage(IData data)
        {
            ClientLanguage = data.ReadExtendedString(2, 3);

            return 3;
        }
    }
}
