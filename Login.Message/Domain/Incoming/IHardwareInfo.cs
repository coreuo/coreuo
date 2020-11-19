namespace Login.Message.Domain.Incoming
{
    public interface IHardwareInfo
    {
        bool OldClient { set; }

        int InstanceId { set; }

        int OsMajor { set; }

        int OsMinor { set; }

        int OsRevision { set; }

        int CpuManufacturer { set; }

        int CpuFamily { set; }

        int CpuModel { set; }

        int CpuClockSpeed { set; }

        int CpuQuantity { set; }

        int PhysicalMemory { set; }

        int ScreenWidth { set; }

        int ScreenHeight { set; }

        int ScreenDepth { set; }

        int DirectXMajor { set; }

        int DirectXMinor { set; }

        string VideoCardDescription { set; }

        int VideoCardVendorId { set; }

        int VideoCardDeviceId { set; }

        int VideoCardMemory { set; }

        int Distribution { set; }

        int ClientsRunning { set; }

        int ClientsInstalled { set; }

        int PartialInstalled { set; }

        string Language { set; }

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
