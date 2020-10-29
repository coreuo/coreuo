namespace Shard.Message.Domain.Incoming
{
    public interface IAccountLogin
    {
        int AuthorizationId { get; set; }

        string Name { get; set; }

        string Password { get; set; }

        internal int OnReadAccountLogin(IData data)
        {
            AuthorizationId = data.OnReadInt(1);

            Name = data.OnReadAscii(5, 30);

            Password = data.OnReadAscii(35, 30);

            return 65;
        }
    }
}
