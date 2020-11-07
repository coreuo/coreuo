using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Launcher.Domain
{
    public class Mobile : Entity,
        Shard.Message.Domain.IMobile<Item, Skill>,
        Shard.Message.Extended.Domain.IMobile<Map, MapPatch>,
        Shard.Server.Domain.IMobile<Item, Entity>,
        Shard.Mobiles.Domain.IMobile<Item>
    {
        [NotMapped] public int Pattern { get; set; }

        public int Slot { get; set; }

        [NotMapped] public string Password { get; set; }

        public byte Profession { get; set; }

        public short CurrentHitPoints { get; set; }

        public short MaximumHitPoints { get; set; }

        [NotMapped] public byte CanBeRenamed { get; set; }

        [NotMapped] public int ClientFlags { get; set; } = 0x6;

        [NotMapped] public byte LightLevel { get; set; }

        [NotMapped] public int LoginUnknownFirst { get; set; }

        public short Body { get; set; }

        [NotMapped] public byte UnknownMobileUpdateFirst { get; set; }

        [NotMapped] public short UnknownMobileUpdateSecond { get; set; }

        [NotMapped] public byte LoginUnknownSecond { get; set; } = 0xFF;

        public ushort Hue { get; set; }

        [NotMapped] public byte StatusFlags { get; set; } = 0x10;

        public byte Gender { get; set; }

        public byte Sex { get; set; }

        public short Strength { get; set; }

        public short SkinColor { get; set; }

        [NotMapped] public int UnknownCharacterCreationFirst { get; set; }

        [NotMapped] public int UnknownCharacterCreationSecond { get; set; }

        public byte SkillFirst { get; set; }

        public byte SkillFirstValue { get; set; }

        public byte SkillSecond { get; set; }

        public byte SkillSecondValue { get; set; }

        public byte SkillThird { get; set; }

        public byte SkillThirdValue { get; set; }

        public byte SkillFourth { get; set; }

        public byte SkillFourthValue { get; set; }

        [NotMapped] public byte[] UnknownCharacterCreationThird { get; set; }

        [NotMapped] public byte UnknownCharacterCreationFourth { get; set; }

        public short HairColor { get; set; }

        public short HairStyle { get; set; }

        [NotMapped] public byte UnknownCharacterCreationFifth { get; set; }

        [NotMapped] public int UnknownCharacterCreationSixth { get; set; }

        [NotMapped] public byte UnknownCharacterCreationSeventh { get; set; }

        public short ShirtColor { get; set; }

        public short ShirtStyle { get; set; }

        [NotMapped] public byte UnknownCharacterCreationEighth { get; set; }

        public short FaceColor { get; set; }

        public short FaceStyle { get; set; }

        [NotMapped] public byte UnknownCharacterCreationNinth { get; set; }

        public short BeardStyle { get; set; }

        public short BeardColor { get; set; }

        public short Dexterity { get; set; }

        public short Intelligence { get; set; }

        public short CurrentStamina { get; set; }

        public short MaximumStamina { get; set; }

        public short CurrentMana { get; set; }

        public short MaximumMana { get; set; }

        public int GoldInPack { get; set; }

        public short ArmorRating { get; set; }

        public short Weight { get; set; }

        public short MaximumWeight { get; set; }

        public byte Race { get; set; }

        public short StatsCap { get; set; }

        public byte Followers { get; set; }

        public byte MaximumFollowers { get; set; }

        public short FireResist { get; set; }

        public short ColdResist { get; set; }

        public short PoisonResist { get; set; }

        public short EnergyResist { get; set; }

        public short Luck { get; set; }

        public short DamageMinimum { get; set; }

        public short DamageMaximum { get; set; }

        public int TithingPoints { get; set; }

        public short MaximumPhysicalResistance { get; set; }

        public short MaximumFireResistance { get; set; }

        public short MaximumColdResistance { get; set; }

        public short MaximumPoisonResistance { get; set; }

        public short MaximumEnergyResistance { get; set; }

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

        public short MaximumHitPointsIncrease { get; set; }

        public short MaximumStaminaIncrease { get; set; }

        public short MaximumManaIncrease { get; set; }

        public byte Notoriety { get; set; }

        [NotMapped] public int LoginUnknownThird { get; set; }

        [NotMapped] public int LoginUnknownFourth { get; set; }

        [NotMapped] public byte LoginUnknownFifth { get; set; }

        [NotMapped] public ushort BoundaryWidth { get; set; } = 2304;

        [NotMapped] public ushort BoundaryHeight { get; set; } = 1600;

        [NotMapped] public ushort LoginUnknownSixth { get; set; }

        [NotMapped] public int LoginUnknownSeventh { get; set; }

        public List<Skill> Skills { get; set; } = Enumerable.Range(1, 58).ToList().Select(i => new Skill
        {
            SkillId = (ushort)i,
            Value = 1200,
            Base = 1200,
            Lock = 0,
            Cap = 1000

        }).ToList();

        [NotMapped] public short FirstLoginCharacterUnknown { get; set; }

        [NotMapped] public int SecondLoginCharacterUnknown { get; set; }

        public int LoginCount { get; set; }

        [NotMapped] public byte[] ThirdLoginCharacterUnknown { get; set; }

        [NotMapped] public int ClientIpAddress { get; set; }

        //[NotMapped] public byte FirstUnknownServerChange { get; set; }

        [NotMapped] public string ProfileHeader { get; set; } = "Generic Player";

        [NotMapped] public string ProfileBody { get; set; } = string.Empty;

        [NotMapped] public string ProfileFooter { get; set; } = "This account is 689 days old.";

        public byte WarMode { get; set; }
    }
}
