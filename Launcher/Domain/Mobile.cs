using System.Collections.Generic;
using System.Linq;

namespace Launcher.Domain
{
    public class Mobile : 
        Shard.Message.Domain.IMobile<Item, Skill>,
        Shard.Message.Extended.Domain.IMobile<Map, MapPatch>,
        Shard.Server.Domain.IMobile
    {
        public int Pattern { get; set; }

        public int Index { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public byte Profession { get; set; }

        public short CurrentHitPoints { get; set; } = 67;

        public short MaximumHitPoints { get; set; } = 67;

        public byte CanBeRenamed { get; set; }

        public byte ClientFlags { get; set; } = 0x6;

        public int Serial { get; set; } = 1;

        public byte LightLevel { get; set; } = 0;

        public int LoginUnknownFirst { get; set; }

        public short Body { get; set; } = 400;

        public byte UnknownMobileUpdateFirst { get; set; }

        public ushort LocationX { get; set; } = 819;

        public ushort LocationY { get; set; } = 621;

        public short UnknownMobileUpdateSecond { get; set; }

        public byte LoginUnknownSecond { get; set; } = 0xFF;

        public byte LocationZ { get; set; } = 0xD8;

        public byte Direction { get; set; } = 132;

        public short Hue { get; set; } = -31745;

        public byte StatusFlags { get; set; } = 0x50;

        public byte Gender { get; set; }

        public byte Sex { get; set; } = 0;

        public short Strength { get; set; } = 35;

        public short SkinColor { get; set; }

        public int UnknownCharacterCreationFirst { get; set; }

        public int UnknownCharacterCreationSecond { get; set; }

        public byte SkillFirst { get; set; }

        public byte SkillFirstValue { get; set; }

        public byte SkillSecond { get; set; }

        public byte SkillSecondValue { get; set; }

        public byte SkillThird { get; set; }

        public byte SkillThirdValue { get; set; }

        public byte SkillFourth { get; set; }

        public byte SkillFourthValue { get; set; }

        public byte[] UnknownCharacterCreationThird { get; set; }

        public byte UnknownCharacterCreationFourth { get; set; }

        public short HairColor { get; set; }

        public short HairStyle { get; set; }

        public byte UnknownCharacterCreationFifth { get; set; }

        public int UnknownCharacterCreationSixth { get; set; }

        public byte UnknownCharacterCreationSeventh { get; set; }

        public short ShirtColor { get; set; }

        public short ShirtStyle { get; set; }

        public byte UnknownCharacterCreationEighth { get; set; }

        public short FaceColor { get; set; }

        public short FaceStyle { get; set; }

        public byte UnknownCharacterCreationNinth { get; set; }

        public short BeardStyle { get; set; }

        public short BeardColor { get; set; }

        public short Dexterity { get; set; } = 35;

        public short Intelligence { get; set; } = 10;

        public short CurrentStamina { get; set; } = 35;

        public short MaximumStamina { get; set; } = 35;

        public short CurrentMana { get; set; } = 10;

        public short MaximumMana { get; set; } = 10;

        public int GoldInPack { get; set; } = 1267;

        public short ArmorRating { get; set; } = 44;

        public short Weight { get; set; } = 108;

        public short MaximumWeight { get; set; } = 222;

        public byte Race { get; set; } = 1;

        public short StatsCap { get; set; } = 225;

        public byte Followers { get; set; } = 0;

        public byte MaximumFollowers { get; set; } = 5;

        public short FireResist { get; set; } = 44;

        public short ColdResist { get; set; } = 44;

        public short PoisonResist { get; set; } = 44;

        public short EnergyResist { get; set; } = 44;

        public short Luck { get; set; } = 0;

        public short DamageMinimum { get; set; } = 2;

        public short DamageMaximum { get; set; } = 10;

        public int TithingPoints { get; set; }

        public short MaximumPhysicalResistance { get; set; } = -1;

        public short MaximumFireResistance { get; set; } = -1;

        public short MaximumColdResistance { get; set; } = -1;

        public short MaximumPoisonResistance { get; set; } = -1;

        public short MaximumEnergyResistance { get; set; } = -1;

        public short HitChanceIncrease { get; set; }

        public short SwingSpeedIncrease { get; set; }

        public short DamageChanceIncrease { get; set; }

        public short LowerReagentCost { get; set; }

        public short HitPointsRegeneration { get; set; }

        public short StaminaRegeneration { get; set; }

        public short ManaRegeneration { get; set; }

        public short ReflectPhysicalDamage { get; set; }

        public short EnhancePotions { get; set; }

        public short DefenseChanceIncrease { get; set; }

        public short SpellDamageIncrease { get; set; }

        public short FasterCastRecovery { get; set; }

        public short FasterCasting { get; set; }

        public short LowerManaCost { get; set; }

        public short StrengthIncrease { get; set; }

        public short DexterityIncrease { get; set; }

        public short IntelligenceIncrease { get; set; }

        public short HitPointsIncrease { get; set; }

        public short StaminaIncrease { get; set; }

        public short ManaIncrease { get; set; }

        public short MaximumHitPointsIncrease { get; set; } = 67;

        public short MaximumStaminaIncrease { get; set; } = 35;

        public short MaximumManaIncrease { get; set; } = 10;

        public byte Notoriety { get; set; } = 3;

        public List<Item> Equipment { get; set; } = new List<Item>
        {
            new Item{Serial = 1073741848, ItemId = 3701, Layer = 21},
            new Item{Serial = 1073741853, ItemId = 5068, Layer = 13},
            new Item{Serial = 1073741855, ItemId = 40707, Layer = 22, Hue = 1721},
            new Item{Serial = 1073741860, ItemId = 38167, Layer = 5, Hue = 2},
            new Item{Serial = 1073741861, ItemId = 38190, Layer = 4, Hue = 2},
            new Item{Serial = 1073741862, ItemId = 38671, Layer = 3, Hue = 1729},
            new Item{Serial = 2147482617, ItemId = 47940, Layer = 15, Hue = 1023}
        };

        public int LoginUnknownThird { get; set; }

        public int LoginUnknownFourth { get; set; }

        public byte LoginUnknownFifth { get; set; }

        public ushort BoundaryWidth { get; set; } = 2304;

        public ushort BoundaryHeight { get; set; } = 1600;

        public ushort LoginUnknownSixth { get; set; }

        public int LoginUnknownSeventh { get; set; }

        public List<Skill> Skills { get; } = Enumerable.Range(1, 58).ToList().Select(i => new Skill
        {
            Id = (ushort) i,
            Value = 1200,
            Base = 1200,
            Lock = 0,
            Cap = 1000

        }).ToList();

        public Map Map { get; } = new Map();
    }
}
