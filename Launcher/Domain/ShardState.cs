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
    using ShardMessageHandlers = Shard.Message.Handlers<ShardServer, ShardState, Data, Entity, Mobile, City, Item, Skill, Attribute, Target>;

    public class ShardState :
        Network.Listener.Domain.ISocket,
        Network.State.Domain.IReceiver<Data>,
        Network.State.Domain.ISender<Data>,
        Network.Server.Domain.IState<Data>,
        Shard.Message.Domain.IState<Data, Mobile, Item, Entity, Attribute, Skill>,
        Shard.Message.Extended.Domain.IState<Data>,
        Shard.Message.Compression.Domain.IState<Data>,
        Shard.Server.Domain.IState<Mobile, Item, Entity, Identity, Target>,
        Shard.Entity.Items.Domain.IState,
        Shard.Mobile.Race.Domain.IState,
        Shard.Entity.Graphic.Domain.IState
    {
        // ReSharper disable once UnusedMember.Global
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
        public ConcurrentQueue<Data> BufferQueue { get; } = new();

        [NotMapped]
        public ConcurrentQueue<Data> ReceiveQueue { get; } = new();

        public string Identity { get; set; }

        public string IpAddress { get; set; }

        public int Port { get; set; }

        public int Seed { get; set; }

        public int AuthorizationId { get; set; }

        [NotMapped] public byte[] EncryptionBase { get; } = {0x02, 0x01, 0x03};

        [NotMapped] public byte[] EncryptionPrime { get; } = {
            0x02, 0x11, 0x00, 0xF6, 0x19, 0x45, 0xEA, 0x54, 0x89, 0xB0, 0xB6, 0xF6, 0x2E, 0x24, 0xD4, 0x6D,
            0xE5, 0x12, 0x9B
        };

        [NotMapped] public byte[] EncryptionPublicKey { get; } = {0x33, 0x3E, 0xC8, 0x16, 0xE, 0x5, 0xCC, 0xA0, 0x7F, 0x2A, 0x1A, 0x4A, 0x4A, 0x9A, 0xB1, 0x58};

        [NotMapped] public int EncryptionKeySize { get; } = 32;

        [NotMapped] public byte[] EncryptionIv { get; } = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16};

        public byte Direction { get; set; }

        public byte Number { get; set; }

        public int MoveKey { get; set; }

        public byte Season { get; } = 1;

        public byte Sound { get; } = 1;

        public byte WarMode { get; set; }

        public string Name { get; set; }

        [NotMapped] public string Password { get; set; }

        [NotMapped] public byte Profession { get; set; }

        [NotMapped] public byte Gender { get; set; }

        [NotMapped] public ushort Hue { get; set; }

        [NotMapped] public int UnknownCharacterCreationFirst { get; set; }

        [NotMapped] public int UnknownCharacterCreationSecond { get; set; }

        [NotMapped] public byte SkillFirst { get; set; }

        [NotMapped] public byte SkillFirstValue { get; set; }

        [NotMapped] public byte SkillSecond { get; set; }

        [NotMapped] public byte SkillSecondValue { get; set; }

        [NotMapped] public byte SkillThird { get; set; }

        [NotMapped] public byte SkillThirdValue { get; set; }

        [NotMapped] public byte SkillFourth { get; set; }

        [NotMapped] public byte SkillFourthValue { get; set; }

        [NotMapped] public byte[] UnknownCharacterCreationThird { get; set; }

        [NotMapped] public byte UnknownCharacterCreationFourth { get; set; }

        [NotMapped] public ushort HairHue { get; set; }

        [NotMapped] public ushort HairGraphic { get; set; }

        [NotMapped] public byte UnknownCharacterCreationFifth { get; set; }

        [NotMapped] public int UnknownCharacterCreationSixth { get; set; }

        [NotMapped] public byte UnknownCharacterCreationSeventh { get; set; }

        [NotMapped] public short ShirtColor { get; set; }

        [NotMapped] public short ShirtStyle { get; set; }

        [NotMapped] public byte UnknownCharacterCreationEighth { get; set; }

        [NotMapped] public ushort FaceHue { get; set; }

        [NotMapped] public ushort FaceGraphic { get; set; }

        [NotMapped] public byte UnknownCharacterCreationNinth { get; set; }

        [NotMapped] public ushort BeardGraphic { get; set; }

        [NotMapped] public ushort BeardHue { get; set; }

        [NotMapped] public string ChatName { get; set; }

        [NotMapped] public int PublicKeyLength { get; set; }

        [NotMapped] public byte[] PublicKey { get; set; }

        [NotMapped] public int UnknownMobileQueryFirst { get; set; }

        public byte MobileQueryType { get; set; }

        public int Serial { get; set; }

        public string ClientLanguage { get; set; }

        [NotMapped] public short UnknownClientTypeFirst { get; set; }

        public int ClientType { get; set; }

        [NotMapped] public List<Mobile> Characters { get; set; } = new();

        public Mobile Mobile { get; set; }

        [NotMapped] public List<int> SerialList { get; set; } = new();

        [NotMapped] public byte PaperDollFlags { get; } = 0x3;

        public Action<int, Action<Data>, string> ExtendedData => (size, writer, name) => ShardMessageHandlers.ExtendedData(this, size, writer, name);

        public Func<Data, Data> Compress => data => CompressionHandlers.Compress(this, data);

        public Action<Data> Send => data => NetworkStateHandlers.Send(this, data);

        public Func<Data> GetBuffer => () => NetworkStateHandlers.GetBuffer(this);

        public Action<string> Output => text => Console.WriteLine($"[{DateTime.Now:O}] {Identity}.{text}");

        public byte ProfileRequestMode { get; set; }

        public short ProfileRequestEditType { get; set; }

        public string ProfileRequestEditText { get; set; }

        public ushort Amount { get; set; }

        public byte SoundMode { get; } = 1;

        public ushort SoundId { get; set; }

        public ushort SoundVolume { get; } = 0;

        public ushort LocationX { get; set; }

        public ushort LocationY { get; set; }

        public sbyte LocationZ { get; set; }

        public byte GridIndex { get; set; }

        public int ParentSerial { get; set; }

        public byte Layer { get; set; }

        public byte SpeechType { get; set; }

        public ushort SpeechFont { get; set; }

        public string SpeechLanguage { get; set; }

        public string SpeechText { get; set; }

        public ushort SpeechGraphics { get; } = 0;

        public List<int> KeyWords { get; set; }

        public int TargetId { get; set; }

        public byte TargetMode { get; set; }

        public byte TargetType { get; set; }

        public ushort Graphic { get; set; }

        [NotMapped] public int Pattern { get; set; }

        [NotMapped] public int Slot { get; set; }

        [NotMapped] public int ClientFlags { get; set; }

        [NotMapped] public byte Race { get; set; }

        [NotMapped] public short Strength { get; set; }

        [NotMapped] public short Dexterity { get; set; }

        [NotMapped] public short Intelligence { get; set; }

        [NotMapped] public short FirstLoginCharacterUnknown { get; set; }

        [NotMapped] public int SecondLoginCharacterUnknown { get; set; }

        public int LoginCount { get; set; }

        [NotMapped] public byte[] ThirdLoginCharacterUnknown { get; set; }

        public int ClientIpAddress { get; set; }
    }
}
