namespace Shard.Message.Domain.Incoming
{
    public interface IChatRequest
    {
        public string ChatName { get; set; }

        internal int OnReadChatRequest(IData data)
        {
            ChatName = data.OnReadAscii(1, 63);

            return 64;
        }
    }
}
