using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;
using System.Net.Sockets;

namespace Launcher.Domain
{
    using NetworkStateHandlers = Network.State.Handlers<Data>;
    using CompressionHandlers = Shard.Message.Compression.Handlers<ShardState, Data>;
    using ShardMessageHandlers = Shard.Message.Handlers<ShardServer, ShardState, Data, Entity, Mobile, City, Item, Skill, Attribute>;

    public class ShardState :
        Network.Listener.Domain.ISocket,
        Network.State.Domain.IReceiver<Data>,
        Network.State.Domain.ISender<Data>,
        Network.Server.Domain.IState<Data>,
        Shard.Message.Domain.IState<Data, Mobile, Item, Skill>,
        Shard.Message.Extended.Domain.IState<Data>,
        Shard.Message.Compression.Domain.IState<Data>,
        Shard.Server.Domain.IState<Mobile, Item>
    {
        public int Id { get; set; }

        [NotMapped]
        public bool Locked { get; set; }

        [NotMapped]
        public bool Receiving { get; set; }

        [NotMapped]
        public int Sending { get; set; }

        [NotMapped]
        public DateTime Last { get; set; }

        [NotMapped]
        public Socket Socket { get; set; }

        [NotMapped]
        public EndPoint EndPoint { get; set; }

        [NotMapped]
        public ConcurrentQueue<Data> BufferQueue { get; } = new ConcurrentQueue<Data>();

        [NotMapped]
        public ConcurrentQueue<Data> ReceiveQueue { get; } = new ConcurrentQueue<Data>();

        public string Identity { get; set; }

        public string IpAddress { get; set; }

        public int Port { get; set; }

        public int Seed { get; set; }

        public int AuthorizationId { get; set; }

        [NotMapped] public byte[] EncryptionBase { get; set; } = {0x02, 0x01, 0x03};

        [NotMapped] public byte[] EncryptionPrime { get; set; } = {
            0x02, 0x11, 0x00, 0xF6, 0x19, 0x45, 0xEA, 0x54, 0x89, 0xB0, 0xB6, 0xF6, 0x2E, 0x24, 0xD4, 0x6D,
            0xE5, 0x12, 0x9B
        };

        [NotMapped] public byte[] EncryptionPublicKey { get; set; } = {0x33, 0x3E, 0xC8, 0x16, 0xE, 0x5, 0xCC, 0xA0, 0x7F, 0x2A, 0x1A, 0x4A, 0x4A, 0x9A, 0xB1, 0x58};

        [NotMapped] public int EncryptionKeySize { get; set; } = 32;

        [NotMapped] public byte[] EncryptionIv { get; set; } = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16};

        public byte MoveDirection { get; set; }

        public byte MoveNumber { get; set; }

        public int MoveKey { get; set; }

        public byte PingNumber { get; set; }

        public byte Season { get; set; } = 1;

        public byte Sound { get; set; } = 1;

        public byte WarMode { get; set; }

        public string Name { get; set; }

        [NotMapped] public string Password { get; set; }

        public string ChatName { get; set; }

        [NotMapped] public int PublicKeyLength { get; set; }

        [NotMapped] public byte[] PublicKey { get; set; }

        [NotMapped] public int UnknownMobileQueryFirst { get; set; }

        public byte MobileQueryType { get; set; }

        public int MobileQuerySerial { get; set; }

        public byte Number { get; set; }

        public string ClientLanguage { get; set; }

        [NotMapped] public short UnknownClientTypeFirst { get; set; }

        public int ClientType { get; set; }

        [NotMapped] public List<Mobile> Characters { get; set; } = new List<Mobile>();

        public Mobile Mobile { get; set; }

        [NotMapped] public List<int> AttributesQuerySerialList { get; set; } = new List<int>();

        public int DoubleClickSerial { get; set; }

        [NotMapped] public byte PaperDollFlags { get; set; } = 0x3;

        public Action<int, Action<Data>, string> ExtendedData => (size, writer, name) => ShardMessageHandlers.ExtendedData(this, size, writer, name);

        public Func<Data, Data> Compress => data => CompressionHandlers.Compress(this, data);

        public Action<Data> Send => data => NetworkStateHandlers.Send(this, data);

        public Func<Data> GetBuffer => () => NetworkStateHandlers.GetBuffer(this);

        public Action<string> Output => text => Console.WriteLine($"[{DateTime.Now:O}] {Identity}.{text}");

        public byte RequestProfileMode { get; set; }

        public int RequestProfileSerial { get; set; }

        public short RequestProfileEditType { get; set; }

        public string RequestProfileEditText { get; set; }
    }
}
