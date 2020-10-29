using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;

namespace Launcher.Domain
{
    using Property = Shard.Server.Validation.Handlers<Validation>;
    using NetworkStateHandlers = Network.State.Handlers<Data>;
    using CompressionHandlers = Shard.Message.Compression.Handlers<ShardState, Data>;
    using ShardMessageHandlers = Shard.Message.Handlers<ShardServer, ShardState, Data, Entity, Mobile, City, Item, Skill, Map, Attribute>;

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
        public ShardState()
        {
            Identity = default;
            IpAddress = default;
            Port = default;
            Seed = default;
            AuthorizationId = default;
            EncryptionBase = default;
            EncryptionPrime = default;
            EncryptionPublicKey = default;
            EncryptionKeySize = default;
            EncryptionIv = default;
            MoveDirection = default;
            MoveNumber = default;
            MoveKey = default;
            PingNumber = default;
            Season = default;
            Sound = default;
            WarMode = default;
            Name = default;
            Password = default;
            ChatName = default;
            PublicKeyLength = default;
            PublicKey = default;
            UnknownMobileQueryFirst = default;
            MobileQueryType = default;
            MobileQuerySerial = default;
            Number = default;
            ClientLanguage = default;
            UnknownClientTypeFirst = default;
            ClientType = default;
            Characters = default;
            Mobile = default;
            AttributesQuerySerialList = default;
            DoubleClickSerial = default;
            PaperDollFlags = default;
        }

        public bool Locked { get; set; }

        public bool Receiving { get; set; }

        public int Sending { get; set; }

        public DateTime Last { get; set; }

        public Socket Socket { get; set; }

        public EndPoint EndPoint { get; set; }

        public ConcurrentQueue<Data> BufferQueue { get; } = new ConcurrentQueue<Data>();

        public ConcurrentQueue<Data> ReceiveQueue { get; } = new ConcurrentQueue<Data>();

        public string Identity
        {
            get => Property.OnGet<string>(this, nameof(Identity));
            set => Property.OnSet(this, nameof(Identity), value);
        }

        public string IpAddress
        {
            get => Property.OnGet<string>(this, nameof(IpAddress));
            set => Property.OnSet(this, nameof(IpAddress), value);
        }

        public int Port
        {
            get => Property.OnGet<int>(this, nameof(Port));
            set => Property.OnSet(this, nameof(Port), value);
        }

        public int Seed
        {
            get => Property.OnGet<int>(this, nameof(Seed));
            set => Property.OnSet(this, nameof(Seed), value);
        }

        public int AuthorizationId
        {
            get => Property.OnGet<int>(this, nameof(AuthorizationId));
            set => Property.OnSet(this, nameof(AuthorizationId), value);
        }

        public byte[] EncryptionBase
        {
            get => Property.OnGet<byte[]>(this, nameof(EncryptionBase));
            set => Property.OnSet(this, nameof(EncryptionBase), value, () => new byte[] {0x02, 0x01, 0x03});
        }

        public byte[] EncryptionPrime
        {
            get => Property.OnGet<byte[]>(this, nameof(EncryptionPrime));
            set => Property.OnSet(this, nameof(EncryptionPrime), value,
                () => new byte[]
                {
                    0x02, 0x11, 0x00, 0xF6, 0x19, 0x45, 0xEA, 0x54, 0x89, 0xB0, 0xB6, 0xF6, 0x2E, 0x24, 0xD4, 0x6D,
                    0xE5, 0x12, 0x9B
                });
        }

        public byte[] EncryptionPublicKey
        {
            get => Property.OnGet<byte[]>(this, nameof(EncryptionPublicKey));
            set => Property.OnSet(this, nameof(EncryptionPublicKey), value,
                () => new byte[]
                    {0x33, 0x3E, 0xC8, 0x16, 0xE, 0x5, 0xCC, 0xA0, 0x7F, 0x2A, 0x1A, 0x4A, 0x4A, 0x9A, 0xB1, 0x58});
        }

        public int EncryptionKeySize
        {
            get => Property.OnGet<int>(this, nameof(EncryptionKeySize));
            set => Property.OnSet(this, nameof(EncryptionKeySize), value, () => 32);
        }

        public byte[] EncryptionIv
        {
            get => Property.OnGet<byte[]>(this, nameof(EncryptionIv));
            set => Property.OnSet(this, nameof(EncryptionIv), value,
                () => new byte[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16});
        }

        public byte MoveDirection
        {
            get => Property.OnGet<byte>(this, nameof(MoveDirection));
            set => Property.OnSet(this, nameof(MoveDirection), value);
        }

        public byte MoveNumber
        {
            get => Property.OnGet<byte>(this, nameof(MoveNumber));
            set => Property.OnSet(this, nameof(MoveNumber), value);
        }

        public int MoveKey
        {
            get => Property.OnGet<int>(this, nameof(MoveKey));
            set => Property.OnSet(this, nameof(MoveKey), value);
        }

        public byte PingNumber
        {
            get => Property.OnGet<byte>(this, nameof(PingNumber));
            set => Property.OnSet(this, nameof(PingNumber), value);
        }

