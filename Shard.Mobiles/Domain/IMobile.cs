﻿using System.Collections.Generic;

namespace Shard.Mobiles.Domain
{
    public interface IMobile<TItem>
        where TItem : IItem
    {
        string Name { get; set; }
        short CurrentHitPoints { get; set; }
        short MaximumHitPoints { get; set; }
        int ClientFlags { get; set; }
        byte LightLevel { get; set; }
        short Body { get; set; }
        ushort LocationX { get; set; }
        ushort LocationY { get; set; }
        byte LocationZ { get; set; }
        byte Direction { get; set; }
        short Hue { get; set; }
        byte StatusFlags { get; set; }
        //byte Gender { get; set; }
        byte Sex { get; set; }
        short Strength { get; set; }
        //short SkinColor { get; set; }
        //short HairColor { get; set; }
        //short HairStyle { get; set; }
        //short ShirtColor { get; set; }
        //short ShirtStyle { get; set; }
        //short FaceColor { get; set; }
        //short FaceStyle { get; set; }
        //short BeardStyle { get; set; }
        //short BeardColor { get; set; }
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
        //short HitChanceIncrease { get; set; }
        //short SwingSpeedIncrease { get; set; }
        //short DamageChanceIncrease { get; set; }
        //short LowerReagentCost { get; set; }
        //short HitPointsRegeneration { get; set; }
        //short StaminaRegeneration { get; set; }
        //short ManaRegeneration { get; set; }
        //short ReflectPhysicalDamage { get; set; }
        //short EnhancePotions { get; set; }
        //short DefenseChanceIncrease { get; set; }
        //short SpellDamageIncrease { get; set; }
        //short FasterCastRecovery { get; set; }
        //short FasterCasting { get; set; }
        //short LowerManaCost { get; set; }
        //short StrengthIncrease { get; set; }
        //short DexterityIncrease { get; set; }
        //short IntelligenceIncrease { get; set; }
        //short HitPointsIncrease { get; set; }
        //short StaminaIncrease { get; set; }
        //short ManaIncrease { get; set; }
        short MaximumHitPointsIncrease { get; set; }
        short MaximumStaminaIncrease { get; set; }
        short MaximumManaIncrease { get; set; }
        byte Notoriety { get; set; }
        List<TItem> Equipment { get; set; }
        //List<Skill> Skills { get; set; }
        //Map Map { get; set; }
        //string ProfileHeader { get; set; }
        //string ProfileBody { get; set; }
        //string ProfileFooter { get; set; }
        //int Serial { get; set; }
        //List<Attribute> Attributes { get; set; }
        //short EntityDisplayId { get; set; }
    }
}