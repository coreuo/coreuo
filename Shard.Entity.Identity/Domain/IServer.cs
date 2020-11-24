using System;
using System.Collections.Generic;
using System.Linq;

namespace Shard.Entity.Identity.Domain
{
    public interface IServer<TEntity, TIdentity>
        where TIdentity : class, IIdentity, new()
    {
        HashSet<TEntity> Entities { get; }

        Random Random { get; }

        Dictionary<string, TIdentity> IdentityNames { get; }

        Dictionary<Guid, TIdentity> IdentityGuids { get; }

        private TIdentity Identity(string guid, string name)
        {
            var identity = new TIdentity{ Guid = new Guid(guid), Name = name };

            IdentityNames.Add(identity.Name, identity);

            if(IdentityGuids.TryGetValue(identity.Guid, out var existing))
                throw new InvalidOperationException($"Cannot add identity ({identity}) with guid ({guid}), because identity ({existing}) already has this guid");

            IdentityGuids.Add(identity.Guid, identity);

            return identity;
        }

        TIdentity Male { get; set; }

        TIdentity Female { get; set; }

        TIdentity Human { get; set; }

        TIdentity Elf { get; set; }

        TIdentity Humanoid { get; set; }

        TIdentity Bandit { get; set; }

        TIdentity Ghost { get; set; }

        TIdentity Mobile { get; set; }

        TIdentity Alive { get; set; }

        TIdentity Dead { get; set; }

        TIdentity Character { get; set; }

        TIdentity Corpse { get; set; }

        TIdentity Dye { get; set; }

        TIdentity Backpack { get; set; }

        TIdentity Gold { get; set; }

        TIdentity RedBook { get; set; }

        TIdentity Hair { get; set; }

        TIdentity Face { get; set; }

        TIdentity Beard { get; set; }

        TIdentity BodyPart { get; set; }

        TIdentity Container { get; set; }

        TIdentity Item { get; set; }

        TIdentity Warrior { get; set; }
        TIdentity Mage { get; set; }
        TIdentity Blacksmith { get; set; }
        TIdentity Paladin { get; set; }
        TIdentity Necromancer { get; set; }
        TIdentity Samurai { get; set; }
        TIdentity Ninja { get; set; }
        TIdentity CustomProfession { get; set; }

        //Layer 1
        TIdentity BookOfArms { get; set; }
        TIdentity BookOfBushido { get; set; }
        TIdentity BookOfNinjitsu { get; set; }
        TIdentity Fukiya { get; set; }
        TIdentity NecromancerBook { get; set; }
        TIdentity PaladinSpellbook { get; set; }
        TIdentity Spellbook { get; set; }
        TIdentity SpellWeavingBook { get; set; }
        TIdentity AssassinSpike { get; set; }
        TIdentity BattleAxe { get; set; }
        TIdentity Bokuto { get; set; }
        TIdentity BoneHarvester { get; set; }
        TIdentity Bow { get; set; }
        TIdentity Broadsword { get; set; }
        TIdentity ButcherKnife { get; set; }
        TIdentity Cleaver { get; set; }
        TIdentity Club { get; set; }
        TIdentity Crossbow { get; set; }
        TIdentity Cutlass { get; set; }
        TIdentity Dagger { get; set; }
        TIdentity DiamondMace { get; set; }
        TIdentity ElvenMachete { get; set; }
        TIdentity HammerPick { get; set; }
        TIdentity HeavyCrossbow { get; set; }
        TIdentity Katana { get; set; }
        TIdentity Kryss { get; set; }
        TIdentity Lance { get; set; }
        TIdentity Leafblade { get; set; }
        TIdentity LizardmansMace { get; set; }
        TIdentity Longsword { get; set; }
        TIdentity LongSword { get; set; }
        TIdentity Mace { get; set; }
        TIdentity MagicSword { get; set; }
        TIdentity Maul { get; set; }
        TIdentity PaladinSword { get; set; }
        TIdentity Pick { get; set; }
        TIdentity Pickaxe { get; set; }
        TIdentity RadiantScimitar { get; set; }
        TIdentity RatmanAxe { get; set; }
        TIdentity RatmanSword { get; set; }
        TIdentity Scepter { get; set; }
        TIdentity Scimitar { get; set; }
        TIdentity Shortsword { get; set; }
        TIdentity SkeletonAxe { get; set; }
        TIdentity SkeletonScimitar { get; set; }
        TIdentity SkinningKnife { get; set; }
        TIdentity SledgeHammer { get; set; }
        TIdentity SmithsHammer { get; set; }
        TIdentity SmythHammer { get; set; }
        TIdentity Sword { get; set; }
        TIdentity TerathanMace { get; set; }
        TIdentity VikingSword { get; set; }
        TIdentity Wakizashi { get; set; }
        TIdentity Wand { get; set; }
        TIdentity WarAxe { get; set; }
        TIdentity WarCleaver { get; set; }
        TIdentity WarFork { get; set; }
        TIdentity WarHammer { get; set; }
        TIdentity WarMace { get; set; }
        TIdentity WildStaff { get; set; }

        //Layer 2
        TIdentity LightSource { get; set; }
        TIdentity Axe { get; set; }
        TIdentity Bardiche { get; set; }
        TIdentity BlackStaff { get; set; }
        TIdentity BladedStaff { get; set; }
        TIdentity BoneMageStaff { get; set; }
        TIdentity BronzeShield { get; set; }
        TIdentity Buckler { get; set; }
        TIdentity Candle { get; set; }
        TIdentity CompositeBow { get; set; }
        TIdentity CrescentBlade { get; set; }
        TIdentity Crook { get; set; }
        TIdentity DaemonSword { get; set; }
        TIdentity Daisho { get; set; }
        TIdentity DoubleAxe { get; set; }
        TIdentity DoubleBladedStaff { get; set; }
        TIdentity ElvenCompositeLo { get; set; }
        TIdentity ElvenSpellblade { get; set; }
        TIdentity EttinHammer { get; set; }
        TIdentity ExecutionersAxe { get; set; }
        TIdentity FishingPole { get; set; }
        TIdentity FrostTrollClub { get; set; }
        TIdentity GnarledStaff { get; set; }
        TIdentity Halberd { get; set; }
        TIdentity Hatchet { get; set; }
        TIdentity HeaterShield { get; set; }
        TIdentity HorsemansBow { get; set; }
        TIdentity ChaosShield { get; set; }
        TIdentity Javelin { get; set; }
        TIdentity Kama { get; set; }
        TIdentity KiteShield { get; set; }
        TIdentity Lajatang { get; set; }
        TIdentity Lantern { get; set; }
        TIdentity LargeBattleAxe { get; set; }
        TIdentity LichesStaff { get; set; }
        TIdentity LizardmansSpear { get; set; }
        TIdentity MagicalShortbow { get; set; }
        TIdentity MagicStaff { get; set; }
        TIdentity MetalShield { get; set; }
        TIdentity Naginata { get; set; }
        TIdentity NoDachi { get; set; }
        TIdentity Nunchaku { get; set; }
        TIdentity OgresClub { get; set; }
        TIdentity OphidianBardiche { get; set; }
        TIdentity OphidianStaff { get; set; }
        TIdentity OrcClub { get; set; }
        TIdentity OrcLordBattleaxe { get; set; }
        TIdentity OrcMageStaff { get; set; }
        TIdentity OrderShield { get; set; }
        TIdentity OrnateAxe { get; set; }
        TIdentity Pike { get; set; }
        TIdentity Pitchfork { get; set; }
        TIdentity QuarterStaff { get; set; }
        TIdentity RepeatingCrossbow { get; set; }
        TIdentity RuneBlade { get; set; }
        TIdentity Sai { get; set; }
        TIdentity ScaleShield { get; set; }
        TIdentity Scythe { get; set; }
        TIdentity ShepherdsCrook { get; set; }
        TIdentity ShortSpear { get; set; }
        TIdentity Spear { get; set; }
        TIdentity Tekagi { get; set; }
        TIdentity TerathanSpear { get; set; }
        TIdentity TerathanStaff { get; set; }
        TIdentity Tessen { get; set; }
        TIdentity Tetsubo { get; set; }
        TIdentity Torch { get; set; }
        TIdentity TrollAxe { get; set; }
        TIdentity TrollMaul { get; set; }
        TIdentity TwoHandedAxe { get; set; }
        TIdentity WoodenShield { get; set; }
        TIdentity Yumi { get; set; }

        //Layer 3
        TIdentity ArcaneThighBoots { get; set; }
        TIdentity Boots { get; set; }
        TIdentity ElvenBoot { get; set; }
        TIdentity FurBoots { get; set; }
        TIdentity JesterShoes { get; set; }
        TIdentity NinjaTallTabi { get; set; }
        TIdentity SamuraiSandalTabi { get; set; }
        TIdentity SamuraiWarajiTa { get; set; }
        TIdentity Sandals { get; set; }
        TIdentity SimpleShoes { get; set; }
        TIdentity TabiBootsTall { get; set; }
        TIdentity ThighBoots { get; set; }
        TIdentity Waraji { get; set; }

        //Layer 4
        TIdentity ShortPants { get; set; }
        TIdentity BoneLeggings { get; set; }
        TIdentity BoneLegs { get; set; }
        TIdentity DragonLeggings { get; set; }
        TIdentity ElvenPants { get; set; }
        TIdentity ElvenPlateLegs { get; set; }
        TIdentity Haidate { get; set; }
        TIdentity HidePants { get; set; }
        TIdentity ChainmailLeggings { get; set; }
        TIdentity JesterPants { get; set; }
        TIdentity Kobakama { get; set; }
        TIdentity LeatherHaidate { get; set; }
        TIdentity LeatherLeggings { get; set; }
        TIdentity LeatherNinjaPants { get; set; }
        TIdentity LeatherShorts { get; set; }
        TIdentity LeatherSkirt { get; set; }
        TIdentity LeatherSuneate { get; set; }
        TIdentity LongPants { get; set; }
        TIdentity LtArmorKilt { get; set; }
        TIdentity LtArmorPants { get; set; }
        TIdentity MailHaidate { get; set; }
        TIdentity NinjaPants { get; set; }
        TIdentity PlateHaidate { get; set; }
        TIdentity PlatemailLegs { get; set; }
        TIdentity PlateSuneate { get; set; }
        TIdentity RingmailLeggings { get; set; }
        TIdentity SpikedShorts { get; set; }
        TIdentity StuddedHaidate { get; set; }
        TIdentity StuddedLeggings { get; set; }
        TIdentity StuddedSuneate { get; set; }
        TIdentity TattsukeHakama { get; set; }

        //Layer 5
        TIdentity AmazonArmor { get; set; }
        TIdentity AmazonHarness { get; set; }
        TIdentity EliteHarness { get; set; }
        TIdentity ElvenShirt { get; set; }
        TIdentity Elvenshirt1Male { get; set; }
        TIdentity Elvenshirt2Male { get; set; }
        TIdentity ElvenShirtMale { get; set; }
        TIdentity FancyShirt { get; set; }
        TIdentity Fshirt1Chest { get; set; }
        TIdentity Fshirt2Chest { get; set; }
        TIdentity CheckeredShirt { get; set; }
        TIdentity NinjaShirt { get; set; }
        TIdentity SimpleShirt { get; set; }

        //Layer 6
        TIdentity Bandana { get; set; }
        TIdentity Bascinet { get; set; }
        TIdentity BearMask { get; set; }
        TIdentity BoneHelmet { get; set; }
        TIdentity Bonnet { get; set; }
        TIdentity Cap { get; set; }
        TIdentity Circlet { get; set; }
        TIdentity Circlet1 { get; set; }
        TIdentity Circlet2 { get; set; }
        TIdentity Circlet3 { get; set; }
        TIdentity CloseHelm { get; set; }
        TIdentity CloseHelmet { get; set; }
        TIdentity DeerMask { get; set; }
        TIdentity DragonHelm { get; set; }
        TIdentity ElvenGlasses { get; set; }
        TIdentity FeatheredHat { get; set; }
        TIdentity FeatheredMask { get; set; }
        TIdentity FloppyHat { get; set; }
        TIdentity FlowerGarland { get; set; }
        TIdentity GemmedCirclet { get; set; }
        TIdentity Hachimaki { get; set; }
        TIdentity Helmet { get; set; }
        TIdentity ChainmailCoif { get; set; }
        TIdentity JesterHat { get; set; }
        TIdentity JestersCap { get; set; }
        TIdentity Kabuto { get; set; }
        TIdentity KabutoMempo { get; set; }
        TIdentity Kasa { get; set; }
        TIdentity LeatherCap { get; set; }
        TIdentity LeatherJingasa { get; set; }
        TIdentity LeatherNinjaHood { get; set; }
        TIdentity MailHatsuburi { get; set; }
        TIdentity MElvenGlasses { get; set; }
        TIdentity NinjaMask { get; set; }
        TIdentity NorseHelm { get; set; }
        TIdentity OrcHelm { get; set; }
        TIdentity OrcMask { get; set; }
        TIdentity PlateHatsuburi { get; set; }
        TIdentity PlateHelm { get; set; }
        TIdentity PlateJingasa { get; set; }
        TIdentity PlateKabuto { get; set; }
        TIdentity RavenHelm { get; set; }
        TIdentity RobinHoodCap { get; set; }
        TIdentity RoyalCirclet { get; set; }
        TIdentity Skullcap { get; set; }
        TIdentity StrawHat { get; set; }
        TIdentity TallStrawHat { get; set; }
        TIdentity TribalMask { get; set; }
        TIdentity TricorneHat { get; set; }
        TIdentity VultureHelm { get; set; }
        TIdentity WideBrimHat { get; set; }
        TIdentity WingedHelm { get; set; }
        TIdentity WingedHelmet { get; set; }
        TIdentity WizardsHat { get; set; }

        //Layer 7
        TIdentity ArcaneGloves { get; set; }
        TIdentity BoneGloves { get; set; }
        TIdentity DragonGloves { get; set; }
        TIdentity ElvenPlateGloves { get; set; }
        TIdentity HideGloves { get; set; }
        TIdentity KoteGloves { get; set; }
        TIdentity LeatherGloves { get; set; }
        TIdentity LeatherNinjaMitts { get; set; }
        TIdentity LtArmorGloves { get; set; }
        TIdentity PlatemailGloves { get; set; }
        TIdentity RingmailGloves { get; set; }
        TIdentity StuddedGloves { get; set; }

        //Layer 8
        TIdentity Ring { get; set; }

        //Layer 9
        TIdentity Talisman { get; set; }

        //Layer 10
        TIdentity BeadNecklace { get; set; }
        TIdentity ElvenPlateGorget { get; set; }
        TIdentity HideGorget { get; set; }
        TIdentity LeatherGorget { get; set; }
        TIdentity LeatherMempo { get; set; }
        TIdentity LtArmorGorget { get; set; }
        TIdentity Necklace { get; set; }
        TIdentity PlateGorget { get; set; }
        TIdentity PlatemailGorget { get; set; }
        TIdentity PlateMempo { get; set; }
        TIdentity SilverNecklace { get; set; }
        TIdentity StuddedGorget { get; set; }
        TIdentity StuddedMempo { get; set; }

        //Layer 12
        TIdentity ElvenPlateBelt { get; set; }
        TIdentity HalfApron { get; set; }
        TIdentity LeatherNinjaBelt { get; set; }
        TIdentity Obi { get; set; }
        TIdentity WoodlandBelt { get; set; }

        //Layer 13
        TIdentity BoneArmor { get; set; }
        TIdentity ClothNinjaJacket { get; set; }
        TIdentity DoMaru { get; set; }
        TIdentity DragonBreastplate { get; set; }
        TIdentity ElvenPlate { get; set; }
        TIdentity HaramakiDoChest { get; set; }
        TIdentity HideFemaleChest { get; set; }
        TIdentity HideChest { get; set; }
        TIdentity ChainmailTunic { get; set; }
        TIdentity LeatherArmor { get; set; }
        TIdentity LeatherBustier { get; set; }
        TIdentity LeatherDo { get; set; }
        TIdentity LeatherNinjaJacke { get; set; }
        TIdentity LeatherTunic { get; set; }
        TIdentity LtArmorChest { get; set; }
        TIdentity LtfChest { get; set; }
        TIdentity NinjaJacket { get; set; }
        TIdentity PlateArmor { get; set; }
        TIdentity PlateDo { get; set; }
        TIdentity Platemail { get; set; }
        TIdentity RingmailTunic { get; set; }
        TIdentity StuddedArmor { get; set; }
        TIdentity StuddedBustier { get; set; }
        TIdentity StuddedDo { get; set; }
        TIdentity StuddedTunic { get; set; }
        TIdentity WoodlandBreastplat { get; set; }

        //Layer 14
        TIdentity Bracelet { get; set; }

        //Layer 17
        TIdentity BodySash { get; set; }
        TIdentity Doublet { get; set; }
        TIdentity FormalShirt { get; set; }
        TIdentity FullApron { get; set; }
        TIdentity JesterSuit { get; set; }
        TIdentity JinBaori { get; set; }
        TIdentity Surcoat { get; set; }
        TIdentity Tunic { get; set; }

        //Layer 18
        TIdentity Earrings { get; set; }

        //Layer 19
        TIdentity BoneArms { get; set; }
        TIdentity DragonSleeves { get; set; }
        TIdentity ElvenArmPlate { get; set; }
        TIdentity HaramakiDoArms { get; set; }
        TIdentity HidePaldrons { get; set; }
        TIdentity KoteSleeves { get; set; }
        TIdentity LeatherSleeves { get; set; }
        TIdentity LtArmorPaldrons { get; set; }
        TIdentity PlatemailArms { get; set; }
        TIdentity RingmailSleeves { get; set; }
        TIdentity SamuraiArmorArms { get; set; }
        TIdentity StuddedSleeves { get; set; }

        //Layer 20
        TIdentity ArcaneCloak { get; set; }
        TIdentity ElvenQuiver { get; set; }
        TIdentity FurCape { get; set; }
        TIdentity MElvenQuiver { get; set; }
        TIdentity SimpleCloak { get; set; }

        //Layer 22
        TIdentity DeathShroud { get; set; }
        TIdentity GmRobe { get; set; }
        TIdentity HoodedShroud { get; set; }
        TIdentity ArcaneRobe { get; set; }
        TIdentity ElvenRobe { get; set; }
        TIdentity FancyDress { get; set; }
        TIdentity FemaleKimono { get; set; }
        TIdentity GildedDress { get; set; }
        TIdentity HakamaShita { get; set; }
        TIdentity Kamishimo { get; set; }
        TIdentity Kimono { get; set; }
        TIdentity KimonoFemaleDres { get; set; }
        TIdentity KimonoMaleDress { get; set; }
        TIdentity LongDress { get; set; }
        TIdentity MaleKimono { get; set; }
        TIdentity MElvenRobe01 { get; set; }
        TIdentity MElvenRobe02 { get; set; }
        TIdentity PlainDress { get; set; }
        TIdentity Robe { get; set; }

        //Layer 23
        TIdentity FurSurong { get; set; }
        TIdentity Hakama { get; set; }
        TIdentity Kilt { get; set; }
        TIdentity KneeSkirt { get; set; }
        TIdentity SimpleSkirt { get; set; }

        TIdentity OneHand { get; set; }
        TIdentity TwoHand { get; set; }
        TIdentity Shoes { get; set; }
        TIdentity Pants { get; set; }
        TIdentity Shirt { get; set; }
        TIdentity Hat { get; set; }
        TIdentity Gloves { get; set; }
        TIdentity Gorget { get; set; }
        TIdentity Belt { get; set; }
        TIdentity Chest { get; set; }
        TIdentity Sash { get; set; }
        TIdentity Arms { get; set; }
        TIdentity Cloak { get; set; }
        TIdentity Dress { get; set; }
        TIdentity Skirt { get; set; }

        internal void Initialize()
        {
            IdentityNames.Clear();

            IdentityGuids.Clear();

            Male = Identity("4E9266ED-1F02-4CDC-B5A6-E5B0877C5177", nameof(Male));

            Female = Identity("61BC74BF-9B5C-46C4-B8D0-DD106FE2C513", nameof(Female));

            Human = Identity("A200AD91-34A2-4A98-9968-586E07176503", nameof(Human));

            Elf = Identity("A8E2D8A2-F1F2-47CB-9CDE-DFBE838929A8", nameof(Elf));

            Humanoid = Identity("D8D78474-AA82-4981-9A25-ED5AAAE67262", nameof(Humanoid));

            Bandit = Identity("F0F7C9F3-621B-4BCC-A83A-C0C8B55E5BAB", nameof(Bandit));

            Ghost = Identity("E80EB46C-2B8F-4F3E-B962-C8CE0713A9F9", nameof(Ghost));

            Mobile = Identity("46BCFF7D-9AEE-4ECC-A86C-D4A1B1AFA145", nameof(Mobile));

            Alive = Identity("DFEB14F7-F944-47DF-B270-B0F73158B91F", nameof(Alive));

            Dead = Identity("F1ECB67E-BF10-455B-8E04-D1D94F6846AF", nameof(Dead));

            Character = Identity("AAB48727-13F3-4688-B139-C3A8A7280EEB", nameof(Character));

            Corpse = Identity("F2667A5B-6730-42DD-ACDC-64E5244C6589", nameof(Corpse));

            Dye = Identity("7B879005-6070-41C4-A55C-9297CA6BC5E5", nameof(Dye));

            Backpack = Identity("32B02057-4FE8-4345-B92C-E2E5C44AD956", nameof(Backpack));

            Gold = Identity("E0E97E00-1266-4D1A-8F90-CBF40F26832B", nameof(Gold));

            RedBook = Identity("A0CB5022-A812-4B0C-B214-31A3B6B4C304", nameof(RedBook));

            Hair = Identity("FFAD623B-2E6E-4E79-B1BC-3233CBD0EAB0", nameof(Hair));

            Face = Identity("E106FDA8-87AD-449B-8A5B-48D39548EB3D", nameof(Face));

            Beard = Identity("35579838-B014-426B-BC41-47CF2F62726A", nameof(Beard));

            BodyPart = Identity("69577C62-9E52-48D3-9FD8-7BDBCE87FB4F", nameof(BodyPart));

            Container = Identity("B79E8E29-EEF0-42EC-A91F-0E6261B01171", nameof(Container));

            Item = Identity("64A01F46-4ED4-4CE2-BDD3-1D921715E931", nameof(Item));

            //Layer 1
            BookOfArms = Identity("537CAF69-1D40-4318-A4A4-2FF249FE8CC5", nameof(BookOfArms));
            BookOfBushido = Identity("D05687C7-2C67-4136-87C3-939096D6561D", nameof(BookOfBushido));
            BookOfNinjitsu = Identity("D3470C5E-D367-453B-AE9F-71AC1BB20E11", nameof(BookOfNinjitsu));
            Fukiya = Identity("1B57B597-0F7C-4642-B010-96E07FF36951", nameof(Fukiya));
            NecromancerBook = Identity("D8F20CA7-796A-4D27-8CA7-2E6C364AD86D", nameof(NecromancerBook));
            PaladinSpellbook = Identity("D7318C8B-2472-4B1C-ABF5-C76B6E46640A", nameof(PaladinSpellbook));
            Spellbook = Identity("EA1CD753-AD9E-4ECE-894B-315A2408FEF7", nameof(Spellbook));
            SpellWeavingBook = Identity("0D904638-7A52-435F-A535-D09541AAD273", nameof(SpellWeavingBook));
            AssassinSpike = Identity("4BDE62C5-3A39-4A4E-AB19-72D25479AFD6", nameof(AssassinSpike));
            BattleAxe = Identity("328B9CB9-32A1-4B29-9C0F-4512911AB7E9", nameof(BattleAxe));
            Bokuto = Identity("1EEF942C-5BB4-4BDC-A981-837D99716910", nameof(Bokuto));
            BoneHarvester = Identity("44EE3DDB-E0D1-4B07-A0BF-CDC656A07C08", nameof(BoneHarvester));
            Bow = Identity("20F4D4CF-80C7-43D0-83CD-ED9C082F912C", nameof(Bow));
            Broadsword = Identity("92A3AF08-737A-4817-B863-72EECCF33DC0", nameof(Broadsword));
            ButcherKnife = Identity("BCFD70C3-BE8F-4D45-946B-DEE0F687044E", nameof(ButcherKnife));
            Cleaver = Identity("7216C98C-4D24-4A85-89D2-944DDA0034D2", nameof(Cleaver));
            Club = Identity("9E9BFAA0-60D2-44B3-8F0C-5ECDA23CE822", nameof(Club));
            Crossbow = Identity("B278503F-B530-4600-8F19-7BD63FE626BD", nameof(Crossbow));
            Cutlass = Identity("0B4ADEB4-907A-43DE-915A-31396FCE1F2E", nameof(Cutlass));
            Dagger = Identity("2DE6FDC3-3419-4D37-8690-5CB399FDE6C9", nameof(Dagger));
            DiamondMace = Identity("E3A6B97B-27AC-41A3-93E2-55332E7481A5", nameof(DiamondMace));
            ElvenMachete = Identity("E8F31A8E-2AFB-4F0C-95A2-4A600ED171C7", nameof(ElvenMachete));
            HammerPick = Identity("0E34D5D4-94CA-4532-93A5-CC2DC343B271", nameof(HammerPick));
            HeavyCrossbow = Identity("16B62940-3991-45EA-88F1-1D039D032174", nameof(HeavyCrossbow));
            Katana = Identity("F9136D22-D042-482B-8326-88E08724B537", nameof(Katana));
            Kryss = Identity("7B6C1815-967C-4B92-BC16-9A425E06B542", nameof(Kryss));
            Lance = Identity("3B82757C-C774-4AB1-B7B7-00DEEBEBB579", nameof(Lance));
            Leafblade = Identity("D82B3E33-27D8-40E3-959F-932BB565AFA0", nameof(Leafblade));
            LizardmansMace = Identity("3553DF0A-E470-4D73-95D4-7B2A2B0EE6CD", nameof(LizardmansMace));
            Longsword = Identity("3A974C7B-670A-4405-94A3-C14CA26098F6", nameof(Longsword));
            LongSword = Identity("4A949387-691B-4561-B9C3-582127B85865", nameof(LongSword));
            Mace = Identity("71873947-C455-4A75-AC3C-BAC6A808153A", nameof(Mace));
            MagicSword = Identity("882CACCD-4B36-448A-B356-FDC10A84A6F1", nameof(MagicSword));
            Maul = Identity("E1697A9A-19DE-40FF-A619-47AEA3CE768F", nameof(Maul));
            PaladinSword = Identity("D04BD11E-32D6-4B69-AE36-BBF986B7496E", nameof(PaladinSword));
            Pick = Identity("D3E8752B-6A03-4722-B753-8B9DF771281E", nameof(Pick));
            Pickaxe = Identity("F5080060-D4B4-42CF-A8D6-4100ADF1DF81", nameof(Pickaxe));
            RadiantScimitar = Identity("46637654-2665-4376-849F-8E63550D14B0", nameof(RadiantScimitar));
            RatmanAxe = Identity("E0D4AFCD-546F-490F-82C1-F4F498690F06", nameof(RatmanAxe));
            RatmanSword = Identity("C34D5B80-EF0C-4333-9F2C-964772F4D198", nameof(RatmanSword));
            Scepter = Identity("649EA636-958F-4B13-9062-935B968E9072", nameof(Scepter));
            Scimitar = Identity("007D8F24-EB35-47D6-9BB8-72411581985D", nameof(Scimitar));
            Shortsword = Identity("3CFD8507-EAF8-4199-9279-98CF3D529901", nameof(Shortsword));
            SkeletonAxe = Identity("39D7BABD-2EB6-4DEB-87BF-0B6657FD2B60", nameof(SkeletonAxe));
            SkeletonScimitar = Identity("557521C9-F52D-4700-BFCA-9BA410A0608F", nameof(SkeletonScimitar));
            SkinningKnife = Identity("CFEBC9DB-A5D2-4038-A79D-283B270441FF", nameof(SkinningKnife));
            SledgeHammer = Identity("4A37099D-6D9A-40A3-81EF-927A12E0A92F", nameof(SledgeHammer));
            SmithsHammer = Identity("67AA0297-E352-4121-AABB-D5BDD6A19C76", nameof(SmithsHammer));
            SmythHammer = Identity("2CF69FD0-FEA6-4B53-9006-24CFCDF058EF", nameof(SmythHammer));
            Sword = Identity("86F5347B-AC72-4204-B1AE-F22824FA26E1", nameof(Sword));
            TerathanMace = Identity("65F0C276-DF81-43C0-B92C-D582600FA1F2", nameof(TerathanMace));
            VikingSword = Identity("8613C442-903D-4F21-8F26-F8DD2434FFE4", nameof(VikingSword));
            Wakizashi = Identity("169C77CB-86E4-4A5B-9D47-16FEC133684D", nameof(Wakizashi));
            Wand = Identity("3C6E4215-01C2-4065-A108-E8441D802274", nameof(Wand));
            WarAxe = Identity("DCBC67B4-DE53-4228-8991-B6E1354C916C", nameof(WarAxe));
            WarCleaver = Identity("D9BA591F-F4E3-44C2-B521-EEDE612052F7", nameof(WarCleaver));
            WarFork = Identity("6ECF94A6-08E5-492D-B607-F9F4D6C27C1A", nameof(WarFork));
            WarHammer = Identity("4B77C5FA-EFD4-478F-AE32-2A30087A2B2C", nameof(WarHammer));
            WarMace = Identity("EE91EE0C-2FCE-4AB3-A8E7-FDD15857B6F6", nameof(WarMace));
            WildStaff = Identity("E9F4B147-CC57-4970-9F38-E057EA137E0F", nameof(WildStaff));

            //Layer 2
            LightSource = Identity("8543E544-0C15-4435-A884-56FDF01E2513", nameof(LightSource));
            Axe = Identity("62A13542-C82A-4747-B8EE-1ECDE6427116", nameof(Axe));
            Bardiche = Identity("8F23AFAE-923A-4718-9510-B3D696BB1760", nameof(Bardiche));
            BlackStaff = Identity("CB49852A-FED0-40B0-B33E-1653A4FC82B4", nameof(BlackStaff));
            BladedStaff = Identity("205F9A94-0D5E-49F0-ADAE-0FE7A8853F38", nameof(BladedStaff));
            BoneMageStaff = Identity("80230051-A74D-4BDA-82B4-093BCDB52B3D", nameof(BoneMageStaff));
            BronzeShield = Identity("1F1A637D-D2F2-486B-94DD-8F4CB374D3D6", nameof(BronzeShield));
            Buckler = Identity("1EC941C1-2854-4A76-B5F0-3E168D943EB4", nameof(Buckler));
            Candle = Identity("3BCBEA3C-94B0-4E33-B8B1-5816C852A39B", nameof(Candle));
            CompositeBow = Identity("0DC1AE16-5A35-4D8A-9A76-7FD1DBB5EEE2", nameof(CompositeBow));
            CrescentBlade = Identity("6670E1A5-2435-4F45-A685-FBFAE390E017", nameof(CrescentBlade));
            Crook = Identity("267AD225-0B94-443E-8F21-1AE6F2EF709A", nameof(Crook));
            DaemonSword = Identity("1FDCB4FA-9148-42A1-A3DE-308D9E182923", nameof(DaemonSword));
            Daisho = Identity("CE6993C3-B662-433A-88E7-511F6A98A9B8", nameof(Daisho));
            DoubleAxe = Identity("EFCB0049-D6CB-4701-B9A8-1B484070EED3", nameof(DoubleAxe));
            DoubleBladedStaff = Identity("2970A231-A405-42BB-BE1A-88A7BC0A0827", nameof(DoubleBladedStaff));
            ElvenCompositeLo = Identity("D8BCD487-FC6D-4DB6-8879-DAC917A9D65E", nameof(ElvenCompositeLo));
            ElvenSpellblade = Identity("8841D194-7E87-41D7-92D1-A25C504C8D80", nameof(ElvenSpellblade));
            EttinHammer = Identity("661E2106-4BB8-4F55-B96C-B4630535AF9F", nameof(EttinHammer));
            ExecutionersAxe = Identity("E05D41BE-FCA0-4D69-8DFC-643FFDF5212E", nameof(ExecutionersAxe));
            FishingPole = Identity("70C2D357-7555-4BEF-88A9-7C9C5B7D495E", nameof(FishingPole));
            FrostTrollClub = Identity("9302166F-63AD-44BC-A0AF-DC475A77E51B", nameof(FrostTrollClub));
            GnarledStaff = Identity("DDE4D553-5142-468D-91E2-026F384244BA", nameof(GnarledStaff));
            Halberd = Identity("01477E63-AA9D-4E1B-80E8-1AC89628098D", nameof(Halberd));
            Hatchet = Identity("93261A43-42A5-4BCA-BE46-DDB9B2CC6722", nameof(Hatchet));
            HeaterShield = Identity("B2825F76-656B-4BF7-9776-2526CFD5CCF5", nameof(HeaterShield));
            HorsemansBow = Identity("AACBEC9A-702D-43B3-A30C-E0A83A42245E", nameof(HorsemansBow));
            ChaosShield = Identity("37339BD0-372F-4E65-9472-BC931804E990", nameof(ChaosShield));
            Javelin = Identity("DA7AA0BA-98C5-4214-925E-0EB5E6227F74", nameof(Javelin));
            Kama = Identity("E2461EAA-188E-4070-AC0C-D508BA99A527", nameof(Kama));
            KiteShield = Identity("AF345F63-10F3-44EE-8274-366C7CB9394E", nameof(KiteShield));
            Lajatang = Identity("0457062E-E298-4540-A4CA-D20F1C7A7462", nameof(Lajatang));
            Lantern = Identity("233BC6FA-627C-4840-B125-084B09136EF0", nameof(Lantern));
            LargeBattleAxe = Identity("567BF3EC-EBA0-4B9C-A5F9-1B0960B59054", nameof(LargeBattleAxe));
            LichesStaff = Identity("528C31DE-8BD3-433A-9DE0-A3C81DE582C5", nameof(LichesStaff));
            LizardmansSpear = Identity("DDC221C4-14F0-4B45-B391-E2EF57720F4A", nameof(LizardmansSpear));
            MagicalShortbow = Identity("220EE7E0-53F1-4284-8E38-486D425A5C68", nameof(MagicalShortbow));
            MagicStaff = Identity("2EFE5C03-D059-4439-96FF-7B682F5C4A32", nameof(MagicStaff));
            MetalShield = Identity("151628EA-274A-4E84-89F8-592CBCCDA394", nameof(MetalShield));
            Naginata = Identity("E3130C84-8DF0-4F24-A28B-60D420CA50FD", nameof(Naginata));
            NoDachi = Identity("A8F0C4D5-CA71-4A86-ACF2-05D10F25DC14", nameof(NoDachi));
            Nunchaku = Identity("FDD27469-157F-4FA3-9E84-16701EF8AAC2", nameof(Nunchaku));
            OgresClub = Identity("CDE8196D-7146-4503-9F6E-00543DB1460B", nameof(OgresClub));
            OphidianBardiche = Identity("82FFCF7E-A08D-4636-950D-A2374081CF2C", nameof(OphidianBardiche));
            OphidianStaff = Identity("3E896DD7-FE17-4EE1-9446-94A394EC25E4", nameof(OphidianStaff));
            OrcClub = Identity("1F2599E5-C0C5-4382-AB7B-7CA938CF1060", nameof(OrcClub));
            OrcLordBattleaxe = Identity("26523288-AFD4-4CCD-ABC3-A65B55231390", nameof(OrcLordBattleaxe));
            OrcMageStaff = Identity("054EA75C-907E-413A-9065-F8A3E58B1501", nameof(OrcMageStaff));
            OrderShield = Identity("D34D16DF-6265-4450-A575-7BF82B9080DA", nameof(OrderShield));
            OrnateAxe = Identity("51CFD4B8-AD96-43B2-A84C-BBE1E68E3FD6", nameof(OrnateAxe));
            Pike = Identity("6712FD96-58D2-4E14-9B31-18344CC11B2F", nameof(Pike));
            Pitchfork = Identity("94DD00B9-E52D-42F7-AFF5-CA217D9179F0", nameof(Pitchfork));
            QuarterStaff = Identity("0893BFA1-1AE2-47F4-B52E-DE21256F5521", nameof(QuarterStaff));
            RepeatingCrossbow = Identity("16F697C0-54EA-48AD-B70B-C5C7CBBA5D86", nameof(RepeatingCrossbow));
            RuneBlade = Identity("C47032AC-B53E-486E-983D-53AB2EED725F", nameof(RuneBlade));
            Sai = Identity("9F9F3BF4-6482-40D7-A3FC-E085DA840736", nameof(Sai));
            ScaleShield = Identity("3EDACE4F-2577-4D4E-B746-A40E71DB626F", nameof(ScaleShield));
            Scythe = Identity("4123EAC0-FDA7-4480-8F5F-EB9904096D53", nameof(Scythe));
            ShepherdsCrook = Identity("5CC790CD-3444-48A0-B4E5-F45A64094F62", nameof(ShepherdsCrook));
            ShortSpear = Identity("2F2815BE-6804-4012-8C4F-6950D5097379", nameof(ShortSpear));
            Spear = Identity("7638FB32-5295-49C5-8594-F3D631D1AF15", nameof(Spear));
            Tekagi = Identity("91033789-288F-46D1-89E1-4125BD15C2B7", nameof(Tekagi));
            TerathanSpear = Identity("83BDE4B1-FDBC-4E58-A1AD-7AAD452B7AB3", nameof(TerathanSpear));
            TerathanStaff = Identity("21A5A5D4-64D1-4673-9CF4-606A3E91EE58", nameof(TerathanStaff));
            Tessen = Identity("0454EBBB-319C-4AFE-AA27-0717C02605D9", nameof(Tessen));
            Tetsubo = Identity("87AD5EB8-B0A6-4D75-873D-4E2585166062", nameof(Tetsubo));
            Torch = Identity("2813B358-3A86-40BF-B7FA-E5D04EDE31C6", nameof(Torch));
            TrollAxe = Identity("349F3570-4579-45FE-9E23-02D3EE1DC53A", nameof(TrollAxe));
            TrollMaul = Identity("A46D3897-B484-460C-9BC0-77DC7D3A01C3", nameof(TrollMaul));
            TwoHandedAxe = Identity("62E4D3B4-7207-40E5-AFB3-ABB0FF955CE4", nameof(TwoHandedAxe));
            WoodenShield = Identity("EACC57DF-9CDB-4EFE-9DBC-A3093964F698", nameof(WoodenShield));
            Yumi = Identity("47CE2BB2-4DD0-41D2-BDC1-CBCD8C3402A2", nameof(Yumi));

            //Layer 3
            ArcaneThighBoots = Identity("6BFDF6F5-178B-4EAF-87D5-C292477E7D6E", nameof(ArcaneThighBoots));
            Boots = Identity("84381C46-2B79-42EE-83F6-88378C047618", nameof(Boots));
            ElvenBoot = Identity("B99210A4-F820-4108-9095-CDAD57613FAD", nameof(ElvenBoot));
            FurBoots = Identity("8B2C259F-C0D2-4328-AFD4-A2BABAE759E0", nameof(FurBoots));
            JesterShoes = Identity("0620CC7C-A5A6-48D4-A7DE-8FBCEE7CEAFA", nameof(JesterShoes));
            NinjaTallTabi = Identity("F95A8AA8-C1FE-435D-A69D-A84586E2FEBC", nameof(NinjaTallTabi));
            SamuraiSandalTabi = Identity("1C79463B-A65A-437D-ACCE-C843454007FA", nameof(SamuraiSandalTabi));
            SamuraiWarajiTa = Identity("CE619472-CBCE-4F17-AC08-5E0853BAEB87", nameof(SamuraiWarajiTa));
            Sandals = Identity("2ED6ED99-0BB7-4A71-BD2E-F487A5700854", nameof(Sandals));
            SimpleShoes = Identity("68B41F0B-02C9-4312-9F88-1636BB3ECEEA", nameof(SimpleShoes));
            TabiBootsTall = Identity("2D7A3BDA-4664-48BA-A540-909C8DF0DF42", nameof(TabiBootsTall));
            ThighBoots = Identity("38385BEB-8B00-41EF-BE1E-42A9DF8FD214", nameof(ThighBoots));
            Waraji = Identity("243B2129-6BB7-4D4A-A1E4-E2D2746A7CD2", nameof(Waraji));

            //Layer 4
            ShortPants = Identity("3CD8FBA0-5183-4AF8-975E-86CAA6A82C4E", nameof(ShortPants));
            BoneLeggings = Identity("054969CC-6834-44F1-81D3-1ABF1EB0899D", nameof(BoneLeggings));
            BoneLegs = Identity("F5555E62-5FDC-461A-B40C-AD0A06337605", nameof(BoneLegs));
            DragonLeggings = Identity("40809D5A-59DB-4965-9F1E-ACFB6FC44D69", nameof(DragonLeggings));
            ElvenPants = Identity("7A0D4D7B-3726-406A-9193-A07660A78025", nameof(ElvenPants));
            ElvenPlateLegs = Identity("20244ED7-F120-4C0F-AA55-B137D1D27993", nameof(ElvenPlateLegs));
            Haidate = Identity("8C23A872-FF24-453C-A05C-BBCB65791A42", nameof(Haidate));
            HidePants = Identity("9651EC97-044E-4334-A61B-2A4BA60F6535", nameof(HidePants));
            ChainmailLeggings = Identity("C227AAD2-6ACC-4661-BBB1-B6A468EB5997", nameof(ChainmailLeggings));
            JesterPants = Identity("0E2AE1D3-8976-4D79-BCAD-A80FBCC01C13", nameof(JesterPants));
            Kobakama = Identity("788A276B-0254-4D7C-A001-005594520219", nameof(Kobakama));
            LeatherHaidate = Identity("6FEABFDD-ED17-4E81-B954-2E9BD94DC0C7", nameof(LeatherHaidate));
            LeatherLeggings = Identity("D7D2668F-D79D-459F-B20C-ABAD9E42CD26", nameof(LeatherLeggings));
            LeatherNinjaPants = Identity("8571F4DB-90F9-4199-BA99-84D251F1DFCE", nameof(LeatherNinjaPants));
            LeatherShorts = Identity("077E3F98-B27D-4484-A30F-CA393E774F07", nameof(LeatherShorts));
            LeatherSkirt = Identity("4D654D46-2202-4817-B75A-B9CD862BE5A1", nameof(LeatherSkirt));
            LeatherSuneate = Identity("6C4B1002-3F55-4B65-BEBD-89EFA3AFC912", nameof(LeatherSuneate));
            LongPants = Identity("DE723900-1B22-4E0F-912A-55843FDA4873", nameof(LongPants));
            LtArmorKilt = Identity("18CFEC53-99E5-4DCF-BEBF-E5E6F0E4AFFE", nameof(LtArmorKilt));
            LtArmorPants = Identity("69665D64-FAA3-4BBD-8605-550E4326523A", nameof(LtArmorPants));
            MailHaidate = Identity("897DC510-75B1-4BE1-92D6-73BB99BE8A92", nameof(MailHaidate));
            NinjaPants = Identity("A45EB6A9-965C-4F31-A294-4269449D81CD", nameof(NinjaPants));
            PlateHaidate = Identity("CF9C59C6-0DB6-4FE9-8067-78EA302E8384", nameof(PlateHaidate));
            PlatemailLegs = Identity("768FFF70-9E2D-43EB-8E07-93026BF77399", nameof(PlatemailLegs));
            PlateSuneate = Identity("00B9EB90-05E3-4CC3-9C17-C6491774E65C", nameof(PlateSuneate));
            RingmailLeggings = Identity("263E6884-8BEB-461D-A33A-A015A271E6F4", nameof(RingmailLeggings));
            SpikedShorts = Identity("E486EBC6-EF6E-4B04-9F15-192A8D277AE4", nameof(SpikedShorts));
            StuddedHaidate = Identity("0328EB81-3642-4B8B-A0AB-9CE343AE6214", nameof(StuddedHaidate));
            StuddedLeggings = Identity("560988D3-9B1B-4204-9340-FC5A2744E7EE", nameof(StuddedLeggings));
            StuddedSuneate = Identity("906EAC6E-C7AD-437E-A4B5-B708AB9E7A26", nameof(StuddedSuneate));
            TattsukeHakama = Identity("B7EA4965-291A-4AD0-A80D-A29B7D7A1222", nameof(TattsukeHakama));

            //Layer 5
            AmazonArmor = Identity("E2BD435C-20CF-4D00-8BE5-DEF752F9BB77", nameof(AmazonArmor));
            AmazonHarness = Identity("0EFFBE03-60BF-4CD2-95D0-59B380DA0B76", nameof(AmazonHarness));
            EliteHarness = Identity("9980E58C-8057-40BA-B6C9-CA3F18B45665", nameof(EliteHarness));
            ElvenShirt = Identity("2747B65E-F99C-4195-8E03-7DD6674BEDBD", nameof(ElvenShirt));
            Elvenshirt1Male = Identity("A672CE50-DD6B-4C24-8024-C1F02D511BB9", nameof(Elvenshirt1Male));
            Elvenshirt2Male = Identity("A1A295D9-C296-4E0C-ACC0-E698919F4293", nameof(Elvenshirt2Male));
            ElvenShirtMale = Identity("596BDDF1-228E-420E-B232-79951E4E673A", nameof(ElvenShirtMale));
            FancyShirt = Identity("AC588345-DD55-4C04-9976-E6809EB2E1A0", nameof(FancyShirt));
            Fshirt1Chest = Identity("356AEFCF-B09D-41AB-A373-7AF6FC6A7E3D", nameof(Fshirt1Chest));
            Fshirt2Chest = Identity("8959083C-57B7-4294-9DD5-100EA40E9045", nameof(Fshirt2Chest));
            CheckeredShirt = Identity("6A263682-19A0-4D0D-9266-39E406D592E9", nameof(CheckeredShirt));
            NinjaShirt = Identity("E7057412-3D92-43C3-BD83-657BCD8DFB42", nameof(NinjaShirt));
            SimpleShirt = Identity("57E1A175-B260-49AD-A8C1-1FFE514ABB35", nameof(SimpleShirt));

            //Layer 6
            Bandana = Identity("C52BA63D-4CCC-4931-A1AF-EB8C4524D64F", nameof(Bandana));
            Bascinet = Identity("E3044E8F-2C23-4853-9167-BCC1A9912DD4", nameof(Bascinet));
            BearMask = Identity("6DB47289-79BC-4F9B-8F91-F7FE7EF88F85", nameof(BearMask));
            BoneHelmet = Identity("7A0371B7-A782-4CB7-9CF9-112DE862B3BC", nameof(BoneHelmet));
            Bonnet = Identity("6683126D-D9D6-4208-9D91-A38ED5CA269A", nameof(Bonnet));
            Cap = Identity("412613DB-47D5-4193-8448-D3275EC8976A", nameof(Cap));
            Circlet = Identity("D848A850-E985-4F80-A468-3E67F41F0E49", nameof(Circlet));
            Circlet1 = Identity("CAE8ED90-74B1-447D-8983-96735204B497", nameof(Circlet1));
            Circlet2 = Identity("DCA27D50-8A40-4598-BDF6-CFCF7BD4B931", nameof(Circlet2));
            Circlet3 = Identity("9F629A52-E394-48F8-B8C1-91F5EB5CF6C1", nameof(Circlet3));
            CloseHelm = Identity("BA1AC147-F45B-477E-AB56-7C0807560354", nameof(CloseHelm));
            CloseHelmet = Identity("3FABF2FC-AC28-429F-8098-72B97F051CD3", nameof(CloseHelmet));
            DeerMask = Identity("7C9FE7BE-CF28-44F8-B01C-BE7E3FD5BFC0", nameof(DeerMask));
            DragonHelm = Identity("C1DD9ACA-2D37-40DD-8BF6-FC43A96E38C7", nameof(DragonHelm));
            ElvenGlasses = Identity("0BFD9A50-33A0-47DB-8E91-314D06DF9397", nameof(ElvenGlasses));
            FeatheredHat = Identity("EA74CDA0-ACAB-461B-B461-9A47A06DC9F9", nameof(FeatheredHat));
            FeatheredMask = Identity("18F5645F-E2BD-4581-85C9-10D5A42D3490", nameof(FeatheredMask));
            FloppyHat = Identity("E5AEA880-384C-426E-B671-4DC1F8C36BAC", nameof(FloppyHat));
            FlowerGarland = Identity("A1D9B39E-989E-499D-88BD-43116D10E571", nameof(FlowerGarland));
            GemmedCirclet = Identity("123EA7DF-3B71-476E-B407-7FC1151150A8", nameof(GemmedCirclet));
            Hachimaki = Identity("00B59509-A829-45DE-8876-28975A301E23", nameof(Hachimaki));
            Helmet = Identity("83A5F2DB-F92F-4A5E-B7CC-0E49DE29CCFA", nameof(Helmet));
            ChainmailCoif = Identity("DE0FADD2-E998-4EBF-B78A-0FBB9078CAF3", nameof(ChainmailCoif));
            JesterHat = Identity("2B174A35-3674-456D-A213-7BA4913F933F", nameof(JesterHat));
            JestersCap = Identity("E3B302DE-568D-4771-AFED-9412E9D843C5", nameof(JestersCap));
            Kabuto = Identity("CAA0EC34-5E51-420E-A471-45B2F40889A0", nameof(Kabuto));
            KabutoMempo = Identity("EFE74F9C-C236-4665-B393-FB9BB43D1520", nameof(KabutoMempo));
            Kasa = Identity("9985CD11-7AB1-4C11-95ED-125DE8780BB8", nameof(Kasa));
            LeatherCap = Identity("BD26EF2D-AD85-4DDB-8AA7-2D5861B963DE", nameof(LeatherCap));
            LeatherJingasa = Identity("B86BF4D1-552A-4720-9C28-F6363D3245BD", nameof(LeatherJingasa));
            LeatherNinjaHood = Identity("4046EFFF-ECA5-4A27-BFDD-6DE32B906988", nameof(LeatherNinjaHood));
            MailHatsuburi = Identity("E4E66594-001C-498C-A5D8-CE5292DB461F", nameof(MailHatsuburi));
            MElvenGlasses = Identity("AD33AF93-CFD8-49C9-86E8-E41CC342E335", nameof(MElvenGlasses));
            NinjaMask = Identity("F953851C-8A4C-46AB-B627-3FECDCD81C58", nameof(NinjaMask));
            NorseHelm = Identity("AE761046-0BD0-4B0E-A7BE-E933024E35AF", nameof(NorseHelm));
            OrcHelm = Identity("0387AFA4-A72F-41A7-AB20-3401A1C9C50A", nameof(OrcHelm));
            OrcMask = Identity("58C47072-EB9C-4934-9A6D-2705B6729DAE", nameof(OrcMask));
            PlateHatsuburi = Identity("F02C51E6-0B30-4062-BB89-E995A56C83CD", nameof(PlateHatsuburi));
            PlateHelm = Identity("0C928F6A-C8F6-4736-A35B-662A8448D71A", nameof(PlateHelm));
            PlateJingasa = Identity("588ED4AE-B89C-4085-9BE0-696441DBEEFA", nameof(PlateJingasa));
            PlateKabuto = Identity("47ECEAA3-8679-4A53-B1B0-2197B387D3E2", nameof(PlateKabuto));
            RavenHelm = Identity("7BA25C19-894B-4465-B3ED-AEB2B01848A1", nameof(RavenHelm));
            RobinHoodCap = Identity("4F85E908-5264-4356-AD6B-10FBBEBBD431", nameof(RobinHoodCap));
            RoyalCirclet = Identity("A9BE9AE1-55FE-4D66-AB91-3E3660C7028E", nameof(RoyalCirclet));
            Skullcap = Identity("5AA967A5-4E65-4B4F-B285-1AF2CC3083D6", nameof(Skullcap));
            StrawHat = Identity("FFE35FE1-FE41-492E-AD22-B9CFAF30F19C", nameof(StrawHat));
            TallStrawHat = Identity("F0174A43-C1E6-4E91-B816-51472F304037", nameof(TallStrawHat));
            TribalMask = Identity("30175651-029B-4D8F-AEBD-45F42F5F1328", nameof(TribalMask));
            TricorneHat = Identity("3EFD637F-5A70-4380-A441-F915FC4D6906", nameof(TricorneHat));
            VultureHelm = Identity("BC3FFF54-CDDE-49DE-8D85-AF94D1450DC5", nameof(VultureHelm));
            WideBrimHat = Identity("B5B03EFF-6D19-48C1-B521-1070C8180977", nameof(WideBrimHat));
            WingedHelm = Identity("A4F81A0A-33DD-4F58-A99A-35D3C02B056E", nameof(WingedHelm));
            WingedHelmet = Identity("388F02DB-4AA1-4E4D-B1E5-241B86FBD006", nameof(WingedHelmet));
            WizardsHat = Identity("1A9BC1C5-C6E9-4BEE-AB2E-C5C3355BE3AC", nameof(WizardsHat));

            //Layer 7
            ArcaneGloves = Identity("A17EACBF-180B-47BA-9F0C-4491057079CC", nameof(ArcaneGloves));
            BoneGloves = Identity("A831F284-48DC-4401-B783-CFB148ABE00F", nameof(BoneGloves));
            DragonGloves = Identity("2BDF2917-5955-4802-8281-49F9E096E687", nameof(DragonGloves));
            ElvenPlateGloves = Identity("3E15E841-C4CC-433A-A10D-F520797FF471", nameof(ElvenPlateGloves));
            HideGloves = Identity("ADF24FAC-964E-4551-840E-7634F7DE2820", nameof(HideGloves));
            KoteGloves = Identity("842F6EF9-4E9C-42FA-9872-F9EDAAF57CCE", nameof(KoteGloves));
            LeatherGloves = Identity("6CFFDB42-0C32-47CC-A0D8-B669E6B9BBC5", nameof(LeatherGloves));
            LeatherNinjaMitts = Identity("DFD7CDE2-A644-4E53-B404-30A2BB56B6BE", nameof(LeatherNinjaMitts));
            LtArmorGloves = Identity("071D5504-1EC9-414E-A33B-450205DC4C00", nameof(LtArmorGloves));
            PlatemailGloves = Identity("3303FDC4-CD46-4117-A53E-DD5D64435E3C", nameof(PlatemailGloves));
            RingmailGloves = Identity("000D086B-6401-462F-9E22-A031CCA0F043", nameof(RingmailGloves));
            StuddedGloves = Identity("0BB12BF4-49AD-468C-8F95-CA50310F30F5", nameof(StuddedGloves));

            //Layer 8
            Ring = Identity("8BB9EB62-7BFA-429F-A232-BB85713B09C3", nameof(Ring));

            //Layer 9
            Talisman = Identity("118C4A23-8EA3-4155-86D8-3E5A58279976", nameof(Talisman));

            //Layer 10
            BeadNecklace = Identity("4AF5098F-5144-4ABB-A78B-44D3A7825E4E", nameof(BeadNecklace));
            ElvenPlateGorget = Identity("3F99FC8A-A306-4B10-B67F-B1FFF7B6B8E7", nameof(ElvenPlateGorget));
            HideGorget = Identity("18EE1574-3D28-488D-8ED9-26458036124A", nameof(HideGorget));
            LeatherGorget = Identity("C9407F7D-8DCF-42EE-A24E-45B93F234188", nameof(LeatherGorget));
            LeatherMempo = Identity("186E278D-BAB9-4C18-8909-1E217C04FFB0", nameof(LeatherMempo));
            LtArmorGorget = Identity("A0E9B8AD-776A-4B42-8760-1A2A5437DFE3", nameof(LtArmorGorget));
            Necklace = Identity("78190AB6-EA5D-48DC-B55A-376F266F3458", nameof(Necklace));
            PlateGorget = Identity("62874012-5EF6-4C35-B7D5-237BF4693CCE", nameof(PlateGorget));
            PlatemailGorget = Identity("F60AC46E-A406-4F57-875C-CA5AC82D92D3", nameof(PlatemailGorget));
            PlateMempo = Identity("991F3963-5968-43D7-899C-08C003B918BA", nameof(PlateMempo));
            SilverNecklace = Identity("39C5875D-60B4-42ED-9957-E47F91D38CA4", nameof(SilverNecklace));
            StuddedGorget = Identity("12641057-BCA0-4813-ACA0-E86D3D77FC31", nameof(StuddedGorget));
            StuddedMempo = Identity("A863FE9E-5D96-4C41-B718-170F3408DA4D", nameof(StuddedMempo));

            //Layer 12
            ElvenPlateBelt = Identity("CB5B31D4-2225-4FB4-A01F-A2B7BA1A8C6C", nameof(ElvenPlateBelt));
            HalfApron = Identity("CFE153C1-B5C4-4539-987A-E621FF6F0573", nameof(HalfApron));
            LeatherNinjaBelt = Identity("1D00D802-193E-4CB8-B983-64E4314A5183", nameof(LeatherNinjaBelt));
            Obi = Identity("0440006C-88B5-476A-915C-967E8DC6B1E3", nameof(Obi));
            WoodlandBelt = Identity("CDD7CBC1-F62E-4990-BD15-0479D6AB006C", nameof(WoodlandBelt));

            //Layer 13
            BoneArmor = Identity("F6EE04F3-5230-4BC3-AE25-D4430CC6B2E1", nameof(BoneArmor));
            ClothNinjaJacket = Identity("4123968D-51AF-4F9B-BF5F-BA880A2589B8", nameof(ClothNinjaJacket));
            DoMaru = Identity("301B6A0C-B7FE-4865-8F79-29A94CE9D4E4", nameof(DoMaru));
            DragonBreastplate = Identity("BDA2ECD3-65B2-4751-80FB-653FC9DD0248", nameof(DragonBreastplate));
            ElvenPlate = Identity("0146E0BF-A7A5-4F14-B489-B2FD6D52B9D1", nameof(ElvenPlate));
            HaramakiDoChest = Identity("53965D45-98FD-4D9F-8C0B-97DEE456BEA8", nameof(HaramakiDoChest));
            HideFemaleChest = Identity("7575E0E3-6656-4401-8D8F-E9C9E38196A3", nameof(HideFemaleChest));
            HideChest = Identity("9FA5117C-91F7-48BA-BAB6-1D6C49CB2E70", nameof(HideChest));
            ChainmailTunic = Identity("4196A02C-321E-4C02-9AEA-89ABBDF80798", nameof(ChainmailTunic));
            LeatherArmor = Identity("C442A974-8F0A-4DB4-8B6F-BAA518B00859", nameof(LeatherArmor));
            LeatherBustier = Identity("5510C983-61A4-4B86-AF91-CE0493DC9D32", nameof(LeatherBustier));
            LeatherDo = Identity("6354004E-8E5D-4E51-BB58-963687DBB4DF", nameof(LeatherDo));
            LeatherNinjaJacke = Identity("307956AD-E286-4576-A1DC-5F26A96F1757", nameof(LeatherNinjaJacke));
            LeatherTunic = Identity("8E827287-0619-4C51-8AB3-AF94EC055861", nameof(LeatherTunic));
            LtArmorChest = Identity("A93380C2-24C8-4D43-94D1-B1C4A2D4CF42", nameof(LtArmorChest));
            LtfChest = Identity("CE5E5957-068D-4125-AFA5-FE4E0F801CE1", nameof(LtfChest));
            NinjaJacket = Identity("4375F21E-D4F0-4717-BF4C-0B716CE7FEC3", nameof(NinjaJacket));
            PlateArmor = Identity("C3F68BF1-3977-494D-A660-3F0853BF2815", nameof(PlateArmor));
            PlateDo = Identity("022F35E7-67A0-41C8-9E37-055DB08646B3", nameof(PlateDo));
            Platemail = Identity("4EA48FEB-F188-4BB7-A4AE-9B4679364726", nameof(Platemail));
            RingmailTunic = Identity("CC4B8A13-7297-4B6E-BB83-885F48217EC3", nameof(RingmailTunic));
            StuddedArmor = Identity("42DD61F0-2489-4EBE-8E63-1B9E7ED6F5C4", nameof(StuddedArmor));
            StuddedBustier = Identity("3CCAD50D-360B-40B1-9751-D2875F54F204", nameof(StuddedBustier));
            StuddedDo = Identity("E77095E2-E3AC-4A0F-A003-321DD6F189C9", nameof(StuddedDo));
            StuddedTunic = Identity("49C8D65F-0438-411F-8425-8294D9A7A0D2", nameof(StuddedTunic));
            WoodlandBreastplat = Identity("7C05A929-F229-40EB-82A2-B1017CB64BD0", nameof(WoodlandBreastplat));

            //Layer 14
            Bracelet = Identity("C26C072C-0825-4975-A4D6-11C7EE4C23F6", nameof(Bracelet));

            //Layer 17
            BodySash = Identity("93264884-C7D1-4B7E-8828-198CB9C5E7C1", nameof(BodySash));
            Doublet = Identity("FB9F4539-AB56-4654-AC00-A2B7C2F869EC", nameof(Doublet));
            FormalShirt = Identity("02F0B2B2-0E48-4FD2-A20B-7408C6202374", nameof(FormalShirt));
            FullApron = Identity("6A479111-6A1C-460A-BE83-7A901D72BEB4", nameof(FullApron));
            JesterSuit = Identity("F3A2B286-1701-417C-800D-85DDC3490011", nameof(JesterSuit));
            JinBaori = Identity("C60791D7-0B92-4FA3-9605-AB7F6F6D3ED3", nameof(JinBaori));
            Surcoat = Identity("8CCA8CFA-530C-4755-9912-B6DFE33A9F48", nameof(Surcoat));
            Tunic = Identity("048E3565-DAAF-4EF8-B173-A5DE8F120CE8", nameof(Tunic));

            //Layer 18
            Earrings = Identity("08193388-D264-4E38-92C2-8989AE5E747A", nameof(Earrings));

            //Layer 19
            BoneArms = Identity("93472DFC-8958-42AC-B62A-03EFB668E63F", nameof(BoneArms));
            DragonSleeves = Identity("E41345BE-5F14-4812-9A07-30D130473D18", nameof(DragonSleeves));
            ElvenArmPlate = Identity("58DA250F-6395-4CC0-8371-F5403EC2BDCD", nameof(ElvenArmPlate));
            HaramakiDoArms = Identity("968567D7-1353-4D97-9A00-B4C5942956F4", nameof(HaramakiDoArms));
            HidePaldrons = Identity("166EDB45-02DF-41D4-AEFA-EABEAD14A73F", nameof(HidePaldrons));
            KoteSleeves = Identity("58F6FCC3-A9D7-471E-AD3B-82999E4B13C0", nameof(KoteSleeves));
            LeatherSleeves = Identity("2B76F627-3D15-4C26-AEB7-1AC4A276A9D0", nameof(LeatherSleeves));
            LtArmorPaldrons = Identity("792ED632-420C-464E-AEE4-992F035858F2", nameof(LtArmorPaldrons));
            PlatemailArms = Identity("68B44222-B85F-4BCF-BB87-C8F0F2784B9A", nameof(PlatemailArms));
            RingmailSleeves = Identity("6DB58AD5-A12A-4BE5-B59A-BF8433A6F34D", nameof(RingmailSleeves));
            SamuraiArmorArms = Identity("A5BFE8A2-AF5F-480B-9F9D-8CA532920073", nameof(SamuraiArmorArms));
            StuddedSleeves = Identity("CCE285F8-A5C6-4423-BC03-B4F8242726DE", nameof(StuddedSleeves));

            //Layer 20
            ArcaneCloak = Identity("D64940B7-7DF9-4340-9824-48791522B876", nameof(ArcaneCloak));
            ElvenQuiver = Identity("06F0604A-68E9-4E29-BC83-08C4103C0210", nameof(ElvenQuiver));
            FurCape = Identity("E9C3EE53-4F98-438E-A4A1-769D5D6009FA", nameof(FurCape));
            MElvenQuiver = Identity("0295F027-FAE1-4FB6-B21D-0DDF20A1B9C0", nameof(MElvenQuiver));
            SimpleCloak = Identity("B37936E1-544A-4C94-BEC7-EFD967098084", nameof(SimpleCloak));

            //Layer 22
            DeathShroud = Identity("E4DECD86-15D5-4E16-AC14-93392CC64CC9", nameof(DeathShroud));
            GmRobe = Identity("957EB8EC-2E5A-48B3-A1D8-AAAF18EFC473", nameof(GmRobe));
            HoodedShroud = Identity("E54DF3F5-0178-4308-B9FC-D55706A23008", nameof(HoodedShroud));
            ArcaneRobe = Identity("0C8F8D8F-B0E2-4474-95CA-576DBD357D16", nameof(ArcaneRobe));
            ElvenRobe = Identity("DC5A69EF-4F92-4105-ADD1-91522F81A73B", nameof(ElvenRobe));
            FancyDress = Identity("183B88AF-E35F-42F8-AD15-07DC61B6A452", nameof(FancyDress));
            FemaleKimono = Identity("3F0FBF6B-DE19-4CA5-9002-7EAA3BFB65D3", nameof(FemaleKimono));
            GildedDress = Identity("E325DE3E-7F28-442D-97DA-B6D142C0BBC5", nameof(GildedDress));
            HakamaShita = Identity("67FF180E-0505-4514-A92F-6622D3314ED1", nameof(HakamaShita));
            Kamishimo = Identity("81095C85-3694-4D8A-AD75-902BF93056B1", nameof(Kamishimo));
            Kimono = Identity("529D7523-745D-4EE1-9435-6A9DAE0960F9", nameof(Kimono));
            KimonoFemaleDres = Identity("C923A5AB-F9D8-49F1-91F1-AD2AC7666343", nameof(KimonoFemaleDres));
            KimonoMaleDress = Identity("BBDC57DC-7588-4EA1-AF88-1C6784BF42D1", nameof(KimonoMaleDress));
            LongDress = Identity("AC5ED5E1-55A2-430F-93C6-F9B78638D8EA", nameof(LongDress));
            MaleKimono = Identity("B8C30B48-9810-4BED-A6C9-A74C42C14715", nameof(MaleKimono));
            MElvenRobe01 = Identity("9FA2D333-EA2C-4845-A79B-F8DE1CE3F297", nameof(MElvenRobe01));
            MElvenRobe02 = Identity("0B905819-525B-4845-BA92-D8705A24F967", nameof(MElvenRobe02));
            PlainDress = Identity("659A69D8-808B-4128-8CAF-248AE429EC34", nameof(PlainDress));
            Robe = Identity("4A979C9C-26A0-4D26-B8F2-5C440D128ED1", nameof(Robe));

            //Layer 23
            FurSurong = Identity("FB0641F8-46A9-4E97-BD5B-1EC796585AB2", nameof(FurSurong));
            Hakama = Identity("DA280A62-3181-4AAF-B46A-E60F529B41C5", nameof(Hakama));
            Kilt = Identity("3A1E417D-FC3F-43FB-BBC0-6A010F8C32EE", nameof(Kilt));
            KneeSkirt = Identity("6AD2593A-31E4-42FE-BB77-069DC3C2FC2A", nameof(KneeSkirt));
            SimpleSkirt = Identity("1E1F08C9-EFFF-4B05-96E6-1590A3EABC23", nameof(SimpleSkirt));

            OneHand = Identity("144A2524-891D-42F9-B697-0320FBDA9108", nameof(OneHand));
            TwoHand = Identity("63E69437-193B-427A-B30B-C543E6F1A68D", nameof(TwoHand));
            Shoes = Identity("F48D9C3E-C7C7-487A-961F-E57E7428A37B", nameof(Shoes));
            Pants = Identity("A996F30D-8515-424C-A22B-119F715A243B", nameof(Pants));
            Shirt = Identity("49DD7DD3-C612-420E-AE60-E9490E31F813", nameof(Shirt));
            Hat = Identity("889C3BE4-7768-4AF9-83A4-566EFFDFB17C", nameof(Hat));
            Gloves = Identity("4A8DA128-06A3-484E-B479-A0029F92717F", nameof(Gloves));
            Gorget = Identity("E9AE1602-BAF7-4413-B054-0C9A6A8E49D6", nameof(Gorget));
            Belt = Identity("C4BF5BFF-4EFE-447B-BFF4-6F9AE658B813", nameof(Belt));
            Chest = Identity("1A0E313F-8179-442B-B056-3D0AA654E4E4", nameof(Chest));
            Sash = Identity("2CCF53F5-E1A0-469D-872D-E93E4FC1FF31", nameof(Sash));
            Arms = Identity("540A75AF-215D-46BB-8B0C-1E8BBD6098AF", nameof(Arms));
            Cloak = Identity("142897AA-5554-4B91-9C1A-B11FD19342A7", nameof(Cloak));
            Dress = Identity("543D733A-74D3-4EC1-B850-AD8C851DE5DC", nameof(Dress));
            Skirt = Identity("9AEA0292-A1F7-4218-B718-0171F96A1603", nameof(Skirt));

            Warrior = Identity("6600C3FE-C764-4CDC-BCB0-88BB96521652", nameof(Warrior));
            Mage = Identity("AC2943ED-F36F-48F4-B38F-BF08082B1C2C", nameof(Mage));
            Blacksmith = Identity("B0D05D17-8194-46EF-A560-7459A81669AE", nameof(Blacksmith));
            Paladin = Identity("D46FBF23-F909-40EE-8052-44821B589082", nameof(Paladin));
            Necromancer = Identity("AE5ECA66-5361-4B9C-AF45-8B4F693B2956", nameof(Necromancer));
            Samurai = Identity("EEE5119F-141F-47A7-B93A-D0F0B75150EB", nameof(Samurai));
            Ninja = Identity("412F8D09-6BA2-4D18-8FEA-56D024B66A2F", nameof(Ninja));
            CustomProfession = Identity("E9367A15-B3DC-4E30-9BCB-88A418855EE0", nameof(CustomProfession));

            IdentityTree = BuildTree(new[]
            {
                (Human, Male),
                (Human, Female),
                (Elf, Male),
                (Elf, Female),

                (Humanoid, Human),
                (Humanoid, Elf),
                (Ghost, Human),
                (Ghost, Elf),

                (Warrior, Humanoid),
                (Mage, Humanoid),
                (Blacksmith, Humanoid),
                (Paladin, Humanoid),
                (Necromancer, Humanoid),
                (Samurai, Humanoid),
                (Ninja, Humanoid),
                (CustomProfession, Humanoid),

                (Character, Warrior),
                (Character, Mage),
                (Character, Blacksmith),
                (Character, Paladin),
                (Character, Necromancer),
                (Character, Samurai),
                (Character, Ninja),
                (Character, CustomProfession),

                (Mobile, Bandit),
                (Mobile, Ghost),
                (Mobile, Character),

                (Face, Humanoid),
                (Hair, Humanoid),
                (Beard, Human),

                (BodyPart, Hair),
                (BodyPart, Face),
                (BodyPart, Beard),
                (Container, Backpack),


                //Layer 1
                (Item, BookOfArms),
                (Item, BookOfBushido),
                (Item, BookOfNinjitsu),
                (Item, Fukiya),
                (Item, NecromancerBook),
                (Item, PaladinSpellbook),
                (Item, Spellbook),
                (Item, SpellWeavingBook),
                (OneHand, AssassinSpike),
                (OneHand, BattleAxe),
                (OneHand, Bokuto),
                (OneHand, BoneHarvester),
                (OneHand, Bow),
                (OneHand, Broadsword),
                (OneHand, ButcherKnife),
                (OneHand, Cleaver),
                (OneHand, Club),
                (OneHand, Crossbow),
                (OneHand, Cutlass),
                (OneHand, Dagger),
                (OneHand, DiamondMace),
                (OneHand, ElvenMachete),
                (OneHand, HammerPick),
                (OneHand, HeavyCrossbow),
                (OneHand, Katana),
                (OneHand, Kryss),
                (OneHand, Lance),
                (OneHand, Leafblade),
                (OneHand, LizardmansMace),
                (OneHand, Longsword),
                (OneHand, LongSword),
                (OneHand, Mace),
                (OneHand, MagicSword),
                (OneHand, Maul),
                (OneHand, PaladinSword),
                (OneHand, Pick),
                (OneHand, Pickaxe),
                (OneHand, RadiantScimitar),
                (OneHand, RatmanAxe),
                (OneHand, RatmanSword),
                (OneHand, Scepter),
                (OneHand, Scimitar),
                (OneHand, Shortsword),
                (OneHand, SkeletonAxe),
                (OneHand, SkeletonScimitar),
                (OneHand, SkinningKnife),
                (OneHand, SledgeHammer),
                (OneHand, SmithsHammer),
                (OneHand, SmythHammer),
                (OneHand, Sword),
                (OneHand, TerathanMace),
                (OneHand, VikingSword),
                (OneHand, Wakizashi),
                (OneHand, Wand),
                (OneHand, WarAxe),
                (OneHand, WarCleaver),
                (OneHand, WarFork),
                (OneHand, WarHammer),
                (OneHand, WarMace),
                (OneHand, WildStaff),

                //Layer 2
                (Item, LightSource),
                (TwoHand, Axe),
                (TwoHand, Bardiche),
                (TwoHand, BlackStaff),
                (TwoHand, BladedStaff),
                (TwoHand, BoneMageStaff),
                (TwoHand, BronzeShield),
                (TwoHand, Buckler),
                (TwoHand, Candle),
                (TwoHand, CompositeBow),
                (TwoHand, CrescentBlade),
                (TwoHand, Crook),
                (TwoHand, DaemonSword),
                (TwoHand, Daisho),
                (TwoHand, DoubleAxe),
                (TwoHand, DoubleBladedStaff),
                (TwoHand, ElvenCompositeLo),
                (TwoHand, ElvenSpellblade),
                (TwoHand, EttinHammer),
                (TwoHand, ExecutionersAxe),
                (TwoHand, FishingPole),
                (TwoHand, FrostTrollClub),
                (TwoHand, GnarledStaff),
                (TwoHand, Halberd),
                (TwoHand, Hatchet),
                (TwoHand, HeaterShield),
                (TwoHand, HorsemansBow),
                (TwoHand, ChaosShield),
                (TwoHand, Javelin),
                (TwoHand, Kama),
                (TwoHand, KiteShield),
                (TwoHand, Lajatang),
                (TwoHand, Lantern),
                (TwoHand, LargeBattleAxe),
                (TwoHand, LichesStaff),
                (TwoHand, LizardmansSpear),
                (TwoHand, MagicalShortbow),
                (TwoHand, MagicStaff),
                (TwoHand, MetalShield),
                (TwoHand, Naginata),
                (TwoHand, NoDachi),
                (TwoHand, Nunchaku),
                (TwoHand, OgresClub),
                (TwoHand, OphidianBardiche),
                (TwoHand, OphidianStaff),
                (TwoHand, OrcClub),
                (TwoHand, OrcLordBattleaxe),
                (TwoHand, OrcMageStaff),
                (TwoHand, OrderShield),
                (TwoHand, OrnateAxe),
                (TwoHand, Pike),
                (TwoHand, Pitchfork),
                (TwoHand, QuarterStaff),
                (TwoHand, RepeatingCrossbow),
                (TwoHand, RuneBlade),
                (TwoHand, Sai),
                (TwoHand, ScaleShield),
                (TwoHand, Scythe),
                (TwoHand, ShepherdsCrook),
                (TwoHand, ShortSpear),
                (TwoHand, Spear),
                (TwoHand, Tekagi),
                (TwoHand, TerathanSpear),
                (TwoHand, TerathanStaff),
                (TwoHand, Tessen),
                (TwoHand, Tetsubo),
                (TwoHand, Torch),
                (TwoHand, TrollAxe),
                (TwoHand, TrollMaul),
                (TwoHand, TwoHandedAxe),
                (TwoHand, WoodenShield),
                (TwoHand, Yumi),

                //Layer 3
                (Shoes, ArcaneThighBoots),
                (Shoes, Boots),
                (Shoes, ElvenBoot),
                (Shoes, FurBoots),
                (Shoes, JesterShoes),
                (Shoes, NinjaTallTabi),
                (Shoes, SamuraiSandalTabi),
                (Shoes, SamuraiWarajiTa),
                (Shoes, Sandals),
                (Shoes, SimpleShoes),
                (Shoes, TabiBootsTall),
                (Shoes, ThighBoots),
                (Shoes, Waraji),

                //Layer 4
                (Pants, ShortPants),
                (Pants, BoneLeggings),
                (Pants, BoneLegs),
                (Pants, DragonLeggings),
                (Pants, ElvenPants),
                (Pants, ElvenPlateLegs),
                (Pants, Haidate),
                (Pants, HidePants),
                (Pants, ChainmailLeggings),
                (Pants, JesterPants),
                (Pants, Kobakama),
                (Pants, LeatherHaidate),
                (Pants, LeatherLeggings),
                (Pants, LeatherNinjaPants),
                (Pants, LeatherShorts),
                (Pants, LeatherSkirt),
                (Pants, LeatherSuneate),
                (Pants, LongPants),
                (Pants, LtArmorKilt),
                (Pants, LtArmorPants),
                (Pants, MailHaidate),
                (Pants, NinjaPants),
                (Pants, PlateHaidate),
                (Pants, PlatemailLegs),
                (Pants, PlateSuneate),
                (Pants, RingmailLeggings),
                (Pants, SpikedShorts),
                (Pants, StuddedHaidate),
                (Pants, StuddedLeggings),
                (Pants, StuddedSuneate),
                (Pants, TattsukeHakama),

                //Layer 5
                (Shirt, AmazonArmor),
                (Shirt, AmazonHarness),
                (Shirt, EliteHarness),
                (Shirt, ElvenShirt),
                (Shirt, Elvenshirt1Male),
                (Shirt, Elvenshirt2Male),
                (Shirt, ElvenShirtMale),
                (Shirt, FancyShirt),
                (Shirt, Fshirt1Chest),
                (Shirt, Fshirt2Chest),
                (Shirt, CheckeredShirt),
                (Shirt, NinjaShirt),
                (Shirt, SimpleShirt),

                //Layer 6
                (Hat, Bandana),
                (Hat, Bascinet),
                (Hat, BearMask),
                (Hat, BoneHelmet),
                (Hat, Bonnet),
                (Hat, Cap),
                (Hat, Circlet),
                (Hat, Circlet1),
                (Hat, Circlet2),
                (Hat, Circlet3),
                (Hat, CloseHelm),
                (Hat, CloseHelmet),
                (Hat, DeerMask),
                (Hat, DragonHelm),
                (Hat, ElvenGlasses),
                (Hat, FeatheredHat),
                (Hat, FeatheredMask),
                (Hat, FloppyHat),
                (Hat, FlowerGarland),
                (Hat, GemmedCirclet),
                (Hat, Hachimaki),
                (Hat, Helmet),
                (Hat, ChainmailCoif),
                (Hat, JesterHat),
                (Hat, JestersCap),
                (Hat, Kabuto),
                (Hat, KabutoMempo),
                (Hat, Kasa),
                (Hat, LeatherCap),
                (Hat, LeatherJingasa),
                (Hat, LeatherNinjaHood),
                (Hat, MailHatsuburi),
                (Hat, MElvenGlasses),
                (Hat, NinjaMask),
                (Hat, NorseHelm),
                (Hat, OrcHelm),
                (Hat, OrcMask),
                (Hat, PlateHatsuburi),
                (Hat, PlateHelm),
                (Hat, PlateJingasa),
                (Hat, PlateKabuto),
                (Hat, RavenHelm),
                (Hat, RobinHoodCap),
                (Hat, RoyalCirclet),
                (Hat, Skullcap),
                (Hat, StrawHat),
                (Hat, TallStrawHat),
                (Hat, TribalMask),
                (Hat, TricorneHat),
                (Hat, VultureHelm),
                (Hat, WideBrimHat),
                (Hat, WingedHelm),
                (Hat, WingedHelmet),
                (Hat, WizardsHat),

                //Layer 7
                (Gloves, ArcaneGloves),
                (Gloves, BoneGloves),
                (Gloves, DragonGloves),
                (Gloves, ElvenPlateGloves),
                (Gloves, HideGloves),
                (Gloves, KoteGloves),
                (Gloves, LeatherGloves),
                (Gloves, LeatherNinjaMitts),
                (Gloves, LtArmorGloves),
                (Gloves, PlatemailGloves),
                (Gloves, RingmailGloves),
                (Gloves, StuddedGloves),

                //Layer 8
                (Item, Ring),

                //Layer 9
                (Item, Talisman),

                //Layer 10
                (Item, BeadNecklace),
                (Gorget, ElvenPlateGorget),
                (Gorget, HideGorget),
                (Gorget, LeatherGorget),
                (Gorget, LeatherMempo),
                (Gorget, LtArmorGorget),
                (Gorget, Necklace),
                (Gorget, PlateGorget),
                (Gorget, PlatemailGorget),
                (Gorget, PlateMempo),
                (Gorget, SilverNecklace),
                (Gorget, StuddedGorget),
                (Gorget, StuddedMempo),

                //Layer 12
                (Belt, ElvenPlateBelt),
                (Belt, HalfApron),
                (Belt, LeatherNinjaBelt),
                (Belt, Obi),
                (Belt, WoodlandBelt),

                //Layer 13
                (Chest, BoneArmor),
                (Chest, ClothNinjaJacket),
                (Chest, DoMaru),
                (Chest, DragonBreastplate),
                (Chest, ElvenPlate),
                (Chest, HaramakiDoChest),
                (Chest, HideFemaleChest),
                (Chest, HideChest),
                (Chest, ChainmailTunic),
                (Chest, LeatherArmor),
                (Chest, LeatherBustier),
                (Chest, LeatherDo),
                (Chest, LeatherNinjaJacke),
                (Chest, LeatherTunic),
                (Chest, LtArmorChest),
                (Chest, LtfChest),
                (Chest, NinjaJacket),
                (Chest, PlateArmor),
                (Chest, PlateDo),
                (Chest, Platemail),
                (Chest, RingmailTunic),
                (Chest, StuddedArmor),
                (Chest, StuddedBustier),
                (Chest, StuddedDo),
                (Chest, StuddedTunic),
                (Chest, WoodlandBreastplat),

                //Layer 14
                (Item, Bracelet),

                //Layer 17
                (Sash, BodySash),
                (Sash, Doublet),
                (Sash, FormalShirt),
                (Sash, FullApron),
                (Sash, JesterSuit),
                (Sash, JinBaori),
                (Sash, Surcoat),
                (Sash, Tunic),

                //Layer 18
                (Item, Earrings),

                //Layer 19
                (Arms, BoneArms),
                (Arms, DragonSleeves),
                (Arms, ElvenArmPlate),
                (Arms, HaramakiDoArms),
                (Arms, HidePaldrons),
                (Arms, KoteSleeves),
                (Arms, LeatherSleeves),
                (Arms, LtArmorPaldrons),
                (Arms, PlatemailArms),
                (Arms, RingmailSleeves),
                (Arms, SamuraiArmorArms),
                (Arms, StuddedSleeves),

                //Layer 20
                (Cloak, ArcaneCloak),
                (Cloak, ElvenQuiver),
                (Cloak, FurCape),
                (Cloak, MElvenQuiver),
                (Cloak, SimpleCloak),

                //Layer 22
                (Dress, DeathShroud),
                (Dress, GmRobe),
                (Dress, HoodedShroud),
                (Dress, ArcaneRobe),
                (Dress, ElvenRobe),
                (Dress, FancyDress),
                (Dress, FemaleKimono),
                (Dress, GildedDress),
                (Dress, HakamaShita),
                (Dress, Kamishimo),
                (Dress, Kimono),
                (Dress, KimonoFemaleDres),
                (Dress, KimonoMaleDress),
                (Dress, LongDress),
                (Dress, MaleKimono),
                (Dress, MElvenRobe01),
                (Dress, MElvenRobe02),
                (Dress, PlainDress),
                (Dress, Robe),

                //Layer 23
                (Skirt, FurSurong),
                (Skirt, Hakama),
                (Skirt, Kilt),
                (Skirt, KneeSkirt),
                (Skirt, SimpleSkirt),

                (Item, OneHand),
                (Item, TwoHand),
                (Dye, Shoes),
                (Dye, Pants),
                (Dye, Shirt),
                (Dye, Hat),
                (Dye, Gloves),
                (Dye, Gorget),
                (Dye, Belt),
                (Dye, Chest),
                (Dye, Sash),
                (Dye, Arms),
                (Dye, Cloak),
                (Dye, Skirt),
                (Dye, Dress),

                (Item, Gold),
                (Item, RedBook),
                (Item, Dye),

                (Item, BodyPart),
                (Item, Container)
            });
        }

        List<HashSet<TIdentity>> IdentityTree { get; set; }

        private static List<HashSet<TIdentity>> BuildTree((TIdentity group, TIdentity member)[] hierarchy)
        {
            var tree = hierarchy.Where(p => hierarchy.All(g => g.group != p.member)).Select(p => new HashSet<TIdentity> { p.member }).ToList();

            while (true)
            {
                var loop = false;

                for (var i = tree.Count - 1; i >= 0; i--)
                {
                    var branch = tree[i];

                    var last = branch.Last();

                    var next = hierarchy.Where(g => g.member == last).Select(p => p.group).ToList();

                    var node = next.FirstOrDefault();

                    if (node == null) continue;

                    tree.AddRange(next.Skip(1).Select(a => branch.Concat(new[] { a }).ToHashSet()));

                    branch.Add(node);

                    loop = true;
                }

                if (loop) continue;

                break;
            }

            return tree;
        }
    }
}
