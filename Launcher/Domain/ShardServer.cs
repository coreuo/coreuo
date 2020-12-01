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
    using ShardMobileProfessionHandlers = Shard.Mobile.Profession.Handlers<ShardServer, ShardState, Mobile, Item, Entity, Identity>;

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
        Shard.Mobile.Race.Domain.IServer<Item, Entity, Identity>,
        Shard.Entity.Identity.Domain.IServer<Entity, Identity>,
        Shard.Entity.Graphic.Domain.IServer<Identity>,
        Shard.Mobile.Profession.Domain.IServer<Item, Entity, Identity>
    {
        // ReSharper disable once UnusedMember.Global
        public int Id { get; set; }

        public Random Random { get; } = new();

        public void StatusClose(ShardState state){}

        public string Identity { get; set; } = nameof(ShardServer);

        public string IpAddress { get; set; } = "127.0.0.1";

        public int? Port { get; set; } = 2594;

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

        public void ThreadStart()
        {
            ShardEntityIdentityHandlers.LoadIdentities(this);

            ShardEntityGraphicHandlers.LoadGraphicRanges(this);

            ShardEntityGraphicHandlers.LoadHueRanges(this);

            ShardEntityGraphicHandlers.LoadContainers(this);

            GameDataHandlers.Load(this);

            NetworkListenerHandlers.Start(this);
        }

        public void ThreadUnlock()
        {
            TileArts.Clear();

            NetworkListenerHandlers.Stop(this);

            NetworkServerHandlers.Stop(this);
        }

        public void ThreadSlice() => NetworkServerHandlers.Slice(this);

        public Action ThreadStop { get; set; } = () => { };

        public void StateStart(ShardState state) => NetworkStateHandlers.Start(state);

        public void StateStop(ShardState state) => NetworkStateHandlers.Stop(state);

        public void DataReceived(ShardState state, Data data) => ShardMessageHandlers.Received(this, state, data);

        public void ClientSeed(ShardState state) => ShardServerHandlers.ClientSeed(this, state);

        public void EncryptionResponse(ShardState state){}

        public void AccountLogin(ShardState state) => ShardServerHandlers.AccountLogin(this, state);

        public void CharacterCreate(ShardState state) => ShardServerHandlers.CharacterCreate(this, state);

        public void MobileQuery(ShardState state) => ShardServerHandlers.MobileQuery(this, state);

        public void ExtendedData(ShardState state, Data data) => ShardExtendedMessageHandlers.Received(this, state, data);

        public void ChatRequest(ShardState state){}//ShardServerHandlers.ChatRequest(this, state);

        public void PingRequest(ShardState state) => ShardServerHandlers.PingRequest(this, state);

        public void MoveRequest(ShardState state) => ShardServerHandlers.MoveRequest(this, state);

        public void ClientType(ShardState state){}

        public void CharacterLogin(ShardState state) => ShardServerHandlers.CharacterLogin(this, state);

        public void EntityQuery(ShardState state) => ShardServerHandlers.EntityQuery(this, state);

        public void EntityUse(ShardState state) => ShardServerHandlers.EntityUse(this, state);

        public void ProfileRequest(ShardState state) => ShardServerHandlers.ProfileRequest(this, state);

        public void ItemPick(ShardState state) => ShardServerHandlers.ItemPick(this, state);

        public void ItemPlace(ShardState state) => ShardServerHandlers.ItemPlace(this, state);

        public void ItemWear(ShardState state) => ShardServerHandlers.ItemWear(this, state);

        public void WarModeRequest(ShardState state) => ShardServerHandlers.WarModeRequest(this, state);

        public void SpeechRequest(ShardState state) => ShardServerHandlers.SpeechRequest(this, state);

        public void TargetResponse(ShardState state){}//ShardServerHandlers.TargetResponse(this, state);

        public void ClientLanguage(ShardState state){}//ShardServerHandlers.ClientLanguage(this, state);

        public HashSet<Entity> Entities { get; } = new();

        public Queue<int> MobileSerialPool { get; } = new();

        [NotMapped] public int MaximumMobileSerial { get; set; }

        public Queue<int> ItemSerialPool { get; } = new();

        [NotMapped] public int MaximumItemSerial { get; set; } = 0x40000000;

        public void EncryptionRequest(ShardState state) => ShardMessageHandlers.EncryptionRequest(state);

        public void SupportedFeatures(ShardState state) => ShardMessageHandlers.SupportedFeatures(this, state);

        public void CharacterList(ShardState state) => ShardMessageHandlers.CharacterList(this, state);

        public void LoginConfirm(ShardState state, Mobile mobile) => ShardMessageHandlers.LoginConfirm(state, mobile);

        public void MapChange(ShardState state, Mobile mobile) => ShardExtendedMessageHandlers.MapChange(state, mobile);

        public void MapPatches(ShardState state, Mobile mobile) => ShardExtendedMessageHandlers.MapPatch(state, mobile);

        public void SeasonChange(ShardState state) => ShardMessageHandlers.SeasonChange(state);

        public void MobileUpdate(ShardState state, Mobile mobile) => ShardMessageHandlers.MobileUpdate(state, mobile);

        public void GlobalLight(ShardState state) => ShardMessageHandlers.GlobalLight(this, state);

        public void MobileLight(ShardState state, Mobile mobile) => ShardMessageHandlers.MobileLight(state, mobile);

        public void MobileIncoming(ShardState state, Mobile mobile) => ShardMessageHandlers.MobileIncoming(state, mobile);

        public void MobileStatus(ShardState state, Mobile mobile) => ShardMessageHandlers.MobileStatus(state, mobile);

        public void WarModeResponse(ShardState state, Mobile mobile) => ShardMessageHandlers.WarModeResponse(state, mobile);

        public void LoginComplete(ShardState state) => ShardMessageHandlers.LoginComplete(state);

        public void ServerTime(ShardState state) => ShardMessageHandlers.ServerTime(this, state);

        public void SkillInfo(ShardState state, Mobile mobile) => ShardMessageHandlers.SkillInfo(state, mobile);

        public void PingResponse(ShardState state) => ShardMessageHandlers.PingResponse(state);

        public void MoveResponse(ShardState state, Mobile mobile) => ShardMessageHandlers.MoveResponse(state, mobile);

        public void ClientVersionRequest(ShardState state) => ShardMessageHandlers.ClientVersionRequest(state);

        //public void ServerChange(ShardState state, Mobile mobile) => ShardMessageHandlers.ServerChange(state, mobile);

        public void EntityInfo(ShardState state, Entity entity) => ShardMessageHandlers.EntityInfo(state, entity);

        public void EntityAttributes(ShardState state, Entity entity) => ShardMessageHandlers.EntityAttributes(state, entity);

        //public void MobileAttributes(ShardState state, Mobile mobile) => ShardMessageHandlers.MobileAttributes(state, mobile);

        public void PaperDollOpen(ShardState state, Mobile mobile) => ShardMessageHandlers.PaperDollOpen(state, mobile);

        public void ProfileResponse(ShardState state, Mobile mobile) => ShardMessageHandlers.ProfileResponse(state, mobile);

        public void Output(string text) => Console.WriteLine($"[{DateTime.Now:O}] {Identity}.{text}");

        public void EntityDisplay(ShardState state, Entity entity) => ShardMessageHandlers.EntityDisplay(state, entity);

        public void EntityContent(ShardState state, Entity entity) => ShardMessageHandlers.EntityContent(state, entity);

        public void EntityRemove(ShardState state, Entity entity) => ShardMessageHandlers.EntityRemove(state, entity);

        public Item CreateItem(params Identity[] identities) => ShardServerHandlers.CreateItem(this, identities: identities);

        public Item CreateItem(ushort? graphic, ushort? hue, params Identity[] identities) => ShardServerHandlers.CreateItem(this, graphic, hue, identities);

        public HashSet<Identity> GetIdentitiesByGraphic(ushort graphic) => ShardEntityGraphicHandlers.GetIdentitiesByGraphic(this, graphic);

        public Item CreateItem(ushort hue, params Identity[] identities) => ShardServerHandlers.CreateItem(this, null, hue, identities);

        public void SetItemParent(Entity parent, Item item) => ShardServerHandlers.SetItemParent(this, parent, item);

        public void AssignFace(Mobile mobile, ShardState state = null) => ShardMobileRaceHandlers.AssignFace(this, mobile, state);

        public void AssignHair(Mobile mobile, ShardState state = null) => ShardMobileRaceHandlers.AssignHair(this, mobile, state);

        public void AssignBeard(Mobile mobile, ShardState state = null) => ShardMobileRaceHandlers.AssignBeard(this, mobile, state);

        public void RemoveItemParent(Item item) => ShardServerHandlers.RemoveItemParent(item);

        public void ItemWorld(ShardState state, Item item) => ShardMessageHandlers.ItemWorld(state, item);

        public void ItemWearUpdate(ShardState state, Item item) => ShardMessageHandlers.ItemWearUpdate(state, item);

        public void MobileMoving(ShardState state, Mobile mobile) => ShardMessageHandlers.MobileMoving(state, mobile);

        public void SpeechResponse(ShardState state, Mobile mobile) => ShardMessageHandlers.SpeechResponse(state, mobile);

        public void TargetRequest(ShardState state) => ShardMessageHandlers.TargetRequest(state);

        public void AssignName(Entity entity, string name) => GameDataHandlers.AssignName(this, entity, name);

        public void AssignGraphic(Entity entity, ushort? graphic) => ShardEntityGraphicHandlers.AssignGraphic(this, entity, graphic);

        public void AssignHue(Entity entity, ushort? hue) => ShardEntityGraphicHandlers.AssignHue(this, entity, hue);

        public void AssignMobileItems(Mobile mobile, ShardState state = null) => ShardEntityItemsHandlers.AssignMobileItems(this, mobile, state);

        public void AssignRace(ShardState state, HashSet<Identity> identities) => ShardMobileRaceHandlers.AssignRace(this, state, identities);

        public void AssignGender(ShardState state, HashSet<Identity> identities) => ShardMobileRaceHandlers.AssignGender(this, state, identities);

        public void UpdateRace(Mobile mobile) => ShardMobileRaceHandlers.UpdateRace(this, mobile);

        public void UpdateGender(Mobile mobile) => ShardMobileRaceHandlers.UpdateGender(this, mobile);

        public void AssignLayer(Item item) => GameDataHandlers.AssignLayer(this, item);

        public void AssignDisplayIndex(Item item) => ShardEntityGraphicHandlers.AssignDisplayIndex(this, item);

        public void AssignDisplay(Item item) => GameDataHandlers.AssignDisplay(this, item);

        public void AssignIdentities(HashSet<Identity> identities) => ShardEntityIdentityHandlers.AssignIdentities(this, identities);

        public void SoundPlay(ShardState state, Target target) => ShardMessageHandlers.SoundPlay(state, target);

        public void ItemPlaceApproved(ShardState state) => ShardMessageHandlers.ItemPlaceApproved(state);

        public void EntityContentItem(ShardState state, Item item) => ShardMessageHandlers.EntityContentItem(state, item);

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

        public void AddHumanMaleProfessionItems(sbyte id, IReadOnlyList<ushort> values) => ShardMobileProfessionHandlers.AddHumanMaleProfessionItems(this, id, values);

        public void AddHumanFemaleProfessionItems(sbyte id, IReadOnlyList<ushort> values) => ShardMobileProfessionHandlers.AddHumanFemaleProfessionItems(this, id, values);

        public void AddElfMaleProfessionItems(sbyte id, IReadOnlyList<ushort> values) => ShardMobileProfessionHandlers.AddElfMaleProfessionItems(this, id, values);

        public void AddElfFemaleProfessionItems(sbyte id, IReadOnlyList<ushort> values) => ShardMobileProfessionHandlers.AddElfFemaleProfessionItems(this, id, values);

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

        [NotMapped] public Identity Backpack { get; set; }

        [NotMapped] public Identity Gold { get; set; }

        [NotMapped] public Identity RedBook { get; set; }

        [NotMapped] public Identity Hair { get; set; }

        [NotMapped] public Identity Face { get; set; }

        [NotMapped] public Identity Beard { get; set; }

        [NotMapped] public Identity BodyPart { get; set; }

        [NotMapped] public Identity Container { get; set; }

        [NotMapped] public Identity Item { get; set; }

        [NotMapped] public Identity Warrior { get; set; }

        [NotMapped] public Identity Mage { get; set; }

        [NotMapped] public Identity Blacksmith { get; set; }

        [NotMapped] public Identity Paladin { get; set; }

        [NotMapped] public Identity Necromancer { get; set; }

        [NotMapped] public Identity Samurai { get; set; }

        [NotMapped] public Identity Ninja { get; set; }

        [NotMapped] public Identity CustomProfession { get; set; }

        [NotMapped] public Dictionary<HashSet<Identity>, List<(HashSet<Identity> identities, ushort hue)>> Professions { get; } = new();

        public void AssignProfession(ShardState state, HashSet<Identity> identities) => ShardMobileProfessionHandlers.AssignProfession(this, state, identities);

        [NotMapped] public Dictionary<HashSet<Identity>, List<Range>> GraphicRanges { get; set; } = new();

        [NotMapped] public Dictionary<HashSet<Identity>, List<Range>> HueRanges { get; set; } = new();

        [NotMapped] public List<Identity> Containers { get; set; } = new();

        [NotMapped] public List<HashSet<Identity>> IdentityTree { get; set; } = new();

        //Layer 1
        [NotMapped] public Identity BookOfArms { get; set; }
        [NotMapped] public Identity BookOfBushido { get; set; }
        [NotMapped] public Identity BookOfNinjitsu { get; set; }
        [NotMapped] public Identity Fukiya { get; set; }
        [NotMapped] public Identity NecromancerBook { get; set; }
        [NotMapped] public Identity PaladinSpellbook { get; set; }
        [NotMapped] public Identity Spellbook { get; set; }
        [NotMapped] public Identity SpellWeavingBook { get; set; }
        [NotMapped] public Identity AssassinSpike { get; set; }
        [NotMapped] public Identity BattleAxe { get; set; }
        [NotMapped] public Identity Bokuto { get; set; }
        [NotMapped] public Identity BoneHarvester { get; set; }
        [NotMapped] public Identity Bow { get; set; }
        [NotMapped] public Identity Broadsword { get; set; }
        [NotMapped] public Identity ButcherKnife { get; set; }
        [NotMapped] public Identity Cleaver { get; set; }
        [NotMapped] public Identity Club { get; set; }
        [NotMapped] public Identity Crossbow { get; set; }
        [NotMapped] public Identity Cutlass { get; set; }
        [NotMapped] public Identity Dagger { get; set; }

        public void AssignProfessionItems(Mobile mobile) => ShardMobileProfessionHandlers.AssignProfessionItems(this,mobile);

        [NotMapped] public Identity DiamondMace { get; set; }
        [NotMapped] public Identity ElvenMachete { get; set; }
        [NotMapped] public Identity HammerPick { get; set; }
        [NotMapped] public Identity HeavyCrossbow { get; set; }
        [NotMapped] public Identity Katana { get; set; }
        [NotMapped] public Identity Kryss { get; set; }
        [NotMapped] public Identity Lance { get; set; }
        [NotMapped] public Identity Leafblade { get; set; }
        [NotMapped] public Identity LizardmansMace { get; set; }
        [NotMapped] public Identity Longsword { get; set; }
        [NotMapped] public Identity LongSword { get; set; }
        [NotMapped] public Identity Mace { get; set; }
        [NotMapped] public Identity MagicSword { get; set; }
        [NotMapped] public Identity Maul { get; set; }
        [NotMapped] public Identity PaladinSword { get; set; }
        [NotMapped] public Identity Pick { get; set; }
        [NotMapped] public Identity Pickaxe { get; set; }
        [NotMapped] public Identity RadiantScimitar { get; set; }
        [NotMapped] public Identity RatmanAxe { get; set; }
        [NotMapped] public Identity RatmanSword { get; set; }
        [NotMapped] public Identity Scepter { get; set; }
        [NotMapped] public Identity Scimitar { get; set; }
        [NotMapped] public Identity Shortsword { get; set; }
        [NotMapped] public Identity SkeletonAxe { get; set; }
        [NotMapped] public Identity SkeletonScimitar { get; set; }
        [NotMapped] public Identity SkinningKnife { get; set; }
        [NotMapped] public Identity SledgeHammer { get; set; }
        [NotMapped] public Identity SmithsHammer { get; set; }
        [NotMapped] public Identity SmythHammer { get; set; }
        [NotMapped] public Identity Sword { get; set; }
        [NotMapped] public Identity TerathanMace { get; set; }
        [NotMapped] public Identity VikingSword { get; set; }
        [NotMapped] public Identity Wakizashi { get; set; }
        [NotMapped] public Identity Wand { get; set; }
        [NotMapped] public Identity WarAxe { get; set; }
        [NotMapped] public Identity WarCleaver { get; set; }
        [NotMapped] public Identity WarFork { get; set; }
        [NotMapped] public Identity WarHammer { get; set; }
        [NotMapped] public Identity WarMace { get; set; }
        [NotMapped] public Identity WildStaff { get; set; }

        //Layer 2
        [NotMapped] public Identity LightSource { get; set; }
        [NotMapped] public Identity Axe { get; set; }
        [NotMapped] public Identity Bardiche { get; set; }
        [NotMapped] public Identity BlackStaff { get; set; }
        [NotMapped] public Identity BladedStaff { get; set; }
        [NotMapped] public Identity BoneMageStaff { get; set; }
        [NotMapped] public Identity BronzeShield { get; set; }
        [NotMapped] public Identity Buckler { get; set; }
        [NotMapped] public Identity Candle { get; set; }
        [NotMapped] public Identity CompositeBow { get; set; }
        [NotMapped] public Identity CrescentBlade { get; set; }
        [NotMapped] public Identity Crook { get; set; }
        [NotMapped] public Identity DaemonSword { get; set; }
        [NotMapped] public Identity Daisho { get; set; }
        [NotMapped] public Identity DoubleAxe { get; set; }
        [NotMapped] public Identity DoubleBladedStaff { get; set; }
        [NotMapped] public Identity ElvenCompositeLo { get; set; }
        [NotMapped] public Identity ElvenSpellblade { get; set; }
        [NotMapped] public Identity EttinHammer { get; set; }
        [NotMapped] public Identity ExecutionersAxe { get; set; }
        [NotMapped] public Identity FishingPole { get; set; }
        [NotMapped] public Identity FrostTrollClub { get; set; }
        [NotMapped] public Identity GnarledStaff { get; set; }
        [NotMapped] public Identity Halberd { get; set; }
        [NotMapped] public Identity Hatchet { get; set; }
        [NotMapped] public Identity HeaterShield { get; set; }
        [NotMapped] public Identity HorsemansBow { get; set; }
        [NotMapped] public Identity ChaosShield { get; set; }
        [NotMapped] public Identity Javelin { get; set; }
        [NotMapped] public Identity Kama { get; set; }
        [NotMapped] public Identity KiteShield { get; set; }
        [NotMapped] public Identity Lajatang { get; set; }
        [NotMapped] public Identity Lantern { get; set; }
        [NotMapped] public Identity LargeBattleAxe { get; set; }
        [NotMapped] public Identity LichesStaff { get; set; }
        [NotMapped] public Identity LizardmansSpear { get; set; }
        [NotMapped] public Identity MagicalShortbow { get; set; }
        [NotMapped] public Identity MagicStaff { get; set; }
        [NotMapped] public Identity MetalShield { get; set; }
        [NotMapped] public Identity Naginata { get; set; }
        [NotMapped] public Identity NoDachi { get; set; }
        [NotMapped] public Identity Nunchaku { get; set; }
        [NotMapped] public Identity OgresClub { get; set; }
        [NotMapped] public Identity OphidianBardiche { get; set; }
        [NotMapped] public Identity OphidianStaff { get; set; }
        [NotMapped] public Identity OrcClub { get; set; }
        [NotMapped] public Identity OrcLordBattleaxe { get; set; }
        [NotMapped] public Identity OrcMageStaff { get; set; }
        [NotMapped] public Identity OrderShield { get; set; }
        [NotMapped] public Identity OrnateAxe { get; set; }
        [NotMapped] public Identity Pike { get; set; }
        [NotMapped] public Identity Pitchfork { get; set; }
        [NotMapped] public Identity QuarterStaff { get; set; }
        [NotMapped] public Identity RepeatingCrossbow { get; set; }
        [NotMapped] public Identity RuneBlade { get; set; }
        [NotMapped] public Identity Sai { get; set; }
        [NotMapped] public Identity ScaleShield { get; set; }
        [NotMapped] public Identity Scythe { get; set; }
        [NotMapped] public Identity ShepherdsCrook { get; set; }
        [NotMapped] public Identity ShortSpear { get; set; }
        [NotMapped] public Identity Spear { get; set; }
        [NotMapped] public Identity Tekagi { get; set; }
        [NotMapped] public Identity TerathanSpear { get; set; }
        [NotMapped] public Identity TerathanStaff { get; set; }
        [NotMapped] public Identity Tessen { get; set; }
        [NotMapped] public Identity Tetsubo { get; set; }
        [NotMapped] public Identity Torch { get; set; }
        [NotMapped] public Identity TrollAxe { get; set; }
        [NotMapped] public Identity TrollMaul { get; set; }
        [NotMapped] public Identity TwoHandedAxe { get; set; }
        [NotMapped] public Identity WoodenShield { get; set; }
        [NotMapped] public Identity Yumi { get; set; }

        //Layer 3
        [NotMapped] public Identity ArcaneThighBoots { get; set; }
        [NotMapped] public Identity Boots { get; set; }
        [NotMapped] public Identity ElvenBoot { get; set; }
        [NotMapped] public Identity FurBoots { get; set; }
        [NotMapped] public Identity JesterShoes { get; set; }
        [NotMapped] public Identity NinjaTallTabi { get; set; }
        [NotMapped] public Identity SamuraiSandalTabi { get; set; }
        [NotMapped] public Identity SamuraiWarajiTa { get; set; }
        [NotMapped] public Identity Sandals { get; set; }
        [NotMapped] public Identity SimpleShoes { get; set; }
        [NotMapped] public Identity TabiBootsTall { get; set; }
        [NotMapped] public Identity ThighBoots { get; set; }
        [NotMapped] public Identity Waraji { get; set; }

        //Layer 4
        [NotMapped] public Identity ShortPants { get; set; }
        [NotMapped] public Identity BoneLeggings { get; set; }
        [NotMapped] public Identity BoneLegs { get; set; }
        [NotMapped] public Identity DragonLeggings { get; set; }
        [NotMapped] public Identity ElvenPants { get; set; }
        [NotMapped] public Identity ElvenPlateLegs { get; set; }
        [NotMapped] public Identity Haidate { get; set; }
        [NotMapped] public Identity HidePants { get; set; }
        [NotMapped] public Identity ChainmailLeggings { get; set; }
        [NotMapped] public Identity JesterPants { get; set; }
        [NotMapped] public Identity Kobakama { get; set; }
        [NotMapped] public Identity LeatherHaidate { get; set; }
        [NotMapped] public Identity LeatherLeggings { get; set; }
        [NotMapped] public Identity LeatherNinjaPants { get; set; }
        [NotMapped] public Identity LeatherShorts { get; set; }
        [NotMapped] public Identity LeatherSkirt { get; set; }
        [NotMapped] public Identity LeatherSuneate { get; set; }
        [NotMapped] public Identity LongPants { get; set; }
        [NotMapped] public Identity LtArmorKilt { get; set; }
        [NotMapped] public Identity LtArmorPants { get; set; }
        [NotMapped] public Identity MailHaidate { get; set; }
        [NotMapped] public Identity NinjaPants { get; set; }
        [NotMapped] public Identity PlateHaidate { get; set; }
        [NotMapped] public Identity PlatemailLegs { get; set; }
        [NotMapped] public Identity PlateSuneate { get; set; }
        [NotMapped] public Identity RingmailLeggings { get; set; }
        [NotMapped] public Identity SpikedShorts { get; set; }
        [NotMapped] public Identity StuddedHaidate { get; set; }
        [NotMapped] public Identity StuddedLeggings { get; set; }
        [NotMapped] public Identity StuddedSuneate { get; set; }
        [NotMapped] public Identity TattsukeHakama { get; set; }

        //Layer 5
        [NotMapped] public Identity AmazonArmor { get; set; }
        [NotMapped] public Identity AmazonHarness { get; set; }
        [NotMapped] public Identity EliteHarness { get; set; }
        [NotMapped] public Identity ElvenShirt { get; set; }
        [NotMapped] public Identity Elvenshirt1Male { get; set; }
        [NotMapped] public Identity Elvenshirt2Male { get; set; }
        [NotMapped] public Identity ElvenShirtMale { get; set; }
        [NotMapped] public Identity FancyShirt { get; set; }
        [NotMapped] public Identity Fshirt1Chest { get; set; }
        [NotMapped] public Identity Fshirt2Chest { get; set; }
        [NotMapped] public Identity CheckeredShirt { get; set; }
        [NotMapped] public Identity NinjaShirt { get; set; }
        [NotMapped] public Identity SimpleShirt { get; set; }

        //Layer 6
        [NotMapped] public Identity Bandana { get; set; }
        [NotMapped] public Identity Bascinet { get; set; }
        [NotMapped] public Identity BearMask { get; set; }
        [NotMapped] public Identity BoneHelmet { get; set; }
        [NotMapped] public Identity Bonnet { get; set; }
        [NotMapped] public Identity Cap { get; set; }
        [NotMapped] public Identity Circlet { get; set; }
        [NotMapped] public Identity Circlet1 { get; set; }
        [NotMapped] public Identity Circlet2 { get; set; }
        [NotMapped] public Identity Circlet3 { get; set; }
        [NotMapped] public Identity CloseHelm { get; set; }
        [NotMapped] public Identity CloseHelmet { get; set; }
        [NotMapped] public Identity DeerMask { get; set; }
        [NotMapped] public Identity DragonHelm { get; set; }
        [NotMapped] public Identity ElvenGlasses { get; set; }
        [NotMapped] public Identity FeatheredHat { get; set; }
        [NotMapped] public Identity FeatheredMask { get; set; }
        [NotMapped] public Identity FloppyHat { get; set; }
        [NotMapped] public Identity FlowerGarland { get; set; }
        [NotMapped] public Identity GemmedCirclet { get; set; }
        [NotMapped] public Identity Hachimaki { get; set; }
        [NotMapped] public Identity Helmet { get; set; }
        [NotMapped] public Identity ChainmailCoif { get; set; }
        [NotMapped] public Identity JesterHat { get; set; }
        [NotMapped] public Identity JestersCap { get; set; }
        [NotMapped] public Identity Kabuto { get; set; }
        [NotMapped] public Identity KabutoMempo { get; set; }
        [NotMapped] public Identity Kasa { get; set; }
        [NotMapped] public Identity LeatherCap { get; set; }
        [NotMapped] public Identity LeatherJingasa { get; set; }
        [NotMapped] public Identity LeatherNinjaHood { get; set; }
        [NotMapped] public Identity MailHatsuburi { get; set; }
        [NotMapped] public Identity MElvenGlasses { get; set; }
        [NotMapped] public Identity NinjaMask { get; set; }
        [NotMapped] public Identity NorseHelm { get; set; }
        [NotMapped] public Identity OrcHelm { get; set; }
        [NotMapped] public Identity OrcMask { get; set; }
        [NotMapped] public Identity PlateHatsuburi { get; set; }
        [NotMapped] public Identity PlateHelm { get; set; }
        [NotMapped] public Identity PlateJingasa { get; set; }
        [NotMapped] public Identity PlateKabuto { get; set; }
        [NotMapped] public Identity RavenHelm { get; set; }
        [NotMapped] public Identity RobinHoodCap { get; set; }
        [NotMapped] public Identity RoyalCirclet { get; set; }
        [NotMapped] public Identity Skullcap { get; set; }
        [NotMapped] public Identity StrawHat { get; set; }
        [NotMapped] public Identity TallStrawHat { get; set; }
        [NotMapped] public Identity TribalMask { get; set; }
        [NotMapped] public Identity TricorneHat { get; set; }
        [NotMapped] public Identity VultureHelm { get; set; }
        [NotMapped] public Identity WideBrimHat { get; set; }
        [NotMapped] public Identity WingedHelm { get; set; }
        [NotMapped] public Identity WingedHelmet { get; set; }
        [NotMapped] public Identity WizardsHat { get; set; }

        //Layer 7
        [NotMapped] public Identity ArcaneGloves { get; set; }
        [NotMapped] public Identity BoneGloves { get; set; }
        [NotMapped] public Identity DragonGloves { get; set; }
        [NotMapped] public Identity ElvenPlateGloves { get; set; }
        [NotMapped] public Identity HideGloves { get; set; }
        [NotMapped] public Identity KoteGloves { get; set; }
        [NotMapped] public Identity LeatherGloves { get; set; }
        [NotMapped] public Identity LeatherNinjaMitts { get; set; }
        [NotMapped] public Identity LtArmorGloves { get; set; }
        [NotMapped] public Identity PlatemailGloves { get; set; }
        [NotMapped] public Identity RingmailGloves { get; set; }
        [NotMapped] public Identity StuddedGloves { get; set; }

        //Layer 8
        [NotMapped] public Identity Ring { get; set; }

        //Layer 9
        [NotMapped] public Identity Talisman { get; set; }

        //Layer 10
        [NotMapped] public Identity BeadNecklace { get; set; }
        [NotMapped] public Identity ElvenPlateGorget { get; set; }
        [NotMapped] public Identity HideGorget { get; set; }
        [NotMapped] public Identity LeatherGorget { get; set; }
        [NotMapped] public Identity LeatherMempo { get; set; }
        [NotMapped] public Identity LtArmorGorget { get; set; }
        [NotMapped] public Identity Necklace { get; set; }
        [NotMapped] public Identity PlateGorget { get; set; }
        [NotMapped] public Identity PlatemailGorget { get; set; }
        [NotMapped] public Identity PlateMempo { get; set; }
        [NotMapped] public Identity SilverNecklace { get; set; }
        [NotMapped] public Identity StuddedGorget { get; set; }
        [NotMapped] public Identity StuddedMempo { get; set; }

        //Layer 12
        [NotMapped] public Identity ElvenPlateBelt { get; set; }
        [NotMapped] public Identity HalfApron { get; set; }
        [NotMapped] public Identity LeatherNinjaBelt { get; set; }
        [NotMapped] public Identity Obi { get; set; }
        [NotMapped] public Identity WoodlandBelt { get; set; }

        //Layer 13
        [NotMapped] public Identity BoneArmor { get; set; }
        [NotMapped] public Identity ClothNinjaJacket { get; set; }
        [NotMapped] public Identity DoMaru { get; set; }
        [NotMapped] public Identity DragonBreastplate { get; set; }
        [NotMapped] public Identity ElvenPlate { get; set; }
        [NotMapped] public Identity HaramakiDoChest { get; set; }
        [NotMapped] public Identity HideFemaleChest { get; set; }
        [NotMapped] public Identity HideChest { get; set; }
        [NotMapped] public Identity ChainmailTunic { get; set; }
        [NotMapped] public Identity LeatherArmor { get; set; }
        [NotMapped] public Identity LeatherBustier { get; set; }
        [NotMapped] public Identity LeatherDo { get; set; }
        [NotMapped] public Identity LeatherNinjaJacke { get; set; }
        [NotMapped] public Identity LeatherTunic { get; set; }
        [NotMapped] public Identity LtArmorChest { get; set; }
        [NotMapped] public Identity LtfChest { get; set; }
        [NotMapped] public Identity NinjaJacket { get; set; }
        [NotMapped] public Identity PlateArmor { get; set; }
        [NotMapped] public Identity PlateDo { get; set; }
        [NotMapped] public Identity Platemail { get; set; }
        [NotMapped] public Identity RingmailTunic { get; set; }
        [NotMapped] public Identity StuddedArmor { get; set; }
        [NotMapped] public Identity StuddedBustier { get; set; }
        [NotMapped] public Identity StuddedDo { get; set; }
        [NotMapped] public Identity StuddedTunic { get; set; }
        [NotMapped] public Identity WoodlandBreastplat { get; set; }

        //Layer 14
        [NotMapped] public Identity Bracelet { get; set; }

        //Layer 17
        [NotMapped] public Identity BodySash { get; set; }
        [NotMapped] public Identity Doublet { get; set; }
        [NotMapped] public Identity FormalShirt { get; set; }
        [NotMapped] public Identity FullApron { get; set; }
        [NotMapped] public Identity JesterSuit { get; set; }
        [NotMapped] public Identity JinBaori { get; set; }
        [NotMapped] public Identity Surcoat { get; set; }
        [NotMapped] public Identity Tunic { get; set; }

        //Layer 18
        [NotMapped] public Identity Earrings { get; set; }

        //Layer 19
        [NotMapped] public Identity BoneArms { get; set; }
        [NotMapped] public Identity DragonSleeves { get; set; }
        [NotMapped] public Identity ElvenArmPlate { get; set; }
        [NotMapped] public Identity HaramakiDoArms { get; set; }
        [NotMapped] public Identity HidePaldrons { get; set; }
        [NotMapped] public Identity KoteSleeves { get; set; }
        [NotMapped] public Identity LeatherSleeves { get; set; }
        [NotMapped] public Identity LtArmorPaldrons { get; set; }
        [NotMapped] public Identity PlatemailArms { get; set; }
        [NotMapped] public Identity RingmailSleeves { get; set; }
        [NotMapped] public Identity SamuraiArmorArms { get; set; }
        [NotMapped] public Identity StuddedSleeves { get; set; }

        //Layer 20
        [NotMapped] public Identity ArcaneCloak { get; set; }
        [NotMapped] public Identity ElvenQuiver { get; set; }
        [NotMapped] public Identity FurCape { get; set; }
        [NotMapped] public Identity MElvenQuiver { get; set; }
        [NotMapped] public Identity SimpleCloak { get; set; }

        //Layer 22
        [NotMapped] public Identity DeathShroud { get; set; }
        [NotMapped] public Identity GmRobe { get; set; }
        [NotMapped] public Identity HoodedShroud { get; set; }
        [NotMapped] public Identity ArcaneRobe { get; set; }
        [NotMapped] public Identity ElvenRobe { get; set; }
        [NotMapped] public Identity FancyDress { get; set; }
        [NotMapped] public Identity FemaleKimono { get; set; }
        [NotMapped] public Identity GildedDress { get; set; }
        [NotMapped] public Identity HakamaShita { get; set; }
        [NotMapped] public Identity Kamishimo { get; set; }
        [NotMapped] public Identity Kimono { get; set; }
        [NotMapped] public Identity KimonoFemaleDres { get; set; }
        [NotMapped] public Identity KimonoMaleDress { get; set; }
        [NotMapped] public Identity LongDress { get; set; }
        [NotMapped] public Identity MaleKimono { get; set; }
        [NotMapped] public Identity MElvenRobe01 { get; set; }
        [NotMapped] public Identity MElvenRobe02 { get; set; }
        [NotMapped] public Identity PlainDress { get; set; }
        [NotMapped] public Identity Robe { get; set; }

        //Layer 23
        [NotMapped] public Identity FurSurong { get; set; }
        [NotMapped] public Identity Hakama { get; set; }
        [NotMapped] public Identity Kilt { get; set; }
        [NotMapped] public Identity KneeSkirt { get; set; }
        [NotMapped] public Identity SimpleSkirt { get; set; }

        [NotMapped] public Identity OneHand { get; set; }
        [NotMapped] public Identity TwoHand { get; set; }
        [NotMapped] public Identity Shoes { get; set; }
        [NotMapped] public Identity Pants { get; set; }
        [NotMapped] public Identity Shirt { get; set; }
        [NotMapped] public Identity Hat { get; set; }
        [NotMapped] public Identity Gloves { get; set; }
        [NotMapped] public Identity Gorget { get; set; }
        [NotMapped] public Identity Belt { get; set; }
        [NotMapped] public Identity Chest { get; set; }
        [NotMapped] public Identity Sash { get; set; }
        [NotMapped] public Identity Arms { get; set; }
        [NotMapped] public Identity Cloak { get; set; }
        [NotMapped] public Identity Dress { get; set; }
        [NotMapped] public Identity Skirt { get; set; }
    }
}