using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Launcher.Domain
{
    public class Mobile : Entity,
        Shard.Message.Domain.IMobile<Item, Skill>,
        Shard.Message.Extended.Domain.IMobile<Map, MapPatch>,
        Shard.Server.Domain.IMobile<Item, Entity, Identity>,
        Shard.Entity.Items.Domain.IMobile,
        Shard.Mobile.Race.Domain.IMobile
    {
        public short CurrentHitPoints { get; } = 67;

        public short MaximumHitPoints { get; } = 67;

        [NotMapped] public byte CanBeRenamed { get; } = 0;

        [NotMapped] public int ClientFlags { get; set; } = 0x6;

        [NotMapped] public byte LightLevel { get; } = 0;

        [NotMapped] public int LoginUnknownFirst { get; } = 0;

        [NotMapped] public byte UnknownMobileUpdateFirst { get; } = 0;

        [NotMapped] public short UnknownMobileUpdateSecond { get; } = 0;

        [NotMapped] public byte LoginUnknownSecond { get; } = 0xFF;

        [NotMapped] public byte StatusFlags { get; set; } = 0x10;

        public byte Gender { get; set; }

        public short Strength { get; set; } = 35;

        public short Dexterity { get; set; } = 35;

        public short Intelligence { get; set; } = 10;

        public short CurrentStamina { get; } = 35;

        public short MaximumStamina { get; } = 35;

        public short CurrentMana { get; } = 10;

        public short MaximumMana { get; } = 10;

        public int GoldInPack { get; } = 1267;

        public short ArmorRating { get; } = 44;

        public short Weight { get; } = 108;

        public short MaximumWeight { get; } = 222;

        public byte Race { get; set; }

        public short StatsCap { get; } = 225;

        public byte Followers { get; } = 0;

        public byte MaximumFollowers { get; } = 5;

        public short FireResist { get; } = 44;

        public short ColdResist { get; } = 44;

        public short PoisonResist { get; } = 44;

        public short EnergyResist { get; } = 44;

        public short Luck { get; } = 0;

        public short DamageMinimum { get; } = 2;

        public short DamageMaximum { get; } = 10;

        public int TithingPoints { get; } = 0;

        public short MaximumPhysicalResistance { get; } = 70;

        public short MaximumFireResistance { get; } = 70;

        public short MaximumColdResistance { get; } = 70;

        public short MaximumPoisonResistance { get; } = 70;

        public short MaximumEnergyResistance { get; } = 70;

        public short HitChanceIncrease { get; } = 0;

        public short SwingSpeedIncrease { get; } = 0;

        public short DamageChanceIncrease { get; } = 0;

        public short LowerReagentCost { get; } = 0;

        public short HitPointsRegeneration { get; } = 0;

        public short StaminaRegeneration { get; } = 0;

        public short ManaRegeneration { get; } = 0;

        public short ReflectPhysicalDamage { get; } = 0;

        public short EnhancePotions { get; } = 0;

        public short DefenseChanceIncrease { get; } = 0;

        public short SpellDamageIncrease { get; } = 0;

        public short FasterCastRecovery { get; } = 0;

        public short FasterCasting { get; } = 0;

        public short LowerManaCost { get; } = 0;

        public short StrengthIncrease { get; } = 0;

        public short DexterityIncrease { get; } = 0;

        public short IntelligenceIncrease { get; } = 0;

        public short HitPointsIncrease { get; } = 0;

        public short StaminaIncrease { get; } = 0;

        public short ManaIncrease { get; } = 0;

        public short MaximumHitPointsIncrease { get; } = 0;

        public short MaximumStaminaIncrease { get; } = 0;

        public short MaximumManaIncrease { get; } = 0;

        public byte Notoriety { get; } = 3;

        [NotMapped] public int LoginUnknownThird { get; } = 0;

        [NotMapped] public int LoginUnknownFourth { get; } = 0;

        [NotMapped] public byte LoginUnknownFifth { get; } = 0;

        [NotMapped] public ushort BoundaryWidth { get; } = 2304;

        [NotMapped] public ushort BoundaryHeight { get; } = 1600;

        [NotMapped] public ushort LoginUnknownSixth { get; } = 0;

        [NotMapped] public int LoginUnknownSeventh { get; } = 0;

        public List<Skill> Skills { get; } = Enumerable.Range(1, 58).ToList().Select(i => new Skill
        {
            SkillId = (ushort)i,
            Value = 1200,
            Base = 1200,
            Lock = 0,
            Cap = 1000

        }).ToList();

        [NotMapped] public string ProfileHeader { get; } = "Generic Humanoid";

        [NotMapped] public string ProfileGraphics { get; } = string.Empty;

        [NotMapped] public string ProfileFooter { get; } = "This account is 689 days old.";

        public byte WarMode { get; set; }
    }
}
