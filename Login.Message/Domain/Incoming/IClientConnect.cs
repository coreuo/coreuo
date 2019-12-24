namespace Login.Message.Domain.Incoming
{
    public interface IClientConnect
    {
        public int Seed { get; set; }

        public int MajorVersion { get; set; }

        public int MinorVersion { get; set; }

        public int Patch { get; set; }

        public int Revision { get; set; }

        public int ReadClientConnect(IData data)
        {
            Seed = data.ReadInt(1);

            MajorVersion = data.ReadInt(5);

            MinorVersion = data.ReadInt(9);

            Patch = data.ReadInt(13);

            Revision = data.ReadInt(17);

            return 21;
        }
    }
}
