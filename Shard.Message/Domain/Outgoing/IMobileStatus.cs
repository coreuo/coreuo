using Shard.Message.Domain.Shared;

namespace Shard.Message.Domain.Outgoing
{
    public interface IMobileStatus :
        ISerial,
        IName,
        IAttributes,
        IClientFlags,
        IStats,
        IRace
    {
        byte CanBeRenamed { get; set; }

        byte Sex { get; set; }

        int GoldInPack { get; set; }

        short ArmorRating { get; set; }

        short Weight { get; set; }

        short MaximumWeight { get; set; }

        short StatsCap { get; set; }

        byte Followers { get; set; }

        byte MaximumFollowers { get; set; }

        short FireResist { get; set; }

        short ColdResist { get; set; }

        short PoisonResist { get; set; }

        short EnergyResist { get; set; }

        short Luck { get; set; }

        short DamageMinimum { get; set; }

        short DamageMaximum { get; set; }

        int TithingPoints { get; set; }

        short MaximumPhysicalResistance { get; set; }

        short MaximumFireResistance { get; set; }

        short MaximumColdResistance { get; set; }

        short MaximumPoisonResistance { get; set; }

        short MaximumEnergyResistance { get; set; }

        short HitChanceIncrease { get; set; }

        short SwingSpeedIncrease { get; set; }

        short DamageChanceIncrease { get; set; }

        short LowerReagentCost { get; set; }

        short HitPointsRegeneration { get; set; }

        short StaminaRegeneration { get; set; }

        short ManaRegeneration { get; set; }

        short ReflectPhysicalDamage { get; set; }

        short EnhancePotions { get; set; }

        short DefenseChanceIncrease { get; set; }

        short SpellDamageIncrease { get; set; }

        short FasterCastRecovery { get; set; }

        short FasterCasting { get; set; }

        short LowerManaCost { get; set; }

        short StrengthIncrease { get; set; }

        short DexterityIncrease { get; set; }

        short IntelligenceIncrease { get; set; }

        short HitPointsIncrease { get; set; }

        short StaminaIncrease { get; set; }

        short ManaIncrease { get; set; }

        short MaximumHitPointsIncrease { get; set; }

        short MaximumStaminaIncrease { get; set; }

        short MaximumManaIncrease { get; set; }

        internal void OnWriteMobileStatus(IData data)
        {
            data.OnWrite(3, Serial);

            data.OnWrite(7, Name);

            data.OnWrite(37, CurrentHitPoints);

            data.OnWrite(39, MaximumHitPoints);

            data.OnWrite(41, CanBeRenamed);

            data.OnWrite(42, ClientFlags);

            data.OnWrite(43, Sex);

            data.OnWrite(44, Strength);

            data.OnWrite(46, Dexterity);

            data.OnWrite(48, Intelligence);

            data.OnWrite(50, CurrentStamina);

            data.OnWrite(52, MaximumStamina);

            data.OnWrite(54, CurrentMana);

            data.OnWrite(56, MaximumMana);

            data.OnWrite(58, GoldInPack);

            data.OnWrite(62, ArmorRating);

            data.OnWrite(64, Weight);

            data.OnWrite(66, MaximumWeight);

            data.OnWrite(68, Race);

            data.OnWrite(69, StatsCap);

            data.OnWrite(71, Followers);

            data.OnWrite(72, MaximumFollowers);

            data.OnWrite(73, FireResist);

            data.OnWrite(75, ColdResist);

            data.OnWrite(77, PoisonResist);

            data.OnWrite(79, EnergyResist);

            data.OnWrite(81, Luck);

            data.OnWrite(83, DamageMinimum);

            data.OnWrite(85, DamageMaximum);

            data.OnWrite(87, TithingPoints);

            data.OnWrite(91, MaximumPhysicalResistance);

            data.OnWrite(93, MaximumFireResistance);

            data.OnWrite(95, MaximumColdResistance);

            data.OnWrite(97, MaximumPoisonResistance);

            data.OnWrite(99, MaximumEnergyResistance);

            data.OnWrite(101, DefenseChanceIncrease);

            data.OnWrite(103, (short) 45);

            data.OnWrite(105, HitChanceIncrease);

            data.OnWrite(107, SwingSpeedIncrease);

            data.OnWrite(109, DamageChanceIncrease);

            data.OnWrite(111, LowerReagentCost);

            data.OnWrite(113, SpellDamageIncrease);

            data.OnWrite(115, FasterCastRecovery);

            data.OnWrite(117, FasterCasting);

            data.OnWrite(119, LowerManaCost);

            data.OnWrite(121, HitChanceIncrease);

            data.OnWrite(123, SwingSpeedIncrease);

            data.OnWrite(125, DamageChanceIncrease);

            data.OnWrite(127, LowerReagentCost);

            data.OnWrite(129, HitPointsRegeneration);

            data.OnWrite(131, StaminaRegeneration);

            data.OnWrite(133, ManaRegeneration);

            data.OnWrite(135, ReflectPhysicalDamage);

            data.OnWrite(137, EnhancePotions);

            data.OnWrite(139, DefenseChanceIncrease);

            data.OnWrite(141, SpellDamageIncrease);

            data.OnWrite(143, FasterCastRecovery);

            data.OnWrite(145, FasterCasting);

            data.OnWrite(147, LowerManaCost);

            data.OnWrite(149, StrengthIncrease);

            data.OnWrite(151, DexterityIncrease);

            data.OnWrite(153, IntelligenceIncrease);

            data.OnWrite(155, HitPointsIncrease);

            data.OnWrite(157, StaminaIncrease);

            data.OnWrite(159, ManaIncrease);

            data.OnWrite(161, MaximumHitPointsIncrease);

            data.OnWrite(163, MaximumStaminaIncrease);

            data.OnWrite(165, MaximumManaIncrease);

        }
    }
}