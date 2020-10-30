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
            get => Property.Get<string>(this, nameof(Identity));
            set => Property.Set(this, nameof(Identity), value);
        }

        public string IpAddress
        {
            get => Property.Get<string>(this, nameof(IpAddress));
            set => Property.Set(this, nameof(IpAddress), value);
        }

        public int Port
        {
            get => Property.Get<int>(this, nameof(Port));
            set => Property.Set(this, nameof(Port), value);
        }

        public int Seed
        {
            get => Property.Get<int>(this, nameof(Seed));
            set => Property.Set(this, nameof(Seed), value);
        }

        public int AuthorizationId
        {
            get => Property.Get<int>(this, nameof(AuthorizationId));
            set => Property.Set(this, nameof(AuthorizationId), value);
        }

        public byte[] EncryptionBase
        {
            get => Property.Get<byte[]>(this, nameof(EncryptionBase));
            set => Property.Set(this, nameof(EncryptionBase), value, () => new byte[] {0x02, 0x01, 0x03});
        }

        public byte[] EncryptionPrime
        {
            get => Property.Get<byte[]>(this, nameof(EncryptionPrime));
            set => Property.Set(this, nameof(EncryptionPrime), value,
                () => new byte[]
                {
                    0x02, 0x11, 0x00, 0xF6, 0x19, 0x45, 0xEA, 0x54, 0x89, 0xB0, 0xB6, 0xF6, 0x2E, 0x24, 0xD4, 0x6D,
                    0xE5, 0x12, 0x9B
                });
        }

        public byte[] EncryptionPublicKey
        {
            get => Property.Get<byte[]>(this, nameof(EncryptionPublicKey));
            set => Property.Set(this, nameof(EncryptionPublicKey), value,
                () => new byte[]
                    {0x33, 0x3E, 0xC8, 0x16, 0xE, 0x5, 0xCC, 0xA0, 0x7F, 0x2A, 0x1A, 0x4A, 0x4A, 0x9A, 0xB1, 0x58});
        }

        public int EncryptionKeySize
        {
            get => Property.Get<int>(this, nameof(EncryptionKeySize));
            set => Property.Set(this, nameof(EncryptionKeySize), value, () => 32);
        }

        public byte[] EncryptionIv
        {
            get => Property.Get<byte[]>(this, nameof(EncryptionIv));
            set => Property.Set(this, nameof(EncryptionIv), value,
                () => new byte[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16});
        }

        public byte MoveDirection
        {
            get => Property.Get<byte>(this, nameof(MoveDirection));
            set => Property.Set(this, nameof(MoveDirection), value);
        }

        public byte MoveNumber
        {
            get => Property.Get<byte>(this, nameof(MoveNumber));
            set => Property.Set(this, nameof(MoveNumber), value);
        }

        public int MoveKey
        {
            get => Property.Get<int>(this, nameof(MoveKey));
            set => Property.Set(this, nameof(MoveKey), value);
        }

        public byte PingNumber
        {
            get => Property.Get<byte>(this, nameof(PingNumber));
            set => Property.Set(this, nameof(PingNumber), value);
        }

        public byte Season
        {
            get => Property.Get<byte>(this, nameof(Season));
            set => Property.Set(this, nameof(Season), value, () => 1);
        }

        public byte Sound
        {
            get => Property.Get<byte>(this, nameof(Sound));
            set => Property.Set(this, nameof(Sound), value, () => 1);
        }

        public byte WarMode
        {
            get => Property.Get<byte>(this, nameof(WarMode));
            set => Property.Set(this, nameof(WarMode), value);
        }

        public string Name
        {
            get => Property.Get<string>(this, nameof(Name));
            set => Property.Set(this, nameof(Name), value);
        }

        public string Password
        {
            get => Property.Get<string>(this, nameof(Password));
            set => Property.Set(this, nameof(Password), value);
        }

        public string ChatName
        {
            get => Property.Get<string>(this, nameof(ChatName));
            set => Property.Set(this, nameof(ChatName), value);
        }

        public int PublicKeyLength
        {
            get => Property.Get<int>(this, nameof(PublicKeyLength));
            set => Property.Set(this, nameof(PublicKeyLength), value);
        }

        public byte[] PublicKey
        {
            get => Property.Get<byte[]>(this, nameof(PublicKey));
            set => Property.Set(this, nameof(PublicKey), value);
        }

        public int UnknownMobileQueryFirst
        {
            get => Property.Get<int>(this, nameof(UnknownMobileQueryFirst));
            set => Property.Set(this, nameof(UnknownMobileQueryFirst), value);
        }

        public byte MobileQueryType
        {
            get => Property.Get<byte>(this, nameof(MobileQueryType));
            set => Property.Set(this, nameof(MobileQueryType), value);
        }

        public int MobileQuerySerial
        {
            get => Property.Get<int>(this, nameof(MobileQuerySerial));
            set => Property.Set(this, nameof(MobileQuerySerial), value);
        }

        public byte Number
        {
            get => Property.Get<byte>(this, nameof(Number));
            set => Property.Set(this, nameof(Number), value);
        }

        public string ClientLanguage
        {
            get => Property.Get<string>(this, nameof(ClientLanguage));
            set => Property.Set(this, nameof(ClientLanguage), value);
        }

        public short UnknownClientTypeFirst
        {
            get => Property.Get<short>(this, nameof(UnknownClientTypeFirst));
            set => Property.Set(this, nameof(UnknownClientTypeFirst), value);
        }

        public int ClientType
        {
            get => Property.Get<int>(this, nameof(ClientType));
            set => Property.Set(this, nameof(ClientType), value);
        }

        public List<Mobile> Characters
        {
            get => Property.Get<List<Mobile>>(this, nameof(Characters));
            set => Property.Set(this, nameof(Characters), value, () => new List<Mobile>());
        }

        public Mobile Mobile
        {
            get => Property.Get<Mobile>(this, nameof(Mobile));
            set => Property.Set(this, nameof(Mobile), value);
        }

        public List<int> AttributesQuerySerialList
        {
            get => Property.Get<List<int>>(this, nameof(AttributesQuerySerialList));
            set => Property.Set(this, nameof(AttributesQuerySerialList), value);
        }

        public int DoubleClickSerial
        {
            get => Property.Get<int>(this, nameof(DoubleClickSerial));
            set => Property.Set(this, nameof(DoubleClickSerial), value);
        }

        public byte PaperDollFlags
        {
            get => Property.Get<byte>(this, nameof(PaperDollFlags));
            set => Property.Set(this, nameof(PaperDollFlags), value, () => 0x3);
        }

        public Action<int, Action<Data>, string> ExtendedData => (size, writer, name) =>
            ShardMessageHandlers.ExtendedData(this, size, writer, name);

        public Func<Data, Data> Compress => data => CompressionHandlers.Compress(this, data);

        public Action<Data> Send => data => NetworkStateHandlers.Send(this, data);

        public Func<Data> GetBuffer => () => NetworkStateHandlers.GetBuffer(this);

        public Action<string> Output => text => Console.WriteLine($"[{DateTime.Now:O}] {Identity}.{text}");

        public byte RequestProfileMode
        {
            get => Property.Get<byte>(this, nameof(RequestProfileMode));
            set => Property.Set(this, nameof(RequestProfileMode), value);
        }

        public int RequestProfileSerial
        {
            get => Property.Get<int>(this, nameof(RequestProfileSerial));
            set => Property.Set(this, nameof(RequestProfileSerial), value);
        }

        public short RequestProfileEditType
        {
            get => Property.Get<short>(this, nameof(RequestProfileEditType));
            set => Property.Set(this, nameof(RequestProfileEditType), value);
        }

        public string RequestProfileEditText
        {
            get => Property.Get<string>(this, nameof(RequestProfileEditText));
            set => Property.Set(this, nameof(RequestProfileEditText), value);
        }
    }
}
