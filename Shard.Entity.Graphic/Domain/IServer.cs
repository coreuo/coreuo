using System;
using System.Collections.Generic;
using System.Linq;

namespace Shard.Entity.Graphic.Domain
{
    public interface IServer<TIdentity>
    {
        Random Random { get; }

        TIdentity Male { get; }

        TIdentity Female { get; }

        TIdentity Human { get; }

        TIdentity Elf { get; }

        TIdentity Humanoid { get; }

        TIdentity Ghost { get; }

        TIdentity Mobile { get; }

        TIdentity Alive { get; }

        TIdentity Corpse { get; }

        TIdentity Dye { get; }

        TIdentity Backpack { get; }

        TIdentity Gold { get; }

        TIdentity RedBook { get; }

        TIdentity Hair { get; }

        TIdentity Face { get; }

        TIdentity Beard { get; }

        TIdentity Item { get; }


        //Layer 1
        TIdentity BookOfArms { get; }
        TIdentity BookOfBushido { get; }
        TIdentity BookOfNinjitsu { get; }
        TIdentity Fukiya { get; }
        TIdentity NecromancerBook { get; }
        TIdentity PaladinSpellbook { get; }
        TIdentity Spellbook { get; }
        TIdentity SpellWeavingBook { get; }
        TIdentity AssassinSpike { get; }
        TIdentity BattleAxe { get; }
        TIdentity Bokuto { get; }
        TIdentity BoneHarvester { get; }
        TIdentity Bow { get; }
        TIdentity Broadsword { get; }
        TIdentity ButcherKnife { get; }
        TIdentity Cleaver { get; }
        TIdentity Club { get; }
        TIdentity Crossbow { get; }
        TIdentity Cutlass { get; }
        TIdentity Dagger { get; }
        TIdentity DiamondMace { get; }
        TIdentity ElvenMachete { get; }
        TIdentity HammerPick { get; }
        TIdentity HeavyCrossbow { get; }
        TIdentity Katana { get; }
        TIdentity Kryss { get; }
        TIdentity Lance { get; }
        TIdentity Leafblade { get; }
        TIdentity LizardmansMace { get; }
        TIdentity Longsword { get; }
        TIdentity LongSword { get; }
        TIdentity Mace { get; }
        TIdentity MagicSword { get; }
        TIdentity Maul { get; }
        TIdentity PaladinSword { get; }
        TIdentity Pick { get; }
        TIdentity Pickaxe { get; }
        TIdentity RadiantScimitar { get; }
        TIdentity RatmanAxe { get; }
        TIdentity RatmanSword { get; }
        TIdentity Scepter { get; }
        TIdentity Scimitar { get; }
        TIdentity Shortsword { get; }
        TIdentity SkeletonAxe { get; }
        TIdentity SkeletonScimitar { get; }
        TIdentity SkinningKnife { get; }
        TIdentity SledgeHammer { get; }
        TIdentity SmithsHammer { get; }
        TIdentity SmythHammer { get; }
        TIdentity Sword { get; }
        TIdentity TerathanMace { get; }
        TIdentity VikingSword { get; }
        TIdentity Wakizashi { get; }
        TIdentity Wand { get; }
        TIdentity WarAxe { get; }
        TIdentity WarCleaver { get; }
        TIdentity WarFork { get; }
        TIdentity WarHammer { get; }
        TIdentity WarMace { get; }
        TIdentity WildStaff { get; }

        //Layer 2
        TIdentity LightSource { get; }
        TIdentity Axe { get; }
        TIdentity Bardiche { get; }
        TIdentity BlackStaff { get; }
        TIdentity BladedStaff { get; }
        TIdentity BoneMageStaff { get; }
        TIdentity BronzeShield { get; }
        TIdentity Buckler { get; }
        TIdentity Candle { get; }
        TIdentity CompositeBow { get; }
        TIdentity CrescentBlade { get; }
        TIdentity Crook { get; }
        TIdentity DaemonSword { get; }
        TIdentity Daisho { get; }
        TIdentity DoubleAxe { get; }
        TIdentity DoubleBladedStaff { get; }
        TIdentity ElvenCompositeLo { get; }
        TIdentity ElvenSpellblade { get; }
        TIdentity EttinHammer { get; }
        TIdentity ExecutionersAxe { get; }
        TIdentity FishingPole { get; }
        TIdentity FrostTrollClub { get; }
        TIdentity GnarledStaff { get; }
        TIdentity Halberd { get; }
        TIdentity Hatchet { get; }
        TIdentity HeaterShield { get; }
        TIdentity HorsemansBow { get; }
        TIdentity ChaosShield { get; }
        TIdentity Javelin { get; }
        TIdentity Kama { get; }
        TIdentity KiteShield { get; }
        TIdentity Lajatang { get; }
        TIdentity Lantern { get; }
        TIdentity LargeBattleAxe { get; }
        TIdentity LichesStaff { get; }
        TIdentity LizardmansSpear { get; }
        TIdentity MagicalShortbow { get; }
        TIdentity MagicStaff { get; }
        TIdentity MetalShield { get; }
        TIdentity Naginata { get; }
        TIdentity NoDachi { get; }
        TIdentity Nunchaku { get; }
        TIdentity OgresClub { get; }
        TIdentity OphidianBardiche { get; }
        TIdentity OphidianStaff { get; }
        TIdentity OrcClub { get; }
        TIdentity OrcLordBattleaxe { get; }
        TIdentity OrcMageStaff { get; }
        TIdentity OrderShield { get; }
        TIdentity OrnateAxe { get; }
        TIdentity Pike { get; }
        TIdentity Pitchfork { get; }
        TIdentity QuarterStaff { get; }
        TIdentity RepeatingCrossbow { get; }
        TIdentity RuneBlade { get; }
        TIdentity Sai { get; }
        TIdentity ScaleShield { get; }
        TIdentity Scythe { get; }
        TIdentity ShepherdsCrook { get; }
        TIdentity ShortSpear { get; }
        TIdentity Spear { get; }
        TIdentity Tekagi { get; }
        TIdentity TerathanSpear { get; }
        TIdentity TerathanStaff { get; }
        TIdentity Tessen { get; }
        TIdentity Tetsubo { get; }
        TIdentity Torch { get; }
        TIdentity TrollAxe { get; }
        TIdentity TrollMaul { get; }
        TIdentity TwoHandedAxe { get; }
        TIdentity WoodenShield { get; }
        TIdentity Yumi { get; }

        //Layer 3
        TIdentity ArcaneThighBoots { get; }
        TIdentity Boots { get; }
        TIdentity ElvenBoot { get; }
        TIdentity FurBoots { get; }
        TIdentity JesterShoes { get; }
        TIdentity NinjaTallTabi { get; }
        TIdentity SamuraiSandalTabi { get; }
        TIdentity SamuraiWarajiTa { get; }
        TIdentity Sandals { get; }
        TIdentity SimpleShoes { get; }
        TIdentity TabiBootsTall { get; }
        TIdentity ThighBoots { get; }
        TIdentity Waraji { get; }

        //Layer 4
        TIdentity ShortPants { get; }
        TIdentity BoneLeggings { get; }
        TIdentity BoneLegs { get; }
        TIdentity DragonLeggings { get; }
        TIdentity ElvenPants { get; }
        TIdentity ElvenPlateLegs { get; }
        TIdentity Haidate { get; }
        TIdentity HidePants { get; }
        TIdentity ChainmailLeggings { get; }
        TIdentity JesterPants { get; }
        TIdentity Kobakama { get; }
        TIdentity LeatherHaidate { get; }
        TIdentity LeatherLeggings { get; }
        TIdentity LeatherNinjaPants { get; }
        TIdentity LeatherShorts { get; }
        TIdentity LeatherSkirt { get; }
        TIdentity LeatherSuneate { get; }
        TIdentity LongPants { get; }
        TIdentity LtArmorKilt { get; }
        TIdentity LtArmorPants { get; }
        TIdentity MailHaidate { get; }
        TIdentity NinjaPants { get; }
        TIdentity PlateHaidate { get; }
        TIdentity PlatemailLegs { get; }
        TIdentity PlateSuneate { get; }
        TIdentity RingmailLeggings { get; }
        TIdentity SpikedShorts { get; }
        TIdentity StuddedHaidate { get; }
        TIdentity StuddedLeggings { get; }
        TIdentity StuddedSuneate { get; }
        TIdentity TattsukeHakama { get; }

        //Layer 5
        TIdentity AmazonArmor { get; }
        TIdentity AmazonHarness { get; }
        TIdentity EliteHarness { get; }
        TIdentity ElvenShirt { get; }
        TIdentity Elvenshirt1Male { get; }
        TIdentity Elvenshirt2Male { get; }
        TIdentity ElvenShirtMale { get; }
        TIdentity FancyShirt { get; }
        TIdentity Fshirt1Chest { get; }
        TIdentity Fshirt2Chest { get; }
        TIdentity CheckeredShirt { get; }
        TIdentity NinjaShirt { get; }
        TIdentity SimpleShirt { get; }

        //Layer 6
        TIdentity Bandana { get; }
        TIdentity Bascinet { get; }
        TIdentity BearMask { get; }
        TIdentity BoneHelmet { get; }
        TIdentity Bonnet { get; }
        TIdentity Cap { get; }
        TIdentity Circlet { get; }
        TIdentity Circlet1 { get; }
        TIdentity Circlet2 { get; }
        TIdentity Circlet3 { get; }
        TIdentity CloseHelm { get; }
        TIdentity CloseHelmet { get; }
        TIdentity DeerMask { get; }
        TIdentity DragonHelm { get; }
        TIdentity ElvenGlasses { get; }
        TIdentity FeatheredHat { get; }
        TIdentity FeatheredMask { get; }
        TIdentity FloppyHat { get; }
        TIdentity FlowerGarland { get; }
        TIdentity GemmedCirclet { get; }
        TIdentity Hachimaki { get; }
        TIdentity Helmet { get; }
        TIdentity ChainmailCoif { get; }
        TIdentity JesterHat { get; }
        TIdentity JestersCap { get; }
        TIdentity Kabuto { get; }
        TIdentity KabutoMempo { get; }
        TIdentity Kasa { get; }
        TIdentity LeatherCap { get; }
        TIdentity LeatherJingasa { get; }
        TIdentity LeatherNinjaHood { get; }
        TIdentity MailHatsuburi { get; }
        TIdentity MElvenGlasses { get; }
        TIdentity NinjaMask { get; }
        TIdentity NorseHelm { get; }
        TIdentity OrcHelm { get; }
        TIdentity OrcMask { get; }
        TIdentity PlateHatsuburi { get; }
        TIdentity PlateHelm { get; }
        TIdentity PlateJingasa { get; }
        TIdentity PlateKabuto { get; }
        TIdentity RavenHelm { get; }
        TIdentity RobinHoodCap { get; }
        TIdentity RoyalCirclet { get; }
        TIdentity Skullcap { get; }
        TIdentity StrawHat { get; }
        TIdentity TallStrawHat { get; }
        TIdentity TribalMask { get; }
        TIdentity TricorneHat { get; }
        TIdentity VultureHelm { get; }
        TIdentity WideBrimHat { get; }
        TIdentity WingedHelm { get; }
        TIdentity WingedHelmet { get; }
        TIdentity WizardsHat { get; }

        //Layer 7
        TIdentity ArcaneGloves { get; }
        TIdentity BoneGloves { get; }
        TIdentity DragonGloves { get; }
        TIdentity ElvenPlateGloves { get; }
        TIdentity HideGloves { get; }
        TIdentity KoteGloves { get; }
        TIdentity LeatherGloves { get; }
        TIdentity LeatherNinjaMitts { get; }
        TIdentity LtArmorGloves { get; }
        TIdentity PlatemailGloves { get; }
        TIdentity RingmailGloves { get; }
        TIdentity StuddedGloves { get; }

        //Layer 8
        TIdentity Ring { get; }

        //Layer 9
        TIdentity Talisman { get; }

        //Layer 10
        TIdentity BeadNecklace { get; }
        TIdentity ElvenPlateGorget { get; }
        TIdentity HideGorget { get; }
        TIdentity LeatherGorget { get; }
        TIdentity LeatherMempo { get; }
        TIdentity LtArmorGorget { get; }
        TIdentity Necklace { get; }
        TIdentity PlateGorget { get; }
        TIdentity PlatemailGorget { get; }
        TIdentity PlateMempo { get; }
        TIdentity SilverNecklace { get; }
        TIdentity StuddedGorget { get; }
        TIdentity StuddedMempo { get; }

        //Layer 12
        TIdentity ElvenPlateBelt { get; }
        TIdentity HalfApron { get; }
        TIdentity LeatherNinjaBelt { get; }
        TIdentity Obi { get; }
        TIdentity WoodlandBelt { get; }

        //Layer 13
        TIdentity BoneArmor { get; }
        TIdentity ClothNinjaJacket { get; }
        TIdentity DoMaru { get; }
        TIdentity DragonBreastplate { get; }
        TIdentity ElvenPlate { get; }
        TIdentity HaramakiDoChest { get; }
        TIdentity HideFemaleChest { get; }
        TIdentity HideChest { get; }
        TIdentity ChainmailTunic { get; }
        TIdentity LeatherArmor { get; }
        TIdentity LeatherBustier { get; }
        TIdentity LeatherDo { get; }
        TIdentity LeatherNinjaJacke { get; }
        TIdentity LeatherTunic { get; }
        TIdentity LtArmorChest { get; }
        TIdentity LtfChest { get; }
        TIdentity NinjaJacket { get; }
        TIdentity PlateArmor { get; }
        TIdentity PlateDo { get; }
        TIdentity Platemail { get; }
        TIdentity RingmailTunic { get; }
        TIdentity StuddedArmor { get; }
        TIdentity StuddedBustier { get; }
        TIdentity StuddedDo { get; }
        TIdentity StuddedTunic { get; }
        TIdentity WoodlandBreastplat { get; }

        //Layer 14
        TIdentity Bracelet { get; }

        //Layer 17
        TIdentity BodySash { get; }
        TIdentity Doublet { get; }
        TIdentity FormalShirt { get; }
        TIdentity FullApron { get; }
        TIdentity JesterSuit { get; }
        TIdentity JinBaori { get; }
        TIdentity Surcoat { get; }
        TIdentity Tunic { get; }

        //Layer 18
        TIdentity Earrings { get; }

        //Layer 19
        TIdentity BoneArms { get; }
        TIdentity DragonSleeves { get; }
        TIdentity ElvenArmPlate { get; }
        TIdentity HaramakiDoArms { get; }
        TIdentity HidePaldrons { get; }
        TIdentity KoteSleeves { get; }
        TIdentity LeatherSleeves { get; }
        TIdentity LtArmorPaldrons { get; }
        TIdentity PlatemailArms { get; }
        TIdentity RingmailSleeves { get; }
        TIdentity SamuraiArmorArms { get; }
        TIdentity StuddedSleeves { get; }

        //Layer 20
        TIdentity ArcaneCloak { get; }
        TIdentity ElvenQuiver { get; }
        TIdentity FurCape { get; }
        TIdentity MElvenQuiver { get; }
        TIdentity SimpleCloak { get; }

        //Layer 22
        TIdentity DeathShroud { get; }
        TIdentity GmRobe { get; }
        TIdentity HoodedShroud { get; }
        TIdentity ArcaneRobe { get; }
        TIdentity ElvenRobe { get; }
        TIdentity FancyDress { get; }
        TIdentity FemaleKimono { get; }
        TIdentity GildedDress { get; }
        TIdentity HakamaShita { get; }
        TIdentity Kamishimo { get; }
        TIdentity Kimono { get; }
        TIdentity KimonoFemaleDres { get; }
        TIdentity KimonoMaleDress { get; }
        TIdentity LongDress { get; }
        TIdentity MaleKimono { get; }
        TIdentity MElvenRobe01 { get; }
        TIdentity MElvenRobe02 { get; }
        TIdentity PlainDress { get; }
        TIdentity Robe { get; }

        //Layer 23
        TIdentity FurSurong { get; }
        TIdentity Hakama { get; }
        TIdentity Kilt { get; }
        TIdentity KneeSkirt { get; }
        TIdentity SimpleSkirt { get; }

        TIdentity Shoes { get; }
        TIdentity Pants { get; }
        TIdentity Shirt { get; }

        Dictionary<HashSet<TIdentity>, List<Range>> GraphicRanges { get; set; }

        Dictionary<HashSet<TIdentity>, List<Range>> HueRanges { get; set; }

        List<TIdentity> Containers { get; set; }

        internal void LoadGraphicRanges()
        {
            GraphicRanges = new LimitCollection<TIdentity>()
                .Entity(Alive, Human, Male).Limit(400)
                .Entity(Alive, Human, Female).Limit(401)
                .Entity(Ghost, Human, Male).Limit(402)
                .Entity(Ghost, Human, Female).Limit(403)
                .Entity(Alive, Elf, Male).Limit(605)
                .Entity(Alive, Elf, Female).Limit(606)
                .Entity(Ghost, Elf, Male).Limit(607)
                .Entity(Ghost, Elf, Female).Limit(608)
                .Entity(Backpack).Limit(0xE75)
                .Entity(Gold).Limit(0xEED)
                .Entity(RedBook).Limit(0xFF1)
                //Layer 1
                .Entity(BookOfArms).Limit(0x2254)
                .Entity(BookOfBushido).Limit(0x238C)
                .Entity(BookOfNinjitsu).Limit(0x23A0)
                .Entity(Fukiya).Limit(0x27AA, 0x27F5)
                .Entity(NecromancerBook).Limit(0x2253)
                .Entity(PaladinSpellbook).Limit(0x2252)
                .Entity(Spellbook).Limit(0xE3B, 0xEFA)
                .Entity(SpellWeavingBook).Limit(0x2D50)
                .Entity(AssassinSpike).Limit(0x2D21, 0x2D2D)
                .Entity(BattleAxe).Limit(0xF47, 0xF48)
                .Entity(Bokuto).Limit(0x27A8, 0x27F3)
                .Entity(BoneHarvester).Limit(0x26BB, 0x26C5)
                .Entity(Bow).Limit(0x13B1, 0x13B2)
                .Entity(Broadsword).Limit(0xF5E, 0xF5F)
                .Entity(ButcherKnife).Limit(0x13F6, 0x13F7)
                .Entity(Cleaver).Limit(0xEC2, 0xEC3)
                .Entity(Club).Limit(0x13B3, 0x13B4)
                .Entity(Crossbow).Limit(0xF4F, 0xF50)
                .Entity(Cutlass).Limit(0x1440, 0x1441)
                .Entity(Dagger).Limit(0xF51, 0xF52)
                .Entity(DiamondMace).Limit(0x2D24, 0x2D30)
                .Entity(ElvenMachete).Limit(0x2D29, 0x2D35)
                .Entity(HammerPick).Limit(0x143C, 0x143D)
                .Entity(HeavyCrossbow).Limit(0x13FC, 0x13FD)
                .Entity(Katana).Limit(0x13FE, 0x13FF)
                .Entity(Kryss).Limit(0x1400, 0x1401)
                .Entity(Lance).Limit(0x26C0, 0x26CA)
                .Entity(Leafblade).Limit(0x2D22, 0x2D2E)
                .Entity(LizardmansMace).Limit(0x2557)
                .Entity(Longsword).Limit(0xF60, 0xF61, 0x257D)
                .Entity(LongSword).Limit(0x13B7, 0x13B8)
                .Entity(Mace).Limit(0xF5C, 0xF5D)
                .Entity(MagicSword).Limit(0x2573, 0x2574, 0x2575, 0x2576)
                .Entity(Maul).Limit(0x143A, 0x143B)
                .Entity(PaladinSword).Limit(0x26CE, 0x26CF)
                .Entity(Pick).Limit(0x2579)
                .Entity(Pickaxe).Limit(0xE85, 0xE86)
                .Entity(RadiantScimitar).Limit(0x2D27, 0x2D33)
                .Entity(RatmanAxe).Limit(0x255D)
                .Entity(RatmanSword).Limit(0x255E)
                .Entity(Scepter).Limit(0x26BC, 0x26C6)
                .Entity(Scimitar).Limit(0x13B5, 0x13B6)
                .Entity(Shortsword).Limit(0x257E)
                .Entity(SkeletonAxe).Limit(0x255F)
                .Entity(SkeletonScimitar).Limit(0x2560)
                .Entity(SkinningKnife).Limit(0xEC4, 0xEC5)
                .Entity(SledgeHammer).Limit(0xFB4, 0xFB5)
                .Entity(SmithsHammer).Limit(0x13E3, 0x13E4)
                .Entity(SmythHammer).Limit(0x256F)
                .Entity(Sword).Limit(0x257C)
                .Entity(TerathanMace).Limit(0x2563)
                .Entity(VikingSword).Limit(0x13B9, 0x13BA)
                .Entity(Wakizashi).Limit(0x27A4, 0x27EF)
                .Entity(Wand).Limit(0xDF2, 0xDF3, 0xDF4, 0xDF5)
                .Entity(WarAxe).Limit(0x13AF, 0x13B0)
                .Entity(WarCleaver).Limit(0x2D23, 0x2D2F)
                .Entity(WarFork).Limit(0x1404, 0x1405)
                .Entity(WarHammer).Limit(0x1438, 0x1439)
                .Entity(WarMace).Limit(0x1406, 0x1407, 0x257F)
                .Entity(WildStaff).Limit(0x2D25, 0x2D31)

                //Layer 2
                .Entity(LightSource).Limit(0x1647)
                .Entity(Axe).Limit(0xF49, 0xF4A)
                .Entity(Bardiche).Limit(0xF4D, 0xF4E)
                .Entity(BlackStaff).Limit(0xDF0, 0xDF1)
                .Entity(BladedStaff).Limit(0x26BD, 0x26C7)
                .Entity(BoneMageStaff).Limit(0x2569)
                .Entity(BronzeShield).Limit(0x1B72)
                .Entity(Buckler).Limit(0x1B73)
                .Entity(Candle).Limit(0xA0F, 0xA10, 0xA11)
                .Entity(CompositeBow).Limit(0x26C2, 0x26CC)
                .Entity(CrescentBlade).Limit(0x26C1, 0x26CB)
                .Entity(Crook).Limit(0x13F4, 0x13F5)
                .Entity(DaemonSword).Limit(0x2554)
                .Entity(Daisho).Limit(0x27A9, 0x27F4)
                .Entity(DoubleAxe).Limit(0xF4B, 0xF4C)
                .Entity(DoubleBladedStaff).Limit(0x26BF, 0x26C9)
                .Entity(ElvenCompositeLo).Limit(0x2D1E, 0x2D2A)
                .Entity(ElvenSpellblade).Limit(0x2D20, 0x2D2C)
                .Entity(EttinHammer).Limit(0x2555)
                .Entity(ExecutionersAxe).Limit(0xF45, 0xF46)
                .Entity(FishingPole).Limit(0xDBF, 0xDC0)
                .Entity(FrostTrollClub).Limit(0x2566)
                .Entity(GnarledStaff).Limit(0x13F8, 0x13F9)
                .Entity(Halberd).Limit(0x143E, 0x143F)
                .Entity(Hatchet).Limit(0xF43, 0xF44, 0x2570)
                .Entity(HeaterShield).Limit(0x1B76, 0x1B77)
                .Entity(HorsemansBow).Limit(0x2571)
                .Entity(ChaosShield).Limit(0x1BC3)
                .Entity(Javelin).Limit(0x2572)
                .Entity(Kama).Limit(0x27AD, 0x27F8)
                .Entity(KiteShield).Limit(0x1B74, 0x1B75, 0x1B78, 0x1B79)
                .Entity(Lajatang).Limit(0x27A7, 0x27F2)
                .Entity(Lantern).Limit(0xA15, 0xA16, 0xA17, 0xA18, 0xA22, 0xA23, 0xA24, 0xA25)
                .Entity(LargeBattleAxe).Limit(0x13FA, 0x13FB)
                .Entity(LichesStaff).Limit(0x2556)
                .Entity(LizardmansSpear).Limit(0x2558)
                .Entity(MagicalShortbow).Limit(0x2D1F, 0x2D2B)
                .Entity(MagicStaff).Limit(0x256B, 0x256C, 0x256D, 0x256E)
                .Entity(MetalShield).Limit(0x1B7B)
                .Entity(Naginata).Limit(0x2577)
                .Entity(NoDachi).Limit(0x2578, 0x27A2, 0x27ED)
                .Entity(Nunchaku).Limit(0x27AE, 0x27F9)
                .Entity(OgresClub).Limit(0x2559)
                .Entity(OphidianBardiche).Limit(0x255B)
                .Entity(OphidianStaff).Limit(0x255A)
                .Entity(OrcClub).Limit(0x255C)
                .Entity(OrcLordBattleaxe).Limit(0x2567)
                .Entity(OrcMageStaff).Limit(0x2568)
                .Entity(OrderShield).Limit(0x1BC4, 0x1BC5)
                .Entity(OrnateAxe).Limit(0x2D28, 0x2D34)
                .Entity(Pike).Limit(0x26BE, 0x26C8)
                .Entity(Pitchfork).Limit(0xE87, 0xE88)
                .Entity(QuarterStaff).Limit(0xE89, 0xE8A)
                .Entity(RepeatingCrossbow).Limit(0x26C3, 0x26CD)
                .Entity(RuneBlade).Limit(0x2D26, 0x2D32)
                .Entity(Sai).Limit(0x27AF, 0x27FA)
                .Entity(ScaleShield).Limit(0x1BC6, 0x1BC7, 0x256A)
                .Entity(Scythe).Limit(0x26BA, 0x26C4)
                .Entity(ShepherdsCrook).Limit(0xE81, 0xE82)
                .Entity(ShortSpear).Limit(0x1402, 0x1403)
                .Entity(Spear).Limit(0xF62, 0xF63, 0x257A, 0x257B)
                .Entity(Tekagi).Limit(0x27AB, 0x27F6)
                .Entity(TerathanSpear).Limit(0x2562)
                .Entity(TerathanStaff).Limit(0x2561)
                .Entity(Tessen).Limit(0x27A3, 0x27EE)
                .Entity(Tetsubo).Limit(0x27A6, 0x27F1)
                .Entity(Torch).Limit(0xA12, 0xA13, 0xA14, 0xF64, 0xF6B)
                .Entity(TrollAxe).Limit(0x2564)
                .Entity(TrollMaul).Limit(0x2565)
                .Entity(TwoHandedAxe).Limit(0x1442, 0x1443)
                .Entity(WoodenShield).Limit(0x1B7A)
                .Entity(Yumi).Limit(0x27A5, 0x27F0)

                //Layer 3
                .Entity(ArcaneThighBoots).Limit(0x26AF)
                .Entity(Boots).Limit(0x170B, 0x170C)
                .Entity(ElvenBoot).Limit(0x2FC4, 0x317A)
                .Entity(FurBoots).Limit(0x2307, 0x2308)
                .Entity(JesterShoes).Limit(0x2655, 0x2656)
                .Entity(NinjaTallTabi).Limit(0x2797, 0x27E2)
                .Entity(SamuraiSandalTabi).Limit(0x2796, 0x27E1)
                .Entity(SamuraiWarajiTa).Limit(0x2700)
                .Entity(Sandals).Limit(0x170D, 0x170E)
                .Entity(SimpleShoes).Limit(0x170F, 0x1710)
                .Entity(TabiBootsTall).Limit(0x2795, 0x27E0)
                .Entity(ThighBoots).Limit(0x1711, 0x1712)
                .Entity(Waraji).Limit(0x2653, 0x2654)

                //Layer 4
                .Entity(ShortPants).Limit(0x152E, 0x152F)
                .Entity(BoneLeggings).Limit(0x1452)
                .Entity(BoneLegs).Limit(0x1457)
                .Entity(DragonLeggings).Limit(0x2647, 0x2648)
                .Entity(ElvenPants).Limit(0x2FC3, 0x3179)
                .Entity(ElvenPlateLegs).Limit(0x2B6B, 0x3162)
                .Entity(Haidate).Limit(0x264D, 0x264E)
                .Entity(HidePants).Limit(0x2B78, 0x316F)
                .Entity(ChainmailLeggings).Limit(0x13BE, 0x13C3)
                .Entity(JesterPants).Limit(0x2649, 0x264A)
                .Entity(Kobakama).Limit(0x264F, 0x2650)
                .Entity(LeatherHaidate).Limit(0x278A, 0x27D5)
                .Entity(LeatherLeggings).Limit(0x13CB, 0x13D2)
                .Entity(LeatherNinjaPants).Limit(0x2791, 0x27DC)
                .Entity(LeatherShorts).Limit(0x1C00, 0x1C01)
                .Entity(LeatherSkirt).Limit(0x1C08, 0x1C09)
                .Entity(LeatherSuneate).Limit(0x2786, 0x27D1)
                .Entity(LongPants).Limit(0x1539, 0x153A)
                .Entity(LtArmorKilt).Limit(0x2FCA, 0x3180)
                .Entity(LtArmorPants).Limit(0x2FC9, 0x317F)
                .Entity(MailHaidate).Limit(0x278C, 0x27D7)
                .Entity(NinjaPants).Limit(0x2651, 0x2652)
                .Entity(PlateHaidate).Limit(0x278D, 0x27D8)
                .Entity(PlatemailLegs).Limit(0x1411, 0x141A)
                .Entity(PlateSuneate).Limit(0x2788, 0x27D3)
                .Entity(RingmailLeggings).Limit(0x13F0, 0x13F1)
                .Entity(SpikedShorts).Limit(0x25E4, 0x25E5)
                .Entity(StuddedHaidate).Limit(0x278B, 0x27D6)
                .Entity(StuddedLeggings).Limit(0x13DA, 0x13E1)
                .Entity(StuddedSuneate).Limit(0x2787, 0x27D2)
                .Entity(TattsukeHakama).Limit(0x279B, 0x27E6)

                //Layer 5
                .Entity(AmazonArmor).Limit(0x2659, 0x265A, 0x265B, 0x265C, 0x265D, 0x265E)
                .Entity(AmazonHarness).Limit(0x25E6, 0x25E7)
                .Entity(EliteHarness).Limit(0x25E8, 0x25E9)
                .Entity(ElvenShirt).Limit(0x2FBD, 0x2FBE)
                .Entity(Elvenshirt1Male).Limit(0x3175)
                .Entity(Elvenshirt2Male).Limit(0x3176)
                .Entity(ElvenShirtMale).Limit(0x2FBB, 0x2FBC)
                .Entity(FancyShirt).Limit(0x1EFD, 0x1EFE)
                .Entity(Fshirt1Chest).Limit(0x3177)
                .Entity(Fshirt2Chest).Limit(0x3178)
                .Entity(CheckeredShirt).Limit(0x25EA, 0x25EB)
                .Entity(NinjaShirt).Limit(0x2667, 0x2668)
                .Entity(SimpleShirt).Limit(0x1517, 0x1518, 0x265F, 0x2660, 0x2661, 0x2662, 0x2663, 0x2664, 0x2665, 0x2666)

                //Layer 6
                .Entity(Bandana).Limit(0x153F, 0x1540)
                .Entity(Bascinet).Limit(0x140E, 0x140F)
                .Entity(BearMask).Limit(0x1545, 0x1546)
                .Entity(BoneHelmet).Limit(0x1451, 0x1456)
                .Entity(Bonnet).Limit(0x1719)
                .Entity(Cap).Limit(0x1715)
                .Entity(Circlet).Limit(0x2B6E)
                .Entity(Circlet1).Limit(0x3165)
                .Entity(Circlet2).Limit(0x3166)
                .Entity(Circlet3).Limit(0x3167)
                .Entity(CloseHelm).Limit(0x1409)
                .Entity(CloseHelmet).Limit(0x1408)
                .Entity(DeerMask).Limit(0x1547, 0x1548)
                .Entity(DragonHelm).Limit(0x2645, 0x2646)
                .Entity(ElvenGlasses).Limit(0x2FB8)
                .Entity(FeatheredHat).Limit(0x171A)
                .Entity(FeatheredMask).Limit(0x26A1, 0x26A2)
                .Entity(FloppyHat).Limit(0x1713)
                .Entity(FlowerGarland).Limit(0x2305, 0x2306)
                .Entity(GemmedCirclet).Limit(0x2B70)
                .Entity(Hachimaki).Limit(0x268B, 0x268C)
                .Entity(Helmet).Limit(0x140A, 0x140B)
                .Entity(ChainmailCoif).Limit(0x13BB, 0x13C0)
                .Entity(JesterHat).Limit(0x171C)
                .Entity(JestersCap).Limit(0x172E)
                .Entity(Kabuto).Limit(0x236C, 0x236D, 0x268D, 0x268E)
                .Entity(KabutoMempo).Limit(0x268F, 0x2690)
                .Entity(Kasa).Limit(0x2798, 0x27E3)
                .Entity(LeatherCap).Limit(0x1DB9, 0x1DBA, 0x2691, 0x2692)
                .Entity(LeatherJingasa).Limit(0x2776, 0x27C1)
                .Entity(LeatherNinjaHood).Limit(0x278E, 0x278F, 0x27D9, 0x27DA)
                .Entity(MailHatsuburi).Limit(0x2774, 0x27BF)
                .Entity(MElvenGlasses).Limit(0x3172)
                .Entity(NinjaMask).Limit(0x26A3, 0x26A4)
                .Entity(NorseHelm).Limit(0x140C, 0x140D)
                .Entity(OrcHelm).Limit(0x1F0B, 0x1F0C)
                .Entity(OrcMask).Limit(0x141B, 0x141C)
                .Entity(PlateHatsuburi).Limit(0x2775, 0x27C0)
                .Entity(PlateHelm).Limit(0x1412, 0x1419)
                .Entity(PlateJingasa).Limit(0x2777, 0x2781, 0x2784, 0x27C2, 0x27CC, 0x27CF)
                .Entity(PlateKabuto).Limit(0x2778, 0x2785, 0x2789, 0x27C3, 0x27D0, 0x27D4)
                .Entity(RavenHelm).Limit(0x2B71, 0x3168)
                .Entity(RobinHoodCap).Limit(0x269D, 0x269E)
                .Entity(RoyalCirclet).Limit(0x2B6F)
                .Entity(Skullcap).Limit(0x1543, 0x1544)
                .Entity(StrawHat).Limit(0x1717)
                .Entity(TallStrawHat).Limit(0x1716)
                .Entity(TribalMask).Limit(0x1549, 0x154A, 0x154B, 0x154C)
                .Entity(TricorneHat).Limit(0x171B)
                .Entity(VultureHelm).Limit(0x2B72, 0x3169)
                .Entity(WideBrimHat).Limit(0x1714)
                .Entity(WingedHelm).Limit(0x2B73, 0x316A)
                .Entity(WingedHelmet).Limit(0x2689, 0x268A)
                .Entity(WizardsHat).Limit(0x1718)

                //Layer 7
                .Entity(ArcaneGloves).Limit(0x26B0)
                .Entity(BoneGloves).Limit(0x1450, 0x1455)
                .Entity(DragonGloves).Limit(0x2643, 0x2644)
                .Entity(ElvenPlateGloves).Limit(0x2B6A, 0x3161)
                .Entity(HideGloves).Limit(0x2B75, 0x316C)
                .Entity(KoteGloves).Limit(0x2677, 0x2678, 0x2679, 0x267A)
                .Entity(LeatherGloves).Limit(0x13C6, 0x13CE)
                .Entity(LeatherNinjaMitts).Limit(0x2792, 0x27DD)
                .Entity(LtArmorGloves).Limit(0x2FC6, 0x317C)
                .Entity(PlatemailGloves).Limit(0x1414, 0x1418)
                .Entity(RingmailGloves).Limit(0x13EB, 0x13F2)
                .Entity(StuddedGloves).Limit(0x13D5, 0x13DD)

                //Layer 8
                .Entity(Ring).Limit(0x108A, 0x1F09)

                //Layer 9
                .Entity(Talisman).Limit(0x1096, 0x2F58, 0x2F59, 0x2F5A, 0x2F5B)

                //Layer 10
                .Entity(BeadNecklace).Limit(0x1F05)
                .Entity(ElvenPlateGorget).Limit(0x2B69, 0x3160)
                .Entity(HideGorget).Limit(0x2B76, 0x316D)
                .Entity(LeatherGorget).Limit(0x13C7)
                .Entity(LeatherMempo).Limit(0x277A, 0x27C5)
                .Entity(LtArmorGorget).Limit(0x2FC7, 0x317D)
                .Entity(Necklace).Limit(0x1085, 0x1088, 0x1089, 0x1F08)
                .Entity(PlateGorget).Limit(0x264B, 0x264C)
                .Entity(PlatemailGorget).Limit(0x1413)
                .Entity(PlateMempo).Limit(0x2779, 0x27C4)
                .Entity(SilverNecklace).Limit(0x1F0A)
                .Entity(StuddedGorget).Limit(0x13D6)
                .Entity(StuddedMempo).Limit(0x279D, 0x27E8)

                //Layer 12
                .Entity(ElvenPlateBelt).Limit(0x2B68)
                .Entity(HalfApron).Limit(0x153B, 0x153C)
                .Entity(LeatherNinjaBelt).Limit(0x2790, 0x27DB)
                .Entity(Obi).Limit(0x27A0, 0x27EB)
                .Entity(WoodlandBelt).Limit(0x315F)

                //Layer 13
                .Entity(BoneArmor).Limit(0x144F, 0x1454)
                .Entity(ClothNinjaJacket).Limit(0x2794, 0x27DF)
                .Entity(DoMaru).Limit(0x2671, 0x2672)
                .Entity(DragonBreastplate).Limit(0x2641, 0x2642)
                .Entity(ElvenPlate).Limit(0x2B67, 0x2B6D, 0x3164)
                .Entity(HaramakiDoChest).Limit(0x2673)
                .Entity(HideFemaleChest).Limit(0x2B79, 0x3170)
                .Entity(HideChest).Limit(0x2B74, 0x316B)
                .Entity(ChainmailTunic).Limit(0x13BF, 0x13C4)
                .Entity(LeatherArmor).Limit(0x1C06, 0x1C07)
                .Entity(LeatherBustier).Limit(0x1C0A, 0x1C0B)
                .Entity(LeatherDo).Limit(0x277B, 0x27C6)
                .Entity(LeatherNinjaJacke).Limit(0x27DE)
                .Entity(LeatherTunic).Limit(0x13CC, 0x13D3)
                .Entity(LtArmorChest).Limit(0x2FC5, 0x317B)
                .Entity(LtfChest).Limit(0x2FCB, 0x3181)
                .Entity(NinjaJacket).Limit(0x2793)
                .Entity(PlateArmor).Limit(0x1C04, 0x1C05)
                .Entity(PlateDo).Limit(0x277D, 0x27C8)
                .Entity(Platemail).Limit(0x1415, 0x1416)
                .Entity(RingmailTunic).Limit(0x13EC, 0x13ED)
                .Entity(StuddedArmor).Limit(0x1C02, 0x1C03)
                .Entity(StuddedBustier).Limit(0x1C0C, 0x1C0D)
                .Entity(StuddedDo).Limit(0x277C, 0x27C7)
                .Entity(StuddedTunic).Limit(0x13DB, 0x13E2)
                .Entity(WoodlandBreastplat).Limit(0x315E)

                //Layer 14
                .Entity(Bracelet).Limit(0x1086, 0x1F06)

                //Layer 17
                .Entity(BodySash).Limit(0x1541, 0x1542)
                .Entity(Doublet).Limit(0x1F7B, 0x1F7C)
                .Entity(FormalShirt).Limit(0x230F, 0x2310)
                .Entity(FullApron).Limit(0x153D, 0x153E)
                .Entity(JesterSuit).Limit(0x1F9F, 0x1FA0)
                .Entity(JinBaori).Limit(0x27A1, 0x27EC)
                .Entity(Surcoat).Limit(0x1FFD, 0x1FFE)
                .Entity(Tunic).Limit(0x1FA1, 0x1FA2)

                //Layer 18
                .Entity(Earrings).Limit(0x1087, 0x1F07)

                //Layer 19
                .Entity(BoneArms).Limit(0x144E, 0x1453)
                .Entity(DragonSleeves).Limit(0x2657, 0x2658)
                .Entity(ElvenArmPlate).Limit(0x2B6C, 0x3163)
                .Entity(HaramakiDoArms).Limit(0x2674)
                .Entity(HidePaldrons).Limit(0x2B77, 0x316E)
                .Entity(KoteSleeves).Limit(0x266B, 0x266C, 0x266D, 0x266E)
                .Entity(LeatherSleeves).Limit(0x13C5, 0x13CD)
                .Entity(LtArmorPaldrons).Limit(0x2FC8, 0x317E)
                .Entity(PlatemailArms).Limit(0x1410, 0x1417)
                .Entity(RingmailSleeves).Limit(0x13EE, 0x13EF)
                .Entity(SamuraiArmorArms).Limit(0x277E, 0x277F, 0x2780, 0x27C9, 0x27CA, 0x27CB)
                .Entity(StuddedSleeves).Limit(0x13D4, 0x13DC)

                //Layer 20
                .Entity(ArcaneCloak).Limit(0x26AD)
                .Entity(ElvenQuiver).Limit(0x2FB7)
                .Entity(FurCape).Limit(0x2309, 0x230A)
                .Entity(MElvenQuiver).Limit(0x3171)
                .Entity(SimpleCloak).Limit(0x1515, 0x1530)

                //Layer 22
                .Entity(DeathShroud).Limit(0x204E, 0x25F0, 0x25F1, 0x2685, 0x2686, 0x2687)
                .Entity(GmRobe).Limit(0x204F)
                .Entity(HoodedShroud).Limit(0x2683, 0x2684)
                .Entity(ArcaneRobe).Limit(0x26AE)
                .Entity(ElvenRobe).Limit(0x2FB9, 0x2FBA)
                .Entity(FancyDress).Limit(0x1EFF, 0x1F00, 0x267B, 0x267C, 0x267D, 0x267E)
                .Entity(FemaleKimono).Limit(0x2783, 0x27CE)
                .Entity(GildedDress).Limit(0x230D, 0x230E)
                .Entity(HakamaShita).Limit(0x279C, 0x27E7)
                .Entity(Kamishimo).Limit(0x2799, 0x27E4)
                .Entity(Kimono).Limit(0x2681, 0x2682)
                .Entity(KimonoFemaleDres).Limit(0x279F, 0x27EA)
                .Entity(KimonoMaleDress).Limit(0x279E, 0x27E9)
                .Entity(LongDress).Limit(0x267F, 0x2680)
                .Entity(MaleKimono).Limit(0x2782, 0x27CD)
                .Entity(MElvenRobe01).Limit(0x3173)
                .Entity(MElvenRobe02).Limit(0x3174)
                .Entity(PlainDress).Limit(0x1F01, 0x1F02)
                .Entity(Robe).Limit(0x1F03, 0x1F04, 0x25EC, 0x25ED, 0x25EE, 0x25EF)

                //Layer 23
                .Entity(FurSurong).Limit(0x230B, 0x230C)
                .Entity(Hakama).Limit(0x279A, 0x27E5)
                .Entity(Kilt).Limit(0x1537, 0x1538)
                .Entity(KneeSkirt).Limit(0x25F2, 0x25F3)
                .Entity(SimpleSkirt).Limit(0x1516, 0x1531)

                .ToDictionary();
        }

        internal void LoadHueRanges()
        {
            HueRanges = new LimitCollection<TIdentity>()
                .Entity(Mobile).Limit(0)
                .Entity(Item).Limit(0)
                .ToDictionary();
        }

        internal void LoadContainers()
        {
            Containers = new List<TIdentity>
            {
                Corpse,
                Backpack
            };
        }

        internal void AddRange(Dictionary<HashSet<TIdentity>, List<Range>> rangesDictionary, IEnumerable<Range> values, params TIdentity[] identities)
        {
            var set = identities.ToHashSet();

            if (rangesDictionary.TryGetValue(set, out var ranges)) ranges.AddRange(values);

            else rangesDictionary.Add(set, values.ToList());
        }

        internal void AddRange(Dictionary<HashSet<TIdentity>, List<Range>> rangesDictionary, IEnumerable<ushort> values, params TIdentity[] identities) => AddRange(rangesDictionary, values.Select(v => v..v).ToArray(), identities);

        internal void AddGraphicRange(IEnumerable<ushort> values, params TIdentity[] identities) => AddRange(GraphicRanges, values, identities);

        internal void AddHueRange(Range range, params TIdentity[] identities) => AddRange(HueRanges, new[]{range}, identities);

        internal void AddHueRange(IEnumerable<ushort> values, params TIdentity[] identities) => AddRange(HueRanges, values, identities);
    }
}
