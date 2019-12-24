namespace Shard.Message.Domain.Incoming
{
    public interface IAccountLogin
    {
        int AuthorizationId { get; set; }

        string Name { get; set; }

        string Password { get; set; }

        internal int ReadAccountLogin(IData data)
        {
            AuthorizationId = data.ReadInt(1);

            Name = data.ReadString(5, 30);

            Password = data.ReadString(35, 30);

            return 65;
        }
    }
}
