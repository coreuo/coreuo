namespace Login.Message.Domain.Incoming
{
    public interface IAccountLogin
    {
        string Name { get; set; }

        string Password { get; set; }

        int ReadAccountLogin(IData data)
        {
            Name = data.ReadString(1, 30);

            Password = data.ReadString(31, 30);

            return 62;
        }
    }
}
