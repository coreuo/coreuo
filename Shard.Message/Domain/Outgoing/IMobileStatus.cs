namespace Shard.Message.Domain.Outgoing
{
    public interface IMobileStatus
    {
        int Serial { get; set; }

        string Name { get; set; }

        short CurrentHitPoints { get; set; }

        short MaximumHitPoints { get; set; }

        byte CanBeRenamed { get; set; }

        byte ClientFlags { get; set; }

        byte Sex { get; set; }

        short Strength { get; set; }

        short Dexterity { get; set; }

        short Intelligence { get; set; }

        short CurrentStamina { get; set; }

        short MaximumStamina { get; set; }

        short CurrentMana { get; set; }

        short MaximumMana { get; set; }

        int GoldInPack { get; set; }

        short ArmorRating { get; set; }

        short Weight { get; set; }

        short MaximumWeight { get; set; }

        byte Race { get; set; }

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

        internal void WriteMobileStatus(IData data)
        {
            data.Write(3, Serial);

            data.Write(7, Name);

            data.Write(37, CurrentHitPoints);

            data.Write(39, MaximumHitPoints);

            data.Write(41, CanBeRenamed);

            data.Write(42, ClientFlags);

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