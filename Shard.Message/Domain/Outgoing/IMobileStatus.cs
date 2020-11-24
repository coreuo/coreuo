using Shard.Message.Domain.Shared;
using System;

namespace Shard.Message.Domain.Outgoing
{
    public interface IMobileStatus :
        ISerialGet,
        IName,
        Shared.IMobileAttributes,
        IClientFlags,
        IMobileStats,
        IRace
    {
        public byte CanBeRenamed { get; }

        public byte Gender { get; }

        public int GoldInPack { get; }

        public short ArmorRating { get; }

        public short Weight { get; }

        public short MaximumWeight { get; }

        public short StatsCap { get; }

        public byte Followers { get; }

        public byte MaximumFollowers { get; }

        public short FireResist { get; }

        public short ColdResist { get; }

        public short PoisonResist { get; }

        public short EnergyResist { get; }

        public short Luck { get; }

        public short DamageMinimum { get; }

        public short DamageMaximum { get; }

        public int TithingPoints { get; }

        public short MaximumPhysicalResistance { get; }

        public short MaximumFireResistance { get; }

        public short MaximumColdResistance { get; }

        public short MaximumPoisonResistance { get; }

        public short MaximumEnergyResistance { get; }

        public short HitChanceIncrease { get; }

        public short SwingSpeedIncrease { get; }

        public short DamageChanceIncrease { get; }

        public short LowerReagentCost { get; }

        public short HitPointsRegeneration { get; }

        public short StaminaRegeneration { get; }

        public short ManaRegeneration { get; }

        public short ReflectPhysicalDamage { get; }

        public short EnhancePotions { get; }

        public short DefenseChanceIncrease { get; }

        public short SpellDamageIncrease { get; }

        public short FasterCastRecovery { get; }

        public short FasterCasting { get; }

        public short LowerManaCost { get; }

        public short StrengthIncrease { get; }

        public short DexterityIncrease { get; }

        public short IntelligenceIncrease { get; }

        public short HitPointsIncrease { get; }

        public short StaminaIncrease { get; }

        public short ManaIncrease { get; }

        public short MaximumHitPointsIncrease { get; }

        public short MaximumStaminaIncrease { get; }

        public short MaximumManaIncrease { get; }

        internal void WriteMobileStatus(IData data)
        {
            if (Name == null) throw new InvalidOperationException($"Unknown mobile ({this}) name.");

            data.Write(3, Serial);

            data.WriteAscii(7, Name, 30);

            data.Write(37, CurrentHitPoints);

            data.Write(39, MaximumHitPoints);

            data.Write(41, CanBeRenamed);

            data.Write(42, (byte)ClientFlags);

            data.Write(43, Gender);

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