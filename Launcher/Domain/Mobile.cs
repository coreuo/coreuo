using System.Collections.Generic;
using System.Linq;

namespace Launcher.Domain
{
    using Property = Shard.Server.Validation.Handlers<Validation>;

    public class Mobile : Entity,
        Shard.Message.Domain.IMobile<Item, Skill, Map>,
        Shard.Message.Extended.Domain.IMobile<Map, MapPatch>,
        Shard.Server.Domain.IMobile
    {
        public Mobile()
        {
            Pattern = default;
            Slot = default;
            Name = default;
            Password = default;
            Profession = default;
            CurrentHitPoints = default;
            MaximumHitPoints = default;
            CanBeRenamed = default;
            ClientFlags = default;
            LightLevel = default;
            LoginUnknownFirst = default;
            Body = default;
            UnknownMobileUpdateFirst = default;
            LocationX = default;
            LocationY = default;
            UnknownMobileUpdateSecond = default;
            LoginUnknownSecond = default;
            LocationZ = default;
            Direction = default;
            Hue = default;
            StatusFlags = default;
            Gender = default;
            Sex = default;
            Strength = default;
            SkinColor = default;
            UnknownCharacterCreationFirst = default;
            UnknownCharacterCreationSecond = default;
            SkillFirst = default;
            SkillFirstValue = default;
            SkillSecond = default;
            SkillSecondValue = default;
            SkillThird = default;
            SkillThirdValue = default;
            SkillFourth = default;
            SkillFourthValue = default;
            UnknownCharacterCreationThird = default;
            UnknownCharacterCreationFourth = default;
            HairColor = default;
            HairStyle = default;
            UnknownCharacterCreationFifth = default;
            UnknownCharacterCreationSixth = default;
            UnknownCharacterCreationSeventh = default;
            ShirtColor = default;
            ShirtStyle = default;
            UnknownCharacterCreationEighth = default;
            FaceColor = default;
            FaceStyle = default;
            UnknownCharacterCreationNinth = default;
            BeardStyle = default;
            BeardColor = default;
            Dexterity = default;
            Intelligence = default;
            CurrentStamina = default;
            MaximumStamina = default;
            CurrentMana = default;
            MaximumMana = default;
            GoldInPack = default;
            ArmorRating = default;
            Weight = default;
            MaximumWeight = default;
            Race = default;
            StatsCap = default;
            Followers = default;
            MaximumFollowers = default;
            FireResist = default;
            ColdResist = default;
            PoisonResist = default;
            EnergyResist = default;
            Luck = default;
            DamageMinimum = default;
            DamageMaximum = default;
            TithingPoints = default;
            MaximumPhysicalResistance = default;
            MaximumFireResistance = default;
            MaximumColdResistance = default;
            MaximumPoisonResistance = default;
            MaximumEnergyResistance = default;
            HitChanceIncrease = default;
            SwingSpeedIncrease = default;
            DamageChanceIncrease = default;
            LowerReagentCost = default;
            HitPointsRegeneration = default;
            StaminaRegeneration = default;
            ManaRegeneration = default;
            ReflectPhysicalDamage = default;
            EnhancePotions = default;
            DefenseChanceIncrease = default;
            SpellDamageIncrease = default;
            FasterCastRecovery = default;
            FasterCasting = default;
            LowerManaCost = default;
            StrengthIncrease = default;
            DexterityIncrease = default;
            IntelligenceIncrease = default;
            HitPointsIncrease = default;
            StaminaIncrease = default;
            ManaIncrease = default;
            MaximumHitPointsIncrease = default;
            MaximumStaminaIncrease = default;
            MaximumManaIncrease = default;
            Notoriety = default;
            Equipment = default;
            LoginUnknownThird = default;
            LoginUnknownFourth = default;
            LoginUnknownFifth = default;
            BoundaryWidth = default;
            BoundaryHeight = default;
            LoginUnknownSixth = default;
            LoginUnknownSeventh = default;
            Skills = default;
            Map = default;
            FirstLoginCharacterUnknown = default;
            SecondLoginCharacterUnknown = default;
            LoginCount = default;
            ThirdLoginCharacterUnknown = default;
            ClientIpAddress = default;
            FirstUnknownServerChange = default;
            ProfileHeader = default;
            ProfileBody = default;
            ProfileFooter = default;
        }

        public int Pattern
        {
            get => Property.OnGet<int>(this, nameof(Pattern));
            set => Property.OnSet(this, nameof(Pattern), value);
        }

        public int Slot
        {
            get => Property.OnGet<int>(this, nameof(Slot));
            set => Property.OnSet(this, nameof(Slot), value);
        }

        public string Name
        {
            get => Property.OnGet<string>(this, nameof(Name));
            set => Property.OnSet(this, nameof(Name), value);
        }

        public string Password
        {
            get => Property.OnGet<string>(this, nameof(Password));
            set => Property.OnSet(this, nameof(Password), value);
        }

        public byte Profession
        {
            get => Property.OnGet<byte>(this, nameof(Profession));
            set => Property.OnSet(this, nameof(Profession), value);
        }

        public short CurrentHitPoints
        {
            get => Property.OnGet<short>(this, nameof(CurrentHitPoints));
            set => Property.OnSet(this, nameof(CurrentHitPoints), value, () => 67);
        }

        public short MaximumHitPoints
        {
            get => Property.OnGet<short>(this, nameof(MaximumHitPoints));
            set => Property.OnSet(this, nameof(MaximumHitPoints), value, () => 67);
        }

        public byte CanBeRenamed
        {
            get => Property.OnGet<byte>(this, nameof(CanBeRenamed));
            set => Property.OnSet(this, nameof(CanBeRenamed), value);
        }

        public int ClientFlags
        {
            get => Property.OnGet<int>(this, nameof(ClientFlags));
            set => Property.OnSet(this, nameof(ClientFlags), value, () => 0x6);
        }

        public byte LightLevel
        {
            get => Property.OnGet<byte>(this, nameof(LightLevel));
            set => Property.OnSet(this, nameof(LightLevel), value, () => 0);
        }

        public int LoginUnknownFirst
        {
            get => Property.OnGet<int>(this, nameof(LoginUnknownFirst));
            set => Property.OnSet(this, nameof(LoginUnknownFirst), value);
        }

        public short Body
        {
            get => Property.OnGet<short>(this, nameof(Body));
            set => Property.OnSet(this, nameof(Body), value, () => 400);
        }

        public byte UnknownMobileUpdateFirst
        {
            get => Property.OnGet<byte>(this, nameof(UnknownMobileUpdateFirst));
            set => Property.OnSet(this, nameof(UnknownMobileUpdateFirst), value);
        }

        public ushort LocationX
        {
            get => Property.OnGet<ushort>(this, nameof(LocationX));
            set => Property.OnSet(this, nameof(LocationX), value, () => 819);
        }

        public ushort LocationY
        {
            get => Property.OnGet<ushort>(this, nameof(LocationY));
            set => Property.OnSet(this, nameof(LocationY), value, () => 621);
        }

        public short UnknownMobileUpdateSecond
        {
            get => Property.OnGet<short>(this, nameof(UnknownMobileUpdateSecond));
            set => Property.OnSet(this, nameof(UnknownMobileUpdateSecond), value);
        }

        public byte LoginUnknownSecond
        {
            get => Property.OnGet<byte>(this, nameof(LoginUnknownSecond));
            set => Property.OnSet(this, nameof(LoginUnknownSecond), value, () => 0xFF);
        }

        public byte LocationZ
        {
            get => Property.OnGet<byte>(this, nameof(LocationZ));
            set => Property.OnSet(this, nameof(LocationZ), value, () => 0xD8);
        }

        public byte Direction
        {
            get => Property.OnGet<byte>(this, nameof(Direction));
            set => Property.OnSet(this, nameof(Direction), value, () => 132);
        }

        public short Hue
        {
            get => Property.OnGet<short>(this, nameof(Hue));
            set => Property.OnSet(this, nameof(Hue), value, () => -31745);
        }

        public byte StatusFlags
        {
            get => Property.OnGet<byte>(this, nameof(StatusFlags));
            set => Property.OnSet(this, nameof(StatusFlags), value, () => 0x50);
        }

        public byte Gender
        {
            get => Property.OnGet<byte>(this, nameof(Gender));
            set => Property.OnSet(this, nameof(Gender), value);
        }

        public byte Sex
        {
            get => Property.OnGet<byte>(this, nameof(Sex));
            set => Property.OnSet(this, nameof(Sex), value, () => 0);
        }

        public short Strength
        {
            get => Property.OnGet<short>(this, nameof(Strength));
            set => Property.OnSet(this, nameof(Strength), value, () => 35);
        }

        public short SkinColor
        {
            get => Property.OnGet<short>(this, nameof(SkinColor));
            set => Property.OnSet(this, nameof(SkinColor), value);
        }

        public int UnknownCharacterCreationFirst
        {
            get => Property.OnGet<int>(this, nameof(UnknownCharacterCreationFirst));
            set => Property.OnSet(this, nameof(UnknownCharacterCreationFirst), value);
        }

        public int UnknownCharacterCreationSecond
        {
            get => Property.OnGet<int>(this, nameof(UnknownCharacterCreationSecond));
            set => Property.OnSet(this, nameof(UnknownCharacterCreationSecond), value);
        }

        public byte SkillFirst
        {
            get => Property.OnGet<byte>(this, nameof(SkillFirst));
            set => Property.OnSet(this, nameof(SkillFirst), value);
        }

        public byte SkillFirstValue
        {
            get => Property.OnGet<byte>(this, nameof(SkillFirstValue));
            set => Property.OnSet(this, nameof(SkillFirstValue), value);
        }

        public byte SkillSecond
        {
            get => Property.OnGet<byte>(this, nameof(SkillSecond));
            set => Property.OnSet(this, nameof(SkillSecond), value);
        }

        public byte SkillSecondValue
        {
            get => Property.OnGet<byte>(this, nameof(SkillSecondValue));
            set => Property.OnSet(this, nameof(SkillSecondValue), value);
        }

        public byte SkillThird
        {
            get => Property.OnGet<byte>(this, nameof(SkillThird));
            set => Property.OnSet(this, nameof(SkillThird), value);
        }

        public byte SkillThirdValue
        {
            get => Property.OnGet<byte>(this, nameof(SkillThirdValue));
            set => Property.OnSet(this, nameof(SkillThirdValue), value);
        }

        public byte SkillFourth
        {
            get => Property.OnGet<byte>(this, nameof(SkillFourth));
            set => Property.OnSet(this, nameof(SkillFourth), value);
        }

        public byte SkillFourthValue
        {
            get => Property.OnGet<byte>(this, nameof(SkillFourthValue));
            set => Property.OnSet(this, nameof(SkillFourthValue), value);
        }

        public byte[] UnknownCharacterCreationThird
        {
            get => Property.OnGet<byte[]>(this, nameof(UnknownCharacterCreationThird));
            set => Property.OnSet(this, nameof(UnknownCharacterCreationThird), value);
        }

        public byte UnknownCharacterCreationFourth
        {
            get => Property.OnGet<byte>(this, nameof(UnknownCharacterCreationFourth));
            set => Property.OnSet(this, nameof(UnknownCharacterCreationFourth), value);
        }

        public short HairColor
        {
            get => Property.OnGet<short>(this, nameof(HairColor));
            set => Property.OnSet(this, nameof(HairColor), value);
        }

        public short HairStyle
        {
            get => Property.OnGet<short>(this, nameof(HairStyle));
            set => Property.OnSet(this, nameof(HairStyle), value);
        }

        public byte UnknownCharacterCreationFifth
        {
            get => Property.OnGet<byte>(this, nameof(UnknownCharacterCreationFifth));
            set => Property.OnSet(this, nameof(UnknownCharacterCreationFifth), value);
        }

        public int UnknownCharacterCreationSixth
        {
            get => Property.OnGet<int>(this, nameof(UnknownCharacterCreationSixth));
            set => Property.OnSet(this, nameof(UnknownCharacterCreationSixth), value);
        }

        public byte UnknownCharacterCreationSeventh
        {
            get => Property.OnGet<byte>(this, nameof(UnknownCharacterCreationSeventh));
            set => Property.OnSet(this, nameof(UnknownCharacterCreationSeventh), value);
        }

        public short ShirtColor
        {
            get => Property.OnGet<short>(this, nameof(ShirtColor));
            set => Property.OnSet(this, nameof(ShirtColor), value);
        }

        public short ShirtStyle
        {
            get => Property.OnGet<short>(this, nameof(ShirtStyle));
            set => Property.OnSet(this, nameof(ShirtStyle), value);
        }

        public byte UnknownCharacterCreationEighth
        {
            get => Property.OnGet<byte>(this, nameof(UnknownCharacterCreationEighth));
            set => Property.OnSet(this, nameof(UnknownCharacterCreationEighth), value);
        }

        public short FaceColor
        {
            get => Property.OnGet<short>(this, nameof(FaceColor));
            set => Property.OnSet(this, nameof(FaceColor), value);
        }

        public short FaceStyle
        {
            get => Property.OnGet<short>(this, nameof(FaceStyle));
            set => Property.OnSet(this, nameof(FaceStyle), value);
        }

        public byte UnknownCharacterCreationNinth
        {
            get => Property.OnGet<byte>(this, nameof(UnknownCharacterCreationNinth));
            set => Property.OnSet(this, nameof(UnknownCharacterCreationNinth), value);
        }

        public short BeardStyle
        {
            get => Property.OnGet<short>(this, nameof(BeardStyle));
            set => Property.OnSet(this, nameof(BeardStyle), value);
        }

        public short BeardColor
        {
            get => Property.OnGet<short>(this, nameof(BeardColor));
            set => Property.OnSet(this, nameof(BeardColor), value);
        }

        public short Dexterity
        {
            get => Property.OnGet<short>(this, nameof(Dexterity));
            set => Property.OnSet(this, nameof(Dexterity), value, () => 35);
        }

        public short Intelligence
        {
            get => Property.OnGet<short>(this, nameof(Intelligence));
            set => Property.OnSet(this, nameof(Intelligence), value, () => 10);
        }

        public short CurrentStamina
        {
            get => Property.OnGet<short>(this, nameof(CurrentStamina));
            set => Property.OnSet(this, nameof(CurrentStamina), value, () => 35);
        }

        public short MaximumStamina
        {
            get => Property.OnGet<short>(this, nameof(MaximumStamina));
            set => Property.OnSet(this, nameof(MaximumStamina), value, () => 35);
        }

        public short CurrentMana
        {
            get => Property.OnGet<short>(this, nameof(CurrentMana));
            set => Property.OnSet(this, nameof(CurrentMana), value, () => 10);
        }

        public short MaximumMana
        {
            get => Property.OnGet<short>(this, nameof(MaximumMana));
            set => Property.OnSet(this, nameof(MaximumMana), value, () => 10);
        }

        public int GoldInPack
        {
            get => Property.OnGet<int>(this, nameof(GoldInPack));
            set => Property.OnSet(this, nameof(GoldInPack), value, () => 1267);
        }

        public short ArmorRating
        {
            get => Property.OnGet<short>(this, nameof(ArmorRating));
            set => Property.OnSet(this, nameof(ArmorRating), value, () => 44);
        }

        public short Weight
        {
            get => Property.OnGet<short>(this, nameof(Weight));
            set => Property.OnSet(this, nameof(Weight), value, () => 108);
        }

        public short MaximumWeight
        {
            get => Property.OnGet<short>(this, nameof(MaximumWeight));
            set => Property.OnSet(this, nameof(MaximumWeight), value, () => 222);
        }

        public byte Race
        {
            get => Property.OnGet<byte>(this, nameof(Race));
            set => Property.OnSet(this, nameof(Race), value, () => 1);
        }

        public short StatsCap
        {
            get => Property.OnGet<short>(this, nameof(StatsCap));
            set => Property.OnSet(this, nameof(StatsCap), value, () => 225);
        }

        public byte Followers
        {
            get => Property.OnGet<byte>(this, nameof(Followers));
            set => Property.OnSet(this, nameof(Followers), value, () => 0);
        }

        public byte MaximumFollowers
        {
            get => Property.OnGet<byte>(this, nameof(MaximumFollowers));
            set => Property.OnSet(this, nameof(MaximumFollowers), value, () => 5);
        }

        public short FireResist
        {
            get => Property.OnGet<short>(this, nameof(FireResist));
            set => Property.OnSet(this, nameof(FireResist), value, () => 44);
        }

        public short ColdResist
        {
            get => Property.OnGet<short>(this, nameof(ColdResist));
            set => Property.OnSet(this, nameof(ColdResist), value, () => 44);
        }

        public short PoisonResist
        {
            get => Property.OnGet<short>(this, nameof(PoisonResist));
            set => Property.OnSet(this, nameof(PoisonResist), value, () => 44);
        }

        public short EnergyResist
        {
            get => Property.OnGet<short>(this, nameof(EnergyResist));
            set => Property.OnSet(this, nameof(EnergyResist), value, () => 44);
        }

        public short Luck
        {
            get => Property.OnGet<short>(this, nameof(Luck));
            set => Property.OnSet(this, nameof(Luck), value, () => 0);
        }

        public short DamageMinimum
        {
            get => Property.OnGet<short>(this, nameof(DamageMinimum));
            set => Property.OnSet(this, nameof(DamageMinimum), value, () => 2);
        }

        public short DamageMaximum
        {
            get => Property.OnGet<short>(this, nameof(DamageMaximum));
            set => Property.OnSet(this, nameof(DamageMaximum), value, () => 10);
        }

        public int TithingPoints
        {
            get => Property.OnGet<int>(this, nameof(TithingPoints));
            set => Property.OnSet(this, nameof(TithingPoints), value);
        }

        public short MaximumPhysicalResistance
        {
            get => Property.OnGet<short>(this, nameof(MaximumPhysicalResistance));
            set => Property.OnSet(this, nameof(MaximumPhysicalResistance), value, () => -1);
        }

        public short MaximumFireResistance
        {
            get => Property.OnGet<short>(this, nameof(MaximumFireResistance));
            set => Property.OnSet(this, nameof(MaximumFireResistance), value, () => -1);
        }

        public short MaximumColdResistance
        {
            get => Property.OnGet<short>(this, nameof(MaximumColdResistance));
            set => Property.OnSet(this, nameof(MaximumColdResistance), value, () => -1);
        }

        public short MaximumPoisonResistance
        {
            get => Property.OnGet<short>(this, nameof(MaximumPoisonResistance));
            set => Property.OnSet(this, nameof(MaximumPoisonResistance), value, () => -1);
        }

        public short MaximumEnergyResistance
        {
            get => Property.OnGet<short>(this, nameof(MaximumEnergyResistance));
            set => Property.OnSet(this, nameof(MaximumEnergyResistance), value, () => -1);
        }

        public short HitChanceIncrease
        {
            get => Property.OnGet<short>(this, nameof(HitChanceIncrease));
            set => Property.OnSet(this, nameof(HitChanceIncrease), value);
        }

        public short SwingSpeedIncrease
        {
            get => Property.OnGet<short>(this, nameof(SwingSpeedIncrease));
            set => Property.OnSet(this, nameof(SwingSpeedIncrease), value);
        }

        public short DamageChanceIncrease
        {
            get => Property.OnGet<short>(this, nameof(DamageChanceIncrease));
            set => Property.OnSet(this, nameof(DamageChanceIncrease), value);
        }

        public short LowerReagentCost
        {
            get => Property.OnGet<short>(this, nameof(LowerReagentCost));
            set => Property.OnSet(this, nameof(LowerReagentCost), value);
        }

        public short HitPointsRegeneration
        {
            get => Property.OnGet<short>(this, nameof(HitPointsRegeneration));
            set => Property.OnSet(this, nameof(HitPointsRegeneration), value);
        }

        public short StaminaRegeneration
        {
            get => Property.OnGet<short>(this, nameof(StaminaRegeneration));
            set => Property.OnSet(this, nameof(StaminaRegeneration), value);
        }

        public short ManaRegeneration
        {
            get => Property.OnGet<short>(this, nameof(ManaRegeneration));
            set => Property.OnSet(this, nameof(ManaRegeneration), value);
        }

        public short ReflectPhysicalDamage
        {
            get => Property.OnGet<short>(this, nameof(ReflectPhysicalDamage));
            set => Property.OnSet(this, nameof(ReflectPhysicalDamage), value);
        }

        public short EnhancePotions
        {
            get => Property.OnGet<short>(this, nameof(EnhancePotions));
            set => Property.OnSet(this, nameof(EnhancePotions), value);
        }

        public short DefenseChanceIncrease
        {
            get => Property.OnGet<short>(this, nameof(DefenseChanceIncrease));
            set => Property.OnSet(this, nameof(DefenseChanceIncrease), value);
        }

        public short SpellDamageIncrease
        {
            get => Property.OnGet<short>(this, nameof(SpellDamageIncrease));
            set => Property.OnSet(this, nameof(SpellDamageIncrease), value);
        }

        public short FasterCastRecovery
        {
            get => Property.OnGet<short>(this, nameof(FasterCastRecovery));
            set => Property.OnSet(this, nameof(FasterCastRecovery), value);
        }

        public short FasterCasting
        {
            get => Property.OnGet<short>(this, nameof(FasterCasting));
            set => Property.OnSet(this, nameof(FasterCasting), value);
        }

        public short LowerManaCost
        {
            get => Property.OnGet<short>(this, nameof(LowerManaCost));
            set => Property.OnSet(this, nameof(LowerManaCost), value);
        }

        public short StrengthIncrease
        {
            get => Property.OnGet<short>(this, nameof(StrengthIncrease));
            set => Property.OnSet(this, nameof(StrengthIncrease), value);
        }

        public short DexterityIncrease
        {
            get => Property.OnGet<short>(this, nameof(DexterityIncrease));
            set => Property.OnSet(this, nameof(DexterityIncrease), value);
        }

        public short IntelligenceIncrease
        {
            get => Property.OnGet<short>(this, nameof(IntelligenceIncrease));
            set => Property.OnSet(this, nameof(IntelligenceIncrease), value);
        }

        public short HitPointsIncrease
        {
            get => Property.OnGet<short>(this, nameof(HitPointsIncrease));
            set => Property.OnSet(this, nameof(HitPointsIncrease), value);
        }

        public short StaminaIncrease
        {
            get => Property.OnGet<short>(this, nameof(StaminaIncrease));
            set => Property.OnSet(this, nameof(StaminaIncrease), value);
        }

        public short ManaIncrease
        {
            get => Property.OnGet<short>(this, nameof(ManaIncrease));
            set => Property.OnSet(this, nameof(ManaIncrease), value);
        }

        public short MaximumHitPointsIncrease
        {
            get => Property.OnGet<short>(this, nameof(MaximumHitPointsIncrease));
            set => Property.OnSet(this, nameof(MaximumHitPointsIncrease), value, () => 67);
        }

        public short MaximumStaminaIncrease
        {
            get => Property.OnGet<short>(this, nameof(MaximumStaminaIncrease));
            set => Property.OnSet(this, nameof(MaximumStaminaIncrease), value, () => 35);
        }

        public short MaximumManaIncrease
        {
            get => Property.OnGet<short>(this, nameof(MaximumManaIncrease));
            set => Property.OnSet(this, nameof(MaximumManaIncrease), value, () => 10);
        }

        public byte Notoriety
        {
            get => Property.OnGet<byte>(this, nameof(Notoriety));
            set => Property.OnSet(this, nameof(Notoriety), value, () => 3);
        }

        public List<Item> Equipment
        {
            get => Property.OnGet<List<Item>>(this, nameof(Equipment));
            set => Property.OnSet(this, nameof(Equipment), value, () => new List<Item>
            {
                new Item {Serial = 1073741848, ItemId = 3701, Layer = 21},
                new Item {Serial = 1073741853, ItemId = 5068, Layer = 13},
                new Item {Serial = 1073741855, ItemId = 40707, Layer = 22, Hue = 1721},
                new Item {Serial = 1073741860, ItemId = 38167, Layer = 5, Hue = 2},
                new Item {Serial = 1073741861, ItemId = 38190, Layer = 4, Hue = 2},
                new Item {Serial = 1073741862, ItemId = 38671, Layer = 3, Hue = 1729},
                new Item {Serial = 2147482617, ItemId = 47940, Layer = 15, Hue = 1023}
            });
        }

        public int LoginUnknownThird
        {
            get => Property.OnGet<int>(this, nameof(LoginUnknownThird));
            set => Property.OnSet(this, nameof(LoginUnknownThird), value);
        }

        public int LoginUnknownFourth
        {
            get => Property.OnGet<int>(this, nameof(LoginUnknownFourth));
            set => Property.OnSet(this, nameof(LoginUnknownFourth), value);
        }

        public byte LoginUnknownFifth
        {
            get => Property.OnGet<byte>(this, nameof(LoginUnknownFifth));
            set => Property.OnSet(this, nameof(LoginUnknownFifth), value);
        }

        public ushort BoundaryWidth
        {
            get => Property.OnGet<ushort>(this, nameof(BoundaryWidth));
            set => Property.OnSet(this, nameof(BoundaryWidth), value, () => 2304);
        }

        public ushort BoundaryHeight
        {
            get => Property.OnGet<ushort>(this, nameof(BoundaryHeight));
            set => Property.OnSet(this, nameof(BoundaryHeight), value, () => 1600);
        }

        public ushort LoginUnknownSixth
        {
            get => Property.OnGet<ushort>(this, nameof(LoginUnknownSixth));
            set => Property.OnSet(this, nameof(LoginUnknownSixth), value);
        }

        public int LoginUnknownSeventh
        {
            get => Property.OnGet<int>(this, nameof(LoginUnknownSeventh));
            set => Property.OnSet(this, nameof(LoginUnknownSeventh), value);
        }

        public List<Skill> Skills
        {
            get => Property.OnGet<List<Skill>>(this, nameof(Skills));
            set => Property.OnSet(this, nameof(Skills), value, () => Enumerable.Range(1, 58).ToList().Select(i =>
                new Skill
                {
                    Id = (ushort) i,
                    Value = 1200,
                    Base = 1200,
                    Lock = 0,
                    Cap = 1000

                }).ToList());
        }

        public Map Map
        {
            get => Property.OnGet<Map>(this, nameof(Map));
            set => Property.OnSet(this, nameof(Map), value, () => new Map());
        }

        public short FirstLoginCharacterUnknown
        {
            get => Property.OnGet<short>(this, nameof(FirstLoginCharacterUnknown));
            set => Property.OnSet(this, nameof(FirstLoginCharacterUnknown), value);
        }

        public int SecondLoginCharacterUnknown
        {
            get => Property.OnGet<int>(this, nameof(SecondLoginCharacterUnknown));
            set => Property.OnSet(this, nameof(SecondLoginCharacterUnknown), value);
        }

        public int LoginCount
        {
            get => Property.OnGet<int>(this, nameof(LoginCount));
            set => Property.OnSet(this, nameof(LoginCount), value);
        }

        public byte[] ThirdLoginCharacterUnknown
        {
            get => Property.OnGet<byte[]>(this, nameof(ThirdLoginCharacterUnknown));
            set => Property.OnSet(this, nameof(ThirdLoginCharacterUnknown), value);
        }

        public int ClientIpAddress
        {
            get => Property.OnGet<int>(this, nameof(ClientIpAddress));
            set => Property.OnSet(this, nameof(ClientIpAddress), value);
        }

        public byte FirstUnknownServerChange
        {
            get => Property.OnGet<byte>(this, nameof(FirstUnknownServerChange));
            set => Property.OnSet(this, nameof(FirstUnknownServerChange), value);
        }

        public string ProfileHeader
        {
            get => Property.OnGet<string>(this, nameof(ProfileHeader));
            set => Property.OnSet(this, nameof(ProfileHeader), value, () => "Generic Player, Legendary Alchemist");
        }

        public string ProfileBody
        {
            get => Property.OnGet<string>(this, nameof(ProfileBody));
            set => Property.OnSet(this, nameof(ProfileBody), value, () => string.Empty);
        }

        public string ProfileFooter
        {
            get => Property.OnGet<string>(this, nameof(ProfileFooter));
            set => Property.OnSet(this, nameof(ProfileFooter), value, () => "This account is 689 days old.");
        }
    }
}
