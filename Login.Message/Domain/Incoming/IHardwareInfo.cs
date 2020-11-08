namespace Login.Message.Domain.Incoming
{
    public interface IHardwareInfo
    {
        bool OldClient { get; set; }

        int InstanceId { get; set; }

        int OsMajor { get; set; }

        int OsMinor { get; set; }

        int OsRevision { get; set; }

        int CpuManufacturer { get; set; }

        int CpuFamily { get; set; }

        int CpuModel { get; set; }

        int CpuClockSpeed { get; set; }

        int CpuQuantity { get; set; }

        int PhysicalMemory { get; set; }

        int ScreenWidth { get; set; }

        int ScreenHeight { get; set; }

        int ScreenDepth { get; set; }

        int DirectXMajor { get; set; }

        int DirectXMinor { get; set; }

        string VideoCardDescription { get; set; }

        int VideoCardVendorId { get; set; }

        int VideoCardDeviceId { get; set; }

        int VideoCardMemory { get; set; }

        int Distribution { get; set; }

        int ClientsRunning { get; set; }

        int ClientsInstalled { get; set; }

        int PartialInstalled { get; set; }

        string Language { get; set; }

        public int ReadHardwareInfo(IData data)
        {
            OldClient = data.ReadByte(1) > 0;

            InstanceId = data.ReadInt(2);

            OsMajor = data.ReadInt(6);

            OsMinor = data.ReadInt(10);

            OsRevision = data.ReadInt(14);

            CpuManufacturer = data.ReadByte(18);

            CpuFamily = data.ReadInt(19);

            CpuModel = data.ReadInt(23);

            CpuClockSpeed = data.ReadInt(27);

            CpuQuantity = data.ReadByte(31);

            PhysicalMemory = data.ReadInt(32);

            ScreenWidth = data.ReadInt(36);

            ScreenHeight = data.ReadInt(40);

            ScreenDepth = data.ReadInt(44);

            DirectXMajor = data.ReadShort(48);

            DirectXMinor = data.ReadShort(50);

            VideoCardDescription = data.ReadAscii(52, 128);

            VideoCardVendorId = data.ReadInt(180);

            VideoCardDeviceId = data.ReadInt(184);

            VideoCardMemory = data.ReadInt(188);

            Distribution = data.ReadByte(192);

            ClientsRunning = data.ReadByte(193);

            ClientsInstalled = data.ReadByte(194);

            PartialInstalled = data.ReadByte(195);

            Language = data.ReadAscii(196, 6);

            return 268;
        }
    }
}
