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
    using ShardMessageHandlers = Shard.Message.Handlers<ShardServer, ShardState, Data, Entity, Mobile, City, Item, Skill, Attribute, Target>;
    using ShardExtendedMessageHandlers = Shard.Message.Extended.Handlers<ShardServer, ShardState, Data, Mobile, Map, MapPatch>;
    using ShardServerHandlers = Shard.Server.Handlers<ShardServer,ShardState,Mobile,Item, Entity, Identity, Target>;
    using GameDataHandlers = Game.Data.Handlers<ShardServer, Item, Entity, TileArt, CsvDocument>;
    using ShardEntityGraphicHandlers = Shard.Entity.Graphic.Handlers<ShardServer, Entity, Identity>;
    using ShardEntityIdentityHandlers = Shard.Entity.Identity.Handlers<ShardServer, Entity, Identity>;
    using ShardEntityItemsHandlers = Shard.Entity.Items.Handlers<ShardServer, ShardState, Mobile, Item, Entity, Identity>;
    using ShardMobileRaceHandlers = Shard.Mobile.Race.Handlers<ShardServer, ShardState, Mobile, Item, Entity, Identity>;

    public class ShardServer :
        Login.Message.Domain.IShard,
        Login.Server.Domain.IShard,
        Login.Message.Domain.Outgoing.IShardServer,
        Thread.Runner.Domain.IThread,
        Network.Listener.Domain.IListener<ShardState>,
        Network.Server.Domain.IServer<ShardState, Data>,
        Shard.Message.Domain.IServer<ShardState, Data, Mobile, City, Item, Entity, Attribute, Skill>,
        Shard.Message.Extended.Domain.IServer<ShardState, Data>,
        Shard.Server.Domain.IServer<ShardServer, ShardState, Mobile, Item, Entity, Identity, Target>,
        Game.Data.Domain.ISettings<TileArt, CsvDocument>,
        Shard.Entity.Items.Domain.IServer<ShardState, Mobile, Item, Entity, Identity>,
        Shard.Mobile.Race.Domain.IServer<ShardState, Item, Entity, Identity>,
        Shard.Entity.Identity.Domain.IServer<Entity, Identity>,
        Shard.Entity.Graphic.Domain.IServer<Identity>
    {
        // ReSharper disable once UnusedMember.Global
        public int Id { get; set; }

        public Random Random { get; } = new();

        public Action<ShardState> StatusClose => _ => { };

        public string Identity { get; set; } = nameof(ShardServer);

        public string IpAddress { get; set; } = "127.0.0.1";

        public int Port { get; set; } = 12594;

        public string GamePath { get; } = "C:\\Program Files (x86)\\EA Games\\Ultima Online Kingdom Reborn";

        [NotMapped] public bool Locked { get; set; }

        [NotMapped] public bool Running { get; set; }

        [NotMapped] public DateTime DateTime { get; set; }

        [NotMapped] public Socket Socket { get; set; }

        [NotMapped] public EndPoint EndPoint { get; set; }

        [NotMapped] public ConcurrentQueue<ShardState> ListenQueue { get; } = new();

        [NotMapped] public bool Listening { get; set; }

        public List<ShardState> States { get; } = new();

        public int Percentage { get; } = 0;

        public int TimeZone { get; } = 0;

        [NotMapped] public int AuthorizationId { get; set; }

        [NotMapped] public int CharacterFlags { get; } = 1536;

        [NotMapped] public byte LightLevel { get; } = 12;

        [NotMapped] public int FeatureFlags { get; } = 0x92DB;

        [NotMapped]
        public List<City> Cities { get; } = new()
        {
            new City {Name = "New Haven", Town = "New Haven Bank"}
        };

        public Action ThreadStart => () =>
        {
            ShardEntityIdentityHandlers.LoadIdentities(this);

            ShardEntityGraphicHandlers.LoadGraphicRanges(this);

            ShardEntityGraphicHandlers.LoadHueRanges(this);

            ShardEntityGraphicHandlers.LoadContainers(this);

            GameDataHandlers.Load(this);

            NetworkListenerHandlers.Start(this);
        };

        public Action ThreadUnlock => () =>
        {
            TileArts.Clear();

            NetworkListenerHandlers.Stop(this);

            NetworkServerHandlers.Stop(this);
        };

        public Action ThreadSlice => () => NetworkServerHandlers.Slice(this);

        public Action ThreadStop { get; set; } = () => { };

        public Action<ShardState> StateStart => NetworkStateHandlers.Start;

        public Action<ShardState> StateStop => NetworkStateHandlers.Stop;

        public Action<ShardState, Data> DataReceived =>
            (state, data) => ShardMessageHandlers.Received(this, state, data);

        public Action<ShardState> ClientSeed => state => ShardServerHandlers.ClientSeed(this, state);

        public Action<ShardState> EncryptionResponse => _ => { };

        public Action<ShardState> AccountLogin => state => ShardServerHandlers.AccountLogin(this, state);

        public Action<ShardState> CharacterCreate => state => ShardServerHandlers.CharacterCreate(this, state);

        public Action<ShardState> MobileQuery => state => ShardServerHandlers.MobileQuery(this, state);

        public Action<ShardState, Data> ExtendedData =>
            (state, data) => ShardExtendedMessageHandlers.Received(this, state, data);

        public Action<ShardState> ChatRequest => _/*state*/ => { };//ShardServerHandlers.ChatRequest(this, state);

        public Action<ShardState> PingRequest => state => ShardServerHandlers.PingRequest(this, state);

        public Action<ShardState> MoveRequest => state => ShardServerHandlers.MoveRequest(this, state);

        public Action<ShardState> ClientType => _ => { };

        public Action<ShardState> CharacterLogin => state => ShardServerHandlers.CharacterLogin(this, state);

        public Action<ShardState> EntityQuery => state => ShardServerHandlers.EntityQuery(this, state);

        public Action<ShardState> EntityUse => state => ShardServerHandlers.EntityUse(this, state);

        public Action<ShardState> ProfileRequest => state => ShardServerHandlers.ProfileRequest(this, state);

        public Action<ShardState> ItemPick => state => ShardServerHandlers.ItemPick(this, state);

        public Action<ShardState> ItemPlace => state => ShardServerHandlers.ItemPlace(this, state);

        public Action<ShardState> ItemWear => state => ShardServerHandlers.ItemWear(this, state);

        public Action<ShardState> WarModeRequest => state => ShardServerHandlers.WarModeRequest(this, state);

        public Action<ShardState> SpeechRequest => state => ShardServerHandlers.SpeechRequest(this, state);

        public Action<ShardState> TargetResponse => _/*state*/ => { };//ShardServerHandlers.TargetResponse(this, state);

        public Action<ShardState> ClientLanguage => _/*state*/ => { };//ShardServerHandlers.ClientLanguage(this, state);

        public HashSet<Entity> Entities { get; } = new();

        public Queue<int> MobileSerialPool { get; } = new();

        [NotMapped] public int MaximumMobileSerial { get; set; }

        public Queue<int> ItemSerialPool { get; } = new();

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

        public Action<ShardState, Mobile> WarModeResponse => ShardMessageHandlers.WarModeResponse;

        public Action<ShardState> LoginComplete => ShardMessageHandlers.LoginComplete;

        public Action<ShardState> ServerTime => state => ShardMessageHandlers.ServerTime(this, state);

        public Action<ShardState, Mobile> SkillInfo => ShardMessageHandlers.SkillInfo;

        public Action<ShardState> PingResponse => ShardMessageHandlers.PingResponse;

        public Action<ShardState, Mobile> MoveResponse => ShardMessageHandlers.MoveResponse;

        public Action<ShardState> ClientVersionRequest => ShardMessageHandlers.ClientVersionRequest;

        //public Action<ShardState, Mobile> ServerChange => ShardMessageHandlers.ServerChange;

        public Action<ShardState, Entity> EntityInfo => ShardMessageHandlers.EntityInfo;

        public Action<ShardState, Entity> EntityAttributes => ShardMessageHandlers.EntityAttributes;

        //public Action<ShardState, Mobile> MobileAttributes => ShardMessageHandlers.MobileAttributes;

        public Action<ShardState, Mobile> PaperDollOpen => ShardMessageHandlers.PaperDollOpen;

        public Action<ShardState, Mobile> ProfileResponse => ShardMessageHandlers.ProfileResponse;

        public Action<string> Output => text => Console.WriteLine($"[{DateTime.Now:O}] {Identity}.{text}");

        public Action<ShardState, Entity> EntityDisplay => ShardMessageHandlers.EntityDisplay;

        public Action<ShardState, Entity> EntityContent => ShardMessageHandlers.EntityContent;

        public Action<ShardState, Entity> EntityRemove => ShardMessageHandlers.EntityRemove;

        public Item CreateItem(params Identity[] identities) => ShardServerHandlers.CreateItem(this, identities);

        public Item CreateItem(ShardState state, params Identity[] identities) => ShardServerHandlers.CreateItem(this, state, identities);

        public void SetItemParent(Entity parent, Item item) => ShardServerHandlers.SetItemParent(this, parent, item);

        public Action<ShardState, Mobile> AssignFace => (state, mobile) => ShardMobileRaceHandlers.AssignFace(this, state, mobile);

        public Action<ShardState, Mobile> AssignHair => (state, mobile) => ShardMobileRaceHandlers.AssignHair(this, state, mobile);

        public Action<ShardState, Mobile> AssignBeard => (state, mobile) => ShardMobileRaceHandlers.AssignBeard(this, state, mobile);

        public Action<Item> RemoveItemParent => ShardServerHandlers.RemoveItemParent;

        public Action<ShardState, Item> ItemWorld => ShardMessageHandlers.ItemWorld;

        public Action<ShardState, Item> ItemWearUpdate => ShardMessageHandlers.ItemWearUpdate;

        public Action<ShardState, Mobile> MobileMoving => ShardMessageHandlers.MobileMoving;

        public Action<ShardState, Mobile> SpeechResponse => ShardMessageHandlers.SpeechResponse;

        public Action<ShardState> TargetRequest => ShardMessageHandlers.TargetRequest;

        public Action<Entity, string> AssignName => (entity, name) => GameDataHandlers.AssignName(this, entity, name);

        public Action<Entity, ushort?> AssignGraphic => (entity, graphic) => ShardEntityGraphicHandlers.AssignGraphic(this, entity, graphic);

        public Action<Entity, ushort?> AssignHue => (entity, hue) => ShardEntityGraphicHandlers.AssignHue(this, entity, hue);

        public Action<ShardState, Mobile> AssignMobileItems => (state, mobile) => ShardEntityItemsHandlers.AssignMobileItems(this, state, mobile);

        public Action<ShardState, HashSet<Identity>> AssignRace => (state, identities) => ShardMobileRaceHandlers.AssignRace(this, state, identities);

        public Action<ShardState, HashSet<Identity>> AssignGender => (state, identities) => ShardMobileRaceHandlers.AssignGender(this, state, identities);

        public Action<Mobile> UpdateRace => mobile => ShardMobileRaceHandlers.UpdateRace(this, mobile);

        public Action<Mobile> UpdateGender => mobile =>  ShardMobileRaceHandlers.UpdateGender(this, mobile);

        public Action<Item> AssignLayer => item => GameDataHandlers.AssignLayer(this, item);

        public Action<Item> AssignDisplayIndex => item => ShardEntityGraphicHandlers.AssignDisplayIndex(this, item);

        public Action<Item> AssignDisplay => item => GameDataHandlers.AssignDisplay(this, item);

        public Action<HashSet<Identity>> AssignIdentities => identities => ShardEntityIdentityHandlers.AssignIdentities(this, identities);

        public Action<ShardState, Target> SoundPlay => ShardMessageHandlers.SoundPlay;

        public Action<ShardState> ItemPlaceApproved => ShardMessageHandlers.ItemPlaceApproved;

        public Action<ShardState, Item> EntityContentItem => ShardMessageHandlers.EntityContentItem;

        public List<string> StringData { get; } = new();

        public Dictionary<ushort, TileArt> TileArts { get; } = new();

        public Dictionary<ulong, CsvDocument> CsvDocuments { get; } = new();

        public void AddHumanHues(Range range) => ShardEntityGraphicHandlers.AddHumanHues(this, range);

        public void AddElfHues(ushort[] values) => ShardEntityGraphicHandlers.AddElfHues(this, values);

        public void AddHumanoidFaceGraphics(IEnumerable<ushort> values) => ShardEntityGraphicHandlers.AddHumanoidFaceGraphics(this, values);

        public void AddHumanMaleHairGraphics(IEnumerable<ushort> values) => ShardEntityGraphicHandlers.AddHumanMaleHairGraphics(this, values);

        public void AddElfMaleHairGraphics(IEnumerable<ushort> values) => ShardEntityGraphicHandlers.AddElfMaleHairGraphics(this, values);

        public void AddHumanFemaleHairGraphics(IEnumerable<ushort> values) => ShardEntityGraphicHandlers.AddHumanFemaleHairGraphics(this, values);

        public void AddElfFemaleHairGraphics(IEnumerable<ushort> values) => ShardEntityGraphicHandlers.AddElfFemaleHairGraphics(this, values);

        public void AddHumanHairHues(Range range) => ShardEntityGraphicHandlers.AddHumanHairHues(this, range);

        public void AddElfHairHues(IEnumerable<ushort> values) => ShardEntityGraphicHandlers.AddElfHairHues(this, values);

        public void AddHumanMaleBeardGraphics(IEnumerable<ushort> values) => ShardEntityGraphicHandlers.AddHumanMaleBeardGraphics(this, values);

        public void AddHumanBeardHues(Range range) => ShardEntityGraphicHandlers.AddHumanBeardHues(this, range);

        public void AddDyeHues(Range range) => ShardEntityGraphicHandlers.AddDyeHues(this, range);

        public void AddHumanMalePantsGraphics(IEnumerable<ushort> values) => ShardEntityGraphicHandlers.AddHumanMalePantsGraphics(this, values);

        public void AddElfMalePantsGraphics(IEnumerable<ushort> values) => ShardEntityGraphicHandlers.AddElfMalePantsGraphics(this, values);

        public void AddHumanFemalePantsGraphics(IEnumerable<ushort> values) => ShardEntityGraphicHandlers.AddHumanFemalePantsGraphics(this, values);

        public void AddElfFemalePantsGraphics(IEnumerable<ushort> values) => ShardEntityGraphicHandlers.AddElfFemalePantsGraphics(this, values);

        public void AddPantsHues(Range range) => ShardEntityGraphicHandlers.AddPantsHues(this, range);

        public void AddHumanMaleShirtGraphics(IEnumerable<ushort> values) => ShardEntityGraphicHandlers.AddHumanMaleShirtGraphics(this, values);

        public void AddElfMaleShirtGraphics(IEnumerable<ushort> values) => ShardEntityGraphicHandlers.AddElfMaleShirtGraphics(this, values);

        public void AddHumanFemaleShirtGraphics(IEnumerable<ushort> values) => ShardEntityGraphicHandlers.AddHumanFemaleShirtGraphics(this, values);

        public void AddElfFemaleShirtGraphics(IEnumerable<ushort> values) => ShardEntityGraphicHandlers.AddElfFemaleShirtGraphics(this, values);

        public void AddShirtHues(Range range) => ShardEntityGraphicHandlers.AddShirtHues(this, range);

        public void AddHumanMaleShoesGraphics(IEnumerable<ushort> values) => ShardEntityGraphicHandlers.AddHumanMaleShoesGraphics(this, values);

        public void AddElfMaleShoesGraphics(IEnumerable<ushort> values) => ShardEntityGraphicHandlers.AddElfMaleShoesGraphics(this, values);

        public void AddHumanFemaleShoesGraphics(IEnumerable<ushort> values) => ShardEntityGraphicHandlers.AddHumanFemaleShoesGraphics(this, values);

        public void AddElfFemaleShoesGraphics(IEnumerable<ushort> values) => ShardEntityGraphicHandlers.AddElfFemaleShoesGraphics(this, values);

        [NotMapped] public Dictionary<string, Identity> IdentityNames { get; } = new();

        [NotMapped] public Dictionary<Guid, Identity> IdentityGuids { get; } = new();

        [NotMapped] public Identity Male { get; set; }

        [NotMapped] public Identity Female { get; set; }

        [NotMapped] public Identity Human { get; set; }

        [NotMapped] public Identity Elf { get; set; }

        [NotMapped] public Identity Humanoid { get; set; }

        [NotMapped] public Identity Bandit { get; set; }

        [NotMapped] public Identity Ghost { get; set; }

        [NotMapped] public Identity Mobile { get; set; }

        [NotMapped] public Identity Alive { get; set; }

        [NotMapped] public Identity Dead { get; set; }

        [NotMapped] public Identity Character { get; set; }

        [NotMapped] public Identity Corpse { get; set; }

        [NotMapped] public Identity Dye { get; set; }

        [NotMapped] public Identity Pants { get; set; }

        [NotMapped] public Identity Shirt { get; set; }

        [NotMapped] public Identity Shoes { get; set; }

        [NotMapped] public Identity Backpack { get; set; }

        [NotMapped] public Identity Gold { get; set; }

        [NotMapped] public Identity RedBook { get; set; }

        [NotMapped] public Identity Robe { get; set; }

        [NotMapped] public Identity Candle { get; set; }

        [NotMapped] public Identity Dagger { get; set; }

        [NotMapped] public Identity Hair { get; set; }

        [NotMapped] public Identity Face { get; set; }

        [NotMapped] public Identity Beard { get; set; }

        [NotMapped] public Identity BodyPart { get; set; }

        [NotMapped] public Identity Container { get; set; }

        [NotMapped] public Identity Item { get; set; }

        public Dictionary<HashSet<Identity>, List<Range>> GraphicRanges { get; set; }

        public Dictionary<HashSet<Identity>, List<Range>> HueRanges { get; set; }

        public List<Identity> Containers { get; set; }

        [NotMapped] public List<HashSet<Identity>> IdentityTree { get; set; }
    }
}