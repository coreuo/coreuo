using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;

namespace Launcher.Domain
{
    using NetworkListenerHandlers = Network.Listener.Handlers<ShardState>;
    using NetworkStateHandlers = Network.State.Handlers<Data>;
    using NetworkServerHandlers = Network.Server.Handlers<ShardState, Data>;
    using ShardMessageHandlers = Shard.Message.Handlers<ShardServer, ShardState, Data, Entity, Mobile, City, Item, Skill, Map, Property>;
    using ShardExtendedMessageHandler = Shard.Message.Extended.Handlers<ShardServer, ShardState, Data, Mobile, Map, MapPatch>;
    using ShardServerHandlers = Shard.Server.Handlers<ShardServer,ShardState,Entity,Mobile>;

    public class ShardServer :
        Login.Message.Domain.IShard,
        Login.Server.Domain.IShard,
        Login.Message.Domain.Outgoing.IShardServer,
        Thread.Runner.Domain.IThread,
        Network.Listener.Domain.IListener<ShardState>,
        Network.Server.Domain.IServer<ShardState, Data>,
        Shard.Message.Domain.IServer<ShardState, Data, Mobile, City, Item, Skill, Map>,
        Shard.Message.Extended.Domain.IServer<ShardState, Data>,
        Shard.Server.Domain.IServer<ShardState, Entity, Mobile>
    {
        public string Identity { get; set; } = nameof(ShardServer);

        public string IpAddress { get; set; } = "127.0.0.1";

        public int Port { get; set; } = 12594;

        public bool Locked { get; set; }

        public bool Running { get; set; }

        public DateTime DateTime { get; set; }

        public Socket Socket { get; set; }

        public EndPoint EndPoint { get; set; }

        public ConcurrentQueue<ShardState> ListenQueue { get; } = new ConcurrentQueue<ShardState>();

        public bool Listening { get; set; }

        public List<ShardState> States { get; } = new List<ShardState>();

        public int Percentage { get; set; }

        public int TimeZone { get; set; }

        public int AuthorizationId { get; set; }

        public int CharacterFlags { get; } = 1536;

        public byte LightLevel { get; } = 12;

        public int FeatureFlags { get; set; } = 0x92DB;

        public List<City> Cities { get; } = new List<City>
        {
            new City {Name = "New Haven", Town = "New Haven Bank"}
        };

        public Action ThreadStart => () => NetworkListenerHandlers.OnStart(this);

        public Action ThreadUnlock => () =>
        {
            NetworkListenerHandlers.OnStop(this);

            NetworkServerHandlers.OnStop(this);
        };

        public Action ThreadSlice => () => NetworkServerHandlers.OnSlice(this);

        public Action ThreadStop { get; set; } = () => { };

        public Action<ShardState> StateStart => NetworkStateHandlers.OnStart;

        public Action<ShardState> StateStop => NetworkStateHandlers.OnStop;

        public Action<ShardState, Data> DataReceived => (state, data) => ShardMessageHandlers.OnReceived(this, state, data);

        public Action<ShardState> ClientSeed => state => ShardServerHandlers.OnClientSeed(this, state);

        public Action<ShardState> EncryptionResponse => state => { };

        public Action<ShardState> AccountLogin => state => ShardServerHandlers.OnAccountLogin(this, state);

        public Action<ShardState, Mobile> CharacterCreate => (state, mobile) => ShardServerHandlers.OnCharacterCreate(this, state, mobile);

        public Action<ShardState> MobileQuery => state => ShardServerHandlers.OnMobileQuery(this, state);

        public Action<ShardState, Data> ExtendedData => (state, data) => ShardExtendedMessageHandler.OnReceived(this, state, data);

        public Action<ShardState> ChatRequest => state => ShardServerHandlers.OnChatRequest(this, state);

        public Action<ShardState> PingRequest => state => ShardServerHandlers.OnPingRequest(this, state);

        public Action<ShardState> MoveRequest => state => ShardServerHandlers.OnMoveRequest(this, state);

        public Action<ShardState> ClientType => state => { };

        public Action<ShardState, Mobile> CharacterLogin => (state, mobile) => ShardServerHandlers.OnCharacterLogin(this, state, mobile);

        public Action<ShardState> PropertiesQuery => state => ShardServerHandlers.OnPropertiesQuery(this, state);

        public Action<ShardState> ClientLanguage => state => ShardServerHandlers.OnClientLanguage(this, state);

        public Dictionary<int, Entity> Entities { get; } = new Dictionary<int, Entity>();

        public Action<ShardState> EncryptionRequest => ShardMessageHandlers.OnEncryptionRequest;

        public Action<ShardState> SupportedFeatures => state => ShardMessageHandlers.OnSupportedFeatures(this, state);

        public Action<ShardState> CharacterList => state => ShardMessageHandlers.OnCharacterList(this, state);

        public Action<ShardState, Mobile> LoginConfirm => ShardMessageHandlers.OnLoginConfirm;

        public Action<ShardState, Mobile> MapChange => ShardExtendedMessageHandler.OnMapChange;

        public Action<ShardState, Mobile> MapPatches => ShardExtendedMessageHandler.OnMapPatch;

        public Action<ShardState> SeasonChange => ShardMessageHandlers.OnSeasonChange;

        public Action<ShardState, Mobile> MobileUpdate => ShardMessageHandlers.OnMobileUpdate;

        public Action<ShardState> GlobalLight => state => ShardMessageHandlers.OnGlobalLight(this, state);

        public Action<ShardState, Mobile> MobileLight => ShardMessageHandlers.OnMobileLight;

        public Action<ShardState, Mobile> MobileIncoming => ShardMessageHandlers.OnMobileIncoming;

        public Action<ShardState, Mobile> MobileStatus => ShardMessageHandlers.OnMobileStatus;

        public Action<ShardState> WarMode => ShardMessageHandlers.OnWarMode;

        public Action<ShardState> LoginComplete => ShardMessageHandlers.OnLoginComplete;

        public Action<ShardState> ServerTime => state => ShardMessageHandlers.OnServerTime(this, state);

        public Action<ShardState, Mobile> SkillInfo => ShardMessageHandlers.OnSkillInfo;

        public Action<ShardState> PingResponse => ShardMessageHandlers.OnPingResponse;

        public Action<ShardState, Mobile> MoveResponse => ShardMessageHandlers.OnMoveResponse;

        public Action<ShardState> ClientVersionRequest => ShardMessageHandlers.OnClientVersionRequest;

        public Action<ShardState, Mobile> ServerChange => ShardMessageHandlers.OnServerChange;

        public Action<ShardState, Entity> PropertyInfo => ShardMessageHandlers.OnPropertyInfo;

        public Action<ShardState, Entity> PropertyList => ShardMessageHandlers.OnPropertyList;

        public Action<ShardState, Mobile> MobileAttributes => ShardMessageHandlers.OnMobileAttributes;

        public Action<string> Output => text => Console.WriteLine($"[{DateTime.Now:O}] {Identity}.{text}");
    }
}