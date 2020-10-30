using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;

namespace Launcher.Domain
{
    using Property = Shard.Server.Validation.Handlers<Validation>;
    using NetworkListenerHandlers = Network.Listener.Handlers<ShardState>;
    using NetworkStateHandlers = Network.State.Handlers<Data>;
    using NetworkServerHandlers = Network.Server.Handlers<ShardState, Data>;
    using ShardMessageHandlers = Shard.Message.Handlers<ShardServer, ShardState, Data, Entity, Mobile, City, Item, Skill, Map, Attribute>;
    using ShardExtendedMessageHandlers = Shard.Message.Extended.Handlers<ShardServer, ShardState, Data, Mobile, Map, MapPatch>;
    using ShardServerHandlers = Shard.Server.Handlers<ShardServer,ShardState,Entity,Mobile,Item>;
    using ItemType = Shard.Items.Handlers<ShardServer, Item>;
    using MobileType = Shard.Mobiles.Handlers<ShardServer, Mobile, Item>;

    public class ShardServer :
        Login.Message.Domain.IShard,
        Login.Server.Domain.IShard,
        Login.Message.Domain.Outgoing.IShardServer,
        Thread.Runner.Domain.IThread,
        Network.Listener.Domain.IListener<ShardState>,
        Network.Server.Domain.IServer<ShardState, Data>,
        Shard.Message.Domain.IServer<ShardState, Data, Mobile, City, Item, Skill, Map>,
        Shard.Message.Extended.Domain.IServer<ShardState, Data>,
        Shard.Server.Domain.IServer<ShardServer, ShardState, Entity, Mobile, Item>,
        Shard.Mobiles.Domain.IServer<ShardServer, Item>
    {
        public string Identity
        {
            get => Property.Get<string>(this, nameof(Identity));
            set => Property.Set(this, nameof(Identity), value, () => nameof(ShardServer));
        }

        public string IpAddress
        {
            get => Property.Get<string>(this, nameof(IpAddress));
            set => Property.Set(this, nameof(IpAddress), value, () => "127.0.0.1");
        }

        public int Port
        {
            get => Property.Get<int>(this, nameof(Port));
            set => Property.Set(this, nameof(Port), value, () => 12594);
        }

        public bool Locked { get; set; }

        public bool Running { get; set; }

        public DateTime DateTime { get; set; }

        public Socket Socket { get; set; }

        public EndPoint EndPoint { get; set; }

        public ConcurrentQueue<ShardState> ListenQueue { get; } = new ConcurrentQueue<ShardState>();

        public bool Listening { get; set; }

        public List<ShardState> States { get; } = new List<ShardState>();

        public int Percentage
        {
            get => Property.Get<int>(this, nameof(Percentage));
            set => Property.Set(this, nameof(Percentage), value);
        }

        public int TimeZone
        {
            get => Property.Get<int>(this, nameof(TimeZone));
            set => Property.Set(this, nameof(TimeZone), value);
        }

        public int AuthorizationId
        {
            get => Property.Get<int>(this, nameof(AuthorizationId));
            set => Property.Set(this, nameof(AuthorizationId), value);
        }

        public int CharacterFlags
        {
            get => Property.Get<int>(this, nameof(CharacterFlags));
            set => Property.Set(this, nameof(CharacterFlags), value, () => 1536);
        }

        public byte LightLevel
        {
            get => Property.Get<byte>(this, nameof(LightLevel));
            set => Property.Set(this, nameof(LightLevel), value, () => 12);
        }

        public int FeatureFlags
        {
            get => Property.Get<int>(this, nameof(FeatureFlags));
            set => Property.Set(this, nameof(FeatureFlags), value, () => 0x92DB);
        }

        public List<City> Cities
        {
            get => Property.Get<List<City>>(this, nameof(Cities));
            set => Property.Set(this, nameof(Cities), value, () => new List<City>
            {
                new City {Name = "New Haven", Town = "New Haven Bank"}
            });
        }

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

        public Action<ShardState> EncryptionResponse => state => { };

        public Action<ShardState> AccountLogin => state => ShardServerHandlers.AccountLogin(this, state);

        public Action<ShardState, Mobile> CharacterCreate => (state, mobile) => ShardServerHandlers.CharacterCreate(this, state, mobile);

        public Action<ShardState> MobileQuery => state => ShardServerHandlers.MobileQuery(this, state);

        public Action<ShardState, Data> ExtendedData => (state, data) => ShardExtendedMessageHandlers.Received(this, state, data);

        public Action<ShardState> ChatRequest => state => ShardServerHandlers.ChatRequest(this, state);

        public Action<ShardState> PingRequest => state => ShardServerHandlers.PingRequest(this, state);

        public Action<ShardState> MoveRequest => state => ShardServerHandlers.MoveRequest(this, state);

        public Action<ShardState> ClientType => state => { };

        public Action<ShardState, Mobile> CharacterLogin => (state, mobile) => ShardServerHandlers.CharacterLogin(this, state, mobile);

        public Action<ShardState> AttributesQuery => state => ShardServerHandlers.AttributesQuery(this, state);

        public Action<ShardState> DoubleClick => state => ShardServerHandlers.DoubleClick(this, state);

        public Action<ShardState> RequestProfile => state => ShardServerHandlers.RequestProfile(this, state);

        public Action<ShardState> ClientLanguage => state => ShardServerHandlers.ClientLanguage(this, state);

        public Dictionary<int, Entity> Entities { get; } = new Dictionary<int, Entity>();

        public Stack<int> MobileSerialPool { get; } = new Stack<int>(Enumerable.Range(1, 1000000).Reverse());

        public Stack<int> ItemSerialPool { get; } = new Stack<int>(Enumerable.Range(0x40000001, 1000000).Reverse());

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

        public HashSet<Action<ShardServer, Item>> Containers { get; } = ItemType.Containers();

        public Action<ShardState, Entity> EntityDisplay => ShardMessageHandlers.EntityDisplay;

        public Action<ShardServer, Mobile> Human => MobileType.Human;

        public Action<ShardServer, Item>[] GetItemTypes(Item item) => ShardServerHandlers.GetItemTypes(item);

        public ShardServer()
        {
            Identity = default;
            IpAddress = default;
            Port = default;
            Percentage = default;
            TimeZone = default;
            AuthorizationId = default;
            CharacterFlags = default;
            LightLevel = default;
            FeatureFlags = default;
            Cities = default;
        }

        public Item CreateItem(params Action<ShardServer, Item>[] types) => ShardServerHandlers.CreateItem(this, types);

        public Action<ShardServer, Item> Backpack => ItemType.Backpack;

        public Action<ShardServer, Item> LeatherChest => ItemType.LeatherChest;

        public Action<ShardServer, Item> Robe => ItemType.Robe;

        public Action<ShardServer, Item> Shirt => ItemType.Shirt;

        public Action<ShardServer, Item> ShortPants => ItemType.ShortPants;

        public Action<ShardServer, Item> Shoes => ItemType.Shoes;

        public Action<ShardServer, Item> FirstFace => ItemType.FirstFace;
    }
}