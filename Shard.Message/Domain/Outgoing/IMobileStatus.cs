using Shard.Message.Domain.Shared;

namespace Shard.Message.Domain.Outgoing
{
    public interface IMobileStatus :
        ISerial,
        IName,
        Shared.IMobileAttributes,
        IClientFlags,
        IMobileStats,
        IRace
    {
        public byte CanBeRenamed { get; set; }

        public byte Sex { get; set; }

        public int GoldInPack { get; set; }

        public short ArmorRating { get; set; }

        public short Weight { get; set; }

        public short MaximumWeight { get; set; }

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

        internal void WriteMobileStatus(IData data)
        {
            data.Write(3, Serial);

            data.WriteAscii(7, Name, 30);

            data.Write(37, CurrentHitPoints);

            data.Write(39, MaximumHitPoints);

            data.Write(41, CanBeRenamed);

            data.Write(42, (byte)ClientFlags);

            data.Write(43, Sex);

            data.Write(44, Strength);

            data.Write(46, Dexterity);

            data.Write(48, Intelligence);

            data.Write(50, CurrentStamina);

            data.Write(52, MaximumStamina);

            data.Write(54, CurrentMana);

            data.Write(56, MaximumMana);

            data.Write(58, GoldInPack);

            data.Write(62, ArmorRating);

            data.Write(64, Weight);

            data.Write(66, MaximumWeight);

            data.Write(68, Race);

            data.Write(69, StatsCap);

            data.Write(71, Followers);

            data.Write(72, MaximumFollowers);

            data.Write(73, FireResist);

            data.Write(75, ColdResist);

            data.Write(77, PoisonResist);

            data.Write(79, EnergyResist);

            data.Write(81, Luck);

            data.Write(83, DamageMinimum);

            data.Write(85, DamageMaximum);

            data.Write(87, TithingPoints);

            data.Write(91, MaximumPhysicalResistance);

            data.Write(93, MaximumFireResistance);

            data.Write(95, MaximumColdResistance);

            data.Write(97, MaximumPoisonResistance);

            data.Write(99, MaximumEnergyResistance);

            data.Write(101, DefenseChanceIncrease);

            data.Write(103, (short) 45);

            data.Write(105, HitChanceIncrease);

            data.Write(107, SwingSpeedIncrease);

            data.Write(109, DamageChanceIncrease);

            data.Write(111, LowerReagentCost);

            data.Write(113, SpellDamageIncrease);

            data.Write(115, FasterCastRecovery);

            data.Write(117, FasterCasting);

            data.Write(119, LowerManaCost);

            data.Write(121, HitChanceIncrease);

            data.Write(123, SwingSpeedIncrease);

            data.Write(125, DamageChanceIncrease);

            data.Write(127, LowerReagentCost);

            data.Write(129, HitPointsRegeneration);

            data.Write(131, StaminaRegeneration);

            data.Write(133, ManaRegeneration);

            data.Write(135, ReflectPhysicalDamage);

            data.Write(137, EnhancePotions);

            data.Write(139, DefenseChanceIncrease);

            data.Write(141, SpellDamageIncrease);

            data.Write(143, FasterCastRecovery);

            data.Write(145, FasterCasting);

            data.Write(147, LowerManaCost);

            data.Write(149, StrengthIncrease);

            data.Write(151, DexterityIncrease);

            data.Write(153, IntelligenceIncrease);

            data.Write(155, HitPointsIncrease);

            data.Write(157, StaminaIncrease);

            data.Write(159, ManaIncrease);

            data.Write(161, MaximumHitPointsIncrease);

            data.Write(163, MaximumStaminaIncrease);

            data.Write(165, MaximumManaIncrease);

        }
    }
}