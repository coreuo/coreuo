using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;
using System.Net.Sockets;

namespace Launcher.Domain
{
    using NetworkListenerHandlers = Network.Listener.Handlers<ShardState>;
    using NetworkStateHandlers = Network.State.Handlers<Data>;
    using NetworkServerHandlers = Network.Server.Handlers<ShardState, Data>;
    using ShardMessageHandlers = Shard.Message.Handlers<ShardServer, ShardState, Data, Entity, Mobile, City, Item, Skill, Attribute>;
    using ShardExtendedMessageHandlers = Shard.Message.Extended.Handlers<ShardServer, ShardState, Data, Mobile, Map, MapPatch>;
    using ShardServerHandlers = Shard.Server.Handlers<ShardServer,ShardSave,ShardState,Entity,Mobile,Item>;
    using ItemType = Shard.Items.Handlers<ShardServer, Item>;
    using MobileType = Shard.Mobiles.Handlers<ShardServer, Mobile, Item>;

    public class ShardServer :
        Login.Message.Domain.IShard,
        Login.Server.Domain.IShard,
        Login.Message.Domain.Outgoing.IShardServer,
        Thread.Runner.Domain.IThread,
        Network.Listener.Domain.IListener<ShardState>,
        Network.Server.Domain.IServer<ShardState, Data>,
        Shard.Message.Domain.IServer<ShardState, Data, Mobile, City, Item, Skill>,
        Shard.Message.Extended.Domain.IServer<ShardState, Data>,
        Shard.Server.Domain.IServer<ShardServer, ShardSave, ShardState, Entity, Mobile, Item>,
        Shard.Mobiles.Domain.IServer<ShardServer, Item>,
        Shard.Save.Domain.IServer<ShardServer, ShardSave, Property>
    {
        public int Id { get; set; }

        public string Identity
        {
            get => Access.Get(s => s.Identity);
            set => Access.Set(s => s.Identity, value);
        }

        public string IpAddress
        {
            get => Access.Get(s => s.IpAddress);
            set => Access.Set(s => s.IpAddress, value);
        }

        public int Port
        {
            get => Access.Get(s => s.Port);
            set => Access.Set(s => s.Port, value);
        }

        [NotMapped] public bool Locked { get; set; }

        [NotMapped] public bool Running { get; set; }

        [NotMapped] public DateTime DateTime { get; set; }

        [NotMapped] public Socket Socket { get; set; }

        [NotMapped] public EndPoint EndPoint { get; set; }

        [NotMapped] public ConcurrentQueue<ShardState> ListenQueue { get; } = new ConcurrentQueue<ShardState>();

        [NotMapped] public bool Listening { get; set; }

        public List<ShardState> States
        {
            get => Access.Get(s => s.States);
            set => Access.Set(s => s.States, value);
        }

        public int Percentage
        {
            get => Access.Get(s => s.Percentage);
            set => Access.Set(s => s.Percentage, value);
        }

        public int TimeZone
        {
            get => Access.Get(s => s.TimeZone);
            set => Access.Set(s => s.TimeZone, value);
        }

        [NotMapped] public int AuthorizationId { get; set; }

        [NotMapped] public int CharacterFlags { get; set; } = 1536;

        [NotMapped] public byte LightLevel { get; set; } = 12;

        [NotMapped] public int FeatureFlags { get; set; } = 0x92DB;

        [NotMapped] 
        public List<City> Cities { get; set; } = new List<City>
        {
            new City {Name = "New Haven", Town = "New Haven Bank"}
        };

        public Action ThreadStart => () => NetworkListenerHandlers.Start(this);

        public Action ThreadUnlock => () =>
        {
            NetworkListenerHandlers.Stop(this);

            NetworkServerHandlers.Stop(this);
        };

        public Action ThreadSlice => () => NetworkServerHandlers.Slice(this);

        public Action ThreadStop { get; set; } = () => { };

        public Action<ShardState> StateStart => NetworkStateHandlers.Start;

        public Action<ShardState> StateStop => NetworkStateHandlers.Stop;

        public Action<ShardState, Data> DataReceived => (state, data) => ShardMessageHandlers.Received(this, state, data);

        public Action<ShardState> ClientSeed => state => ShardServerHandlers.ClientSeed(this, state);

        public Action<ShardState> EncryptionResponse => _ => { };

        public Action<ShardState> AccountLogin => state => ShardServerHandlers.AccountLogin(this, state);

        public Func<ShardState, Mobile> BeforeCharacterCreate => state => ShardServerHandlers.BeforeCharacterCreate(this, state);

        public Action<ShardState, Mobile> CharacterCreate => (state, mobile) => ShardServerHandlers.CharacterCreate(this, state, mobile);

        public Action<ShardState> MobileQuery => state => ShardServerHandlers.MobileQuery(this, state);

        public Action<ShardState, Data> ExtendedData => (state, data) => ShardExtendedMessageHandlers.Received(this, state, data);

        public Action<ShardState> ChatRequest => state => ShardServerHandlers.ChatRequest(this, state);

        public Action<ShardState> PingRequest => state => ShardServerHandlers.PingRequest(this, state);

        public Action<ShardState> MoveRequest => state => ShardServerHandlers.MoveRequest(this, state);

        public Action<ShardState> ClientType => _ => { };

        public Func<ShardState, int, Mobile> BeforeCharacterLogin => (state, index) => ShardServerHandlers.BeforeCharacterLogin(this, state, index);

        public Action<ShardState, Mobile> CharacterLogin => (state, mobile) => ShardServerHandlers.CharacterLogin(this, state, mobile);

        public Action<ShardState> AttributesQuery => state => ShardServerHandlers.AttributesQuery(this, state);

        public Action<ShardState> DoubleClick => state => ShardServerHandlers.DoubleClick(this, state);

        public Action<ShardState> RequestProfile => state => ShardServerHandlers.RequestProfile(this, state);

        public Action<ShardState> ClientLanguage => state => ShardServerHandlers.ClientLanguage(this, state);

        public HashSet<Entity> Entities
        {
            get => Access.Get(s => s.Entities);
            set => Access.Set(s => s.Entities, value);
        }

        public Queue<int> MobileSerialPool
        {
            get => Access.Get(s => s.MobileSerialPool);
            set => Access.Set(s => s.MobileSerialPool, value);
        }

        [NotMapped] public int MaximumMobileSerial { get; set; }

        public Queue<int> ItemSerialPool
        {
            get => Access.Get(s => s.ItemSerialPool);
            set => Access.Set(s => s.ItemSerialPool, value);
        }

        [NotMapped] public int MaximumItemSerial { get; set; } = 0x40000000;

        public Action<ShardState> EncryptionRequest => ShardMessageHandlers.EncryptionRequest;

        public Action<ShardState> SupportedFeatures => state => ShardMessageHandlers.SupportedFeatures(this, state);

        public Action<ShardState> CharacterList => state => ShardMessageHandlers.CharacterList(this, state);

        public Action<ShardState, Mobile> LoginConfirm => ShardMessageHandlers.LoginConfirm;

        public Action<ShardState, Mobile> MapChange => ShardExtendedMessageHandlers.MapChange;

        public Action<ShardState, Mobile> MapPatches => ShardExtendedMessageHandlers.MapPatch;

        public Action<ShardState> SeasonChange => ShardMessageHandlers.SeasonChange;

        public Action<ShardState, Mobile> MobileUpdate => ShardMessageHandlers.MobileUpdate;

        public Action<ShardState> GlobalLight => state => ShardMessageHandlers.GlobalLight(this, state);

        public Action<ShardState, Mobile> MobileLight => ShardMessageHandlers.MobileLight;

        public Action<ShardState, Mobile> MobileIncoming => ShardMessageHandlers.MobileIncoming;

        public Action<ShardState, Mobile> MobileStatus => ShardMessageHandlers.MobileStatus;

        public Action<ShardState> WarMode => ShardMessageHandlers.WarMode;

        public Action<ShardState> LoginComplete => ShardMessageHandlers.LoginComplete;

        public Action<ShardState> ServerTime => state => ShardMessageHandlers.ServerTime(this, state);

        public Action<ShardState, Mobile> SkillInfo => ShardMessageHandlers.SkillInfo;

        public Action<ShardState> PingResponse => ShardMessageHandlers.PingResponse;

        public Action<ShardState, Mobile> MoveResponse => ShardMessageHandlers.MoveResponse;

        public Action<ShardState> ClientVersionRequest => ShardMessageHandlers.ClientVersionRequest;

        //public Action<ShardState, Mobile> ServerChange => ShardMessageHandlers.ServerChange;

        public Action<ShardState, Entity> AttributeInfo => ShardMessageHandlers.AttributeInfo;

        public Action<ShardState, Entity> AttributeList => ShardMessageHandlers.AttributeList;

        //public Action<ShardState, Mobile> MobileAttributes => ShardMessageHandlers.MobileAttributes;

        public Action<ShardState, Mobile> OpenPaperDoll => ShardMessageHandlers.OpenPaperDoll;

        public Action<ShardState, Mobile> ProfileResponse => ShardMessageHandlers.ProfileResponse;

        public Action<string> Output => text => Console.WriteLine($"[{DateTime.Now:O}] {Identity}.{text}");

        //[NotMapped] public HashSet<Action<ShardServer, Item>> Containers { get; } = ItemType.Containers();

        public Action<ShardState, Entity> EntityDisplay => ShardMessageHandlers.EntityDisplay;

        public Action<ShardState, Entity> EntityContent => ShardMessageHandlers.EntityContent;

        public Action<ShardServer, Mobile> Human => MobileType.Human;

        //public Action<ShardServer, Item>[] GetItemTypes(Item item) => ShardServerHandlers.GetItemTypes(item);

        public Item CreateItem(params Action<ShardServer, Item>[] types) => ShardServerHandlers.CreateItem(this, types);

        public void AddItem(Item parent, Item child) => ShardServerHandlers.AddItem(this, parent, child);

        public Action<ShardServer, Item> Backpack => ItemType.Backpack;

        public Action<ShardServer, Item> LeatherChest => ItemType.LeatherChest;

        public Action<ShardServer, Item> Robe => ItemType.Robe;

        public Action<ShardServer, Item> Shirt => ItemType.Shirt;

        public Action<ShardServer, Item> ShortPants => ItemType.ShortPants;

        public Action<ShardServer, Item> Shoes => ItemType.Shoes;

        public Action<ShardServer, Item> FirstFace => ItemType.FirstFace;

        [NotMapped] public ShardSave Save => Access.Save;

        [NotMapped] public Access<ShardServer> Access { get; set; }

        public ShardServer(ShardSave save)
        {
            Access = save.BaseEntity(this)
                .Property(s => s.Identity, nameof(ShardServer))
                .Property(s => s.IpAddress, "127.0.0.1")
                .Property(s => s.Port, 12594)
                .Property(s => s.States, new List<ShardState>())
                .Property(s => s.Percentage)
                .Property(s => s.TimeZone)
                .Property(s => s.Entities, new HashSet<Entity>())
                .Property(s => s.MobileSerialPool, new Queue<int>())
                .Property(s => s.ItemSerialPool, new Queue<int>())
                .Flush();
        }
    }
}