namespace Login.Message.Domain.Incoming
{
    public interface IAccountLogin
    {
        string Name { get; set; }

        string Password { get; set; }

        int OnReadAccountLogin(IData data)
        {
            Name = data.OnReadString(1, 30);

            Password = data.OnReadString(31, 30);

            return 62;
        }
    }
}
