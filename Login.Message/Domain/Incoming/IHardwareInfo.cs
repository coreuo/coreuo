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

        public int OnReadHardwareInfo(IData data)
        {
            OldClient = data.OnReadByte(1) > 0;

            InstanceId = data.OnReadInt(2);

            OsMajor = data.OnReadInt(6);

            OsMinor = data.OnReadInt(10);

            OsRevision = data.OnReadInt(14);

            CpuManufacturer = data.OnReadByte(18);

            CpuFamily = data.OnReadInt(19);

            CpuModel = data.OnReadInt(23);

            CpuClockSpeed = data.OnReadInt(27);

            CpuQuantity = data.OnReadByte(31);

            PhysicalMemory = data.OnReadInt(32);

            ScreenWidth = data.OnReadInt(36);

            ScreenHeight = data.OnReadInt(40);

            ScreenDepth = data.OnReadInt(44);

            DirectXMajor = data.OnReadShort(48);

            DirectXMinor = data.OnReadShort(50);

            VideoCardDescription = data.OnReadString(52, 128);

            VideoCardVendorId = data.OnReadInt(180);

            VideoCardDeviceId = data.OnReadInt(184);

            VideoCardMemory = data.OnReadInt(188);

            Distribution = data.OnReadByte(192);

            ClientsRunning = data.OnReadByte(193);

            ClientsInstalled = data.OnReadByte(194);

            PartialInstalled = data.OnReadByte(195);

            Language = data.OnReadString(196, 6);

            return 268;
        }
    }
}
