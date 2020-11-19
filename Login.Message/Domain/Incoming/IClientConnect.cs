namespace Login.Message.Domain.Incoming
{
    public interface IClientConnect
    {
        public int Seed { set; }

        public int MajorVersion { set; }

        public int MinorVersion { set; }

        public int Patch { set; }

        public int Revision { set; }

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
