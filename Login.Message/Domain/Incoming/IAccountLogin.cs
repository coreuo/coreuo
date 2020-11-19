namespace Login.Message.Domain.Incoming
{
    public interface IAccountLogin
    {
        string Name { set; }

        string Password { set; }

        int ReadAccountLogin(IData data)
        {
            Name = data.ReadAscii(1, 30);

            Password = data.ReadAscii(31, 30);

            return 62;
        }
    }
}
