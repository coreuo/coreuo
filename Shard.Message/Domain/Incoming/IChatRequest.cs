namespace Shard.Message.Domain.Incoming
{
    public interface IChatRequest
    {
        public string ChatName { get; set; }

        internal int OnReadChatRequest(IData data)
        {
            ChatName = data.OnReadString(1, 63);

            return 64;
        }
    }
}