        public byte Season
        {
            get => Property.OnGet<byte>(this, nameof(Season));
            set => Property.OnSet(this, nameof(Season), value, () => 1);
        }

        public byte Sound
        {
            get => Property.OnGet<byte>(this, nameof(Sound));
            set => Property.OnSet(this, nameof(Sound), value, () => 1);
        }

        public byte WarMode
        {
            get => Property.OnGet<byte>(this, nameof(WarMode));
            set => Property.OnSet(this, nameof(WarMode), value);
        }

        public string Name
        {
            get => Property.OnGet<string>(this, nameof(Name));
            set => Property.OnSet(this, nameof(Name), value);
        }

        public string Password
        {
            get => Property.OnGet<string>(this, nameof(Password));
            set => Property.OnSet(this, nameof(Password), value);
        }

        public string ChatName
        {
            get => Property.OnGet<string>(this, nameof(ChatName));
            set => Property.OnSet(this, nameof(ChatName), value);
        }

        public int PublicKeyLength
        {
            get => Property.OnGet<int>(this, nameof(PublicKeyLength));
            set => Property.OnSet(this, nameof(PublicKeyLength), value);
        }

        public byte[] PublicKey
        {
            get => Property.OnGet<byte[]>(this, nameof(PublicKey));
            set => Property.OnSet(this, nameof(PublicKey), value);
        }

        public int UnknownMobileQueryFirst
        {
            get => Property.OnGet<int>(this, nameof(UnknownMobileQueryFirst));
            set => Property.OnSet(this, nameof(UnknownMobileQueryFirst), value);
        }

        public byte MobileQueryType
        {
            get => Property.OnGet<byte>(this, nameof(MobileQueryType));
            set => Property.OnSet(this, nameof(MobileQueryType), value);
        }

        public int MobileQuerySerial
        {
            get => Property.OnGet<int>(this, nameof(MobileQuerySerial));
            set => Property.OnSet(this, nameof(MobileQuerySerial), value);
        }

        public byte Number
        {
            get => Property.OnGet<byte>(this, nameof(Number));
            set => Property.OnSet(this, nameof(Number), value);
        }

        public string ClientLanguage
        {
            get => Property.OnGet<string>(this, nameof(ClientLanguage));
            set => Property.OnSet(this, nameof(ClientLanguage), value);
        }

        public short UnknownClientTypeFirst
        {
            get => Property.OnGet<short>(this, nameof(UnknownClientTypeFirst));
            set => Property.OnSet(this, nameof(UnknownClientTypeFirst), value);
        }

        public int ClientType
        {
            get => Property.OnGet<int>(this, nameof(ClientType));
            set => Property.OnSet(this, nameof(ClientType), value);
        }

        public List<Mobile> Characters
        {
            get => Property.OnGet<List<Mobile>>(this, nameof(Characters));
            set => Property.OnSet(this, nameof(Characters), value,
                () => new List<Mobile> {new Mobile {Serial = 1, Name = "Generic Player"}});
        }

        public Mobile Mobile
        {
            get => Property.OnGet<Mobile>(this, nameof(Mobile));
            set => Property.OnSet(this, nameof(Mobile), value);
        }

        public List<int> AttributesQuerySerialList
        {
            get => Property.OnGet<List<int>>(this, nameof(AttributesQuerySerialList));
            set => Property.OnSet(this, nameof(AttributesQuerySerialList), value);
        }

        public int DoubleClickSerial
        {
            get => Property.OnGet<int>(this, nameof(DoubleClickSerial));
            set => Property.OnSet(this, nameof(DoubleClickSerial), value);
        }

        public byte PaperDollFlags
        {
            get => Property.OnGet<byte>(this, nameof(PaperDollFlags));
            set => Property.OnSet(this, nameof(PaperDollFlags), value, () => 0x3);
        }

        public Action<int, Action<Data>, string> ExtendedData => (size, writer, name) =>
            ShardMessageHandlers.OnExtendedData(this, size, writer, name);

        public Func<Data, Data> Compress => data => CompressionHandlers.OnCompress(this, data);

        public Action<Data> Send => data => NetworkStateHandlers.OnSend(this, data);

        public Func<Data> GetBuffer => () => NetworkStateHandlers.OnGetBuffer(this);

        public Action<string> Output => text => Console.WriteLine($"[{DateTime.Now:O}] {Identity}.{text}");

        public byte RequestProfileMode
        {
            get => Property.OnGet<byte>(this, nameof(RequestProfileMode));
            set => Property.OnSet(this, nameof(RequestProfileMode), value);
        }

        public int RequestProfileSerial
        {
            get => Property.OnGet<int>(this, nameof(RequestProfileSerial));
            set => Property.OnSet(this, nameof(RequestProfileSerial), value);
        }

        public short RequestProfileEditType
        {
            get => Property.OnGet<short>(this, nameof(RequestProfileEditType));
            set => Property.OnSet(this, nameof(RequestProfileEditType), value);
        }

        public string RequestProfileEditText
        {
            get => Property.OnGet<string>(this, nameof(RequestProfileEditText));
            set => Property.OnSet(this, nameof(RequestProfileEditText), value);
        }
    }
}
