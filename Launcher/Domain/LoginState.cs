using System;
using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;

namespace Launcher.Domain
{
    using NetworkStateHandlers = Network.State.Handlers<Data>;

    public class LoginState : 
        Network.Listener.Domain.ISocket,
        Network.State.Domain.IReceiver<Data>,
        Network.State.Domain.ISender<Data>,
        Network.Server.Domain.IState<Data>,
        Login.Message.Domain.IState<Data>,
        Login.Encryption.Domain.IState,
        Login.Server.Domain.IState
    {
        public string Identity { get; set; }

        public string IpAddress { get; set; }

        public int Port { get; set; }

        public bool Locked { get; set; }

        public bool Receiving { get; set; }

        public int Sending { get; set; }

        public DateTime Last { get; set; }

        public Socket Socket { get; set; }

        public EndPoint EndPoint { get; set; }

        public ConcurrentQueue<Data> BufferQueue { get; } = new ConcurrentQueue<Data>();

        public ConcurrentQueue<Data> ReceiveQueue { get; } = new ConcurrentQueue<Data>();

        public int Seed { get; set; }

        public int MajorVersion { get; set; }

        public int MinorVersion { get; set; }

        public int Patch { get; set; }

        public int Revision { get; set; }

        public uint FirstClientKey { get; set; }

        public uint SecondClientKey { get; set; }

        public uint FirstCurrentKey { get; set; }

        public uint SecondCurrentKey { get; set; }

        public bool Encrypted { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public bool OldClient { get; set; }

        public int InstanceId { get; set; }

        public int OsMajor { get; set; }

        public int OsMinor { get; set; }

        public int OsRevision { get; set; }

        public int CpuManufacturer { get; set; }

        public int CpuFamily { get; set; }

        public int CpuModel { get; set; }

        public int CpuClockSpeed { get; set; }

        public int CpuQuantity { get; set; }

        public int PhysicalMemory { get; set; }

        public int ScreenWidth { get; set; }

        public int ScreenHeight { get; set; }

        public int ScreenDepth { get; set; }

        public int DirectXMajor { get; set; }

        public int DirectXMinor { get; set; }

        public string VideoCardDescription { get; set; }

        public int VideoCardVendorId { get; set; }

        public int VideoCardDeviceId { get; set; }

        public int VideoCardMemory { get; set; }

        public int Distribution { get; set; }

        public int ClientsRunning { get; set; }

        public int ClientsInstalled { get; set; }

        public int PartialInstalled { get; set; }

        public string Language { get; set; }

        public int ShardIndex { get; set; }

        public Func<Data> GetBuffer => () => NetworkStateHandlers.GetBuffer(this);

        public Action<Data> Send => data => NetworkStateHandlers.Send(this, data);

        public Action<string> Output => text => Console.WriteLine($"[{DateTime.Now:O}] {Identity}.{text}");

    }
}
