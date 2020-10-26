using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;

namespace Launcher.Domain
{
    using NetworkStateHandlers = Network.State.Handlers<Data>;
    using CompressionHandlers = Shard.Message.Compression.Handlers<ShardState, Data>;
    using ShardMessageHandlers = Shard.Message.Handlers<ShardServer, ShardState, Data, Entity, Mobile, City, Item, Skill, Map, Property>;

    public class ShardState :
        Network.Listener.Domain.ISocket,
        Network.State.Domain.IReceiver<Data>,
        Network.State.Domain.ISender<Data>,
        Network.Server.Domain.IState<Data>,
        Shard.Message.Domain.IState<Data, Mobile, Item, Skill, Map>,
        Shard.Message.Extended.Domain.IState<Data>,
        Shard.Message.Compression.Domain.IState<Data>,
        Shard.Server.Domain.IState<Mobile>
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

        public int AuthorizationId { get; set; }

        public byte[] EncryptionBase { get; } = {0x02, 0x01, 0x03};

        public byte[] EncryptionPrime { get; } = {0x02, 0x11, 0x00, 0xF6, 0x19, 0x45, 0xEA, 0x54, 0x89, 0xB0, 0xB6, 0xF6, 0x2E, 0x24, 0xD4, 0x6D, 0xE5, 0x12, 0x9B};

        public byte[] EncryptionPublicKey { get; } = {0x33, 0x3E, 0xC8, 0x16, 0xE, 0x5, 0xCC, 0xA0, 0x7F, 0x2A, 0x1A, 0x4A, 0x4A, 0x9A, 0xB1, 0x58};

        public int EncryptionKeySize { get; } = 32;

        public byte[] EncryptionIv { get; } = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16};

        public byte MoveDirection { get; set; }

        public byte MoveNumber { get; set; }

        public int MoveKey { get; set; }

        public byte PingNumber { get; set; }

        public byte Season { get; set; } = 1;

        public byte Sound { get; set; } = 1;

        public byte WarMode { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public string ChatName { get; set; }

        public int PublicKeyLength { get; set; }

        public byte[] PublicKey { get; set; }

        public int UnknownMobileQueryFirst { get; set; }

        public byte MobileQueryType { get; set; }

        public int MobileQuerySerial { get; set; }

        public byte Number { get; set; }

        public string ClientLanguage { get; set; }

        public short UnknownClientTypeFirst { get; set; }

        public int ClientType { get; set; }

        public List<Mobile> Characters { get; } = new List<Mobile> {new Mobile {Serial = 1, Name = "Generic Player"}};

        public Mobile Mobile { get; set; }

        public Action<int, Action<Data>, string> ExtendedData => (size, writer, name) => ShardMessageHandlers.OnExtendedData(this, size, writer, name);

        public Func<Data, Data> Compress => data => CompressionHandlers.OnCompress(this, data);

        public Action<Data> Send => data => NetworkStateHandlers.OnSend(this, data);

        public Func<Data> GetBuffer => () => NetworkStateHandlers.OnGetBuffer(this);

        public Action<string> Output => text => Console.WriteLine($"[{DateTime.Now:O}] {Identity}.{text}");

        public List<int> PropertiesQuerySerialList { get; set; }
    }
}
