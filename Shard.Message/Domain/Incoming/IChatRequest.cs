namespace Shard.Message.Domain.Incoming
{
    public interface IChatRequest
    {
        public string ChatName { get; set; }

        internal int ReadChatRequest(IData data)
        {
            ChatName = data.ReadString(1, 63);

            return 64;
        }
    }
}
