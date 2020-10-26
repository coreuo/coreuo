namespace Login.Message.Domain.Incoming
{
    public interface IClientConnect
    {
        public int Seed { get; set; }

        public int MajorVersion { get; set; }

        public int MinorVersion { get; set; }

        public int Patch { get; set; }

        public int Revision { get; set; }

        public int OnReadClientConnect(IData data)
        {
            Seed = data.OnReadInt(1);

            MajorVersion = data.OnReadInt(5);

            MinorVersion = data.OnReadInt(9);

            Patch = data.OnReadInt(13);

            Revision = data.OnReadInt(17);

            return 21;
        }
    }
}
