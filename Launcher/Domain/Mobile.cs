using System.Collections.Generic;
using System.Linq;

namespace Launcher.Domain
{
    using Property = Shard.Validation.Handlers<Validation>;

    public class Mobile : Entity,
        Shard.Message.Domain.IMobile<Item, Skill>,
        Shard.Message.Extended.Domain.IMobile<Map, MapPatch>,
        Shard.Server.Domain.IMobile<Item>,
        Shard.Mobiles.Domain.IMobile<Item>
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
            get => Property.Get<int>(this, nameof(Pattern));
            set => Property.Set(this, nameof(Pattern), value);
        }

        public int Slot
        {
            get => Property.Get<int>(this, nameof(Slot));
            set => Property.Set(this, nameof(Slot), value);
        }

        public string Name
        {
            get => Property.Get<string>(this, nameof(Name));
            set => Property.Set(this, nameof(Name), value);
        }

        public string Password
        {
            get => Property.Get<string>(this, nameof(Password));
            set => Property.Set(this, nameof(Password), value);
        }

        public byte Profession
        {
            get => Property.Get<byte>(this, nameof(Profession));
            set => Property.Set(this, nameof(Profession), value);
        }

        public short CurrentHitPoints
        {
            get => Property.Get<short>(this, nameof(CurrentHitPoints));
            set => Property.Set(this, nameof(CurrentHitPoints), value);
        }

        public short MaximumHitPoints
        {
            get => Property.Get<short>(this, nameof(MaximumHitPoints));
            set => Property.Set(this, nameof(MaximumHitPoints), value);
        }

        public byte CanBeRenamed
        {
            get => Property.Get<byte>(this, nameof(CanBeRenamed));
            set => Property.Set(this, nameof(CanBeRenamed), value);
        }

        public int ClientFlags
        {
            get => Property.Get<int>(this, nameof(ClientFlags));
            set => Property.Set(this, nameof(ClientFlags), value, () => 0x6);
        }

        public byte LightLevel
        {
            get => Property.Get<byte>(this, nameof(LightLevel));
            set => Property.Set(this, nameof(LightLevel), value);
        }

        public int LoginUnknownFirst
        {
            get => Property.Get<int>(this, nameof(LoginUnknownFirst));
            set => Property.Set(this, nameof(LoginUnknownFirst), value);
        }

        public short Body
        {
            get => Property.Get<short>(this, nameof(Body));
            set => Property.Set(this, nameof(Body), value);
        }

        public byte UnknownMobileUpdateFirst
        {
            get => Property.Get<byte>(this, nameof(UnknownMobileUpdateFirst));
            set => Property.Set(this, nameof(UnknownMobileUpdateFirst), value);
        }

        public ushort LocationX
        {
            get => Property.Get<ushort>(this, nameof(LocationX));
            set => Property.Set(this, nameof(LocationX), value);
        }

        public ushort LocationY
        {
            get => Property.Get<ushort>(this, nameof(LocationY));
            set => Property.Set(this, nameof(LocationY), value);
        }

        public short UnknownMobileUpdateSecond
        {
            get => Property.Get<short>(this, nameof(UnknownMobileUpdateSecond));
            set => Property.Set(this, nameof(UnknownMobileUpdateSecond), value);
        }

        public byte LoginUnknownSecond
        {
            get => Property.Get<byte>(this, nameof(LoginUnknownSecond));
            set => Property.Set(this, nameof(LoginUnknownSecond), value, () => 0xFF);
        }

        public byte LocationZ
        {
            get => Property.Get<byte>(this, nameof(LocationZ));
            set => Property.Set(this, nameof(LocationZ), value);
        }

        public byte Direction
        {
            get => Property.Get<byte>(this, nameof(Direction));
            set => Property.Set(this, nameof(Direction), value);
        }

        public short Hue
        {
            get => Property.Get<short>(this, nameof(Hue));
            set => Property.Set(this, nameof(Hue), value);
        }

        public byte StatusFlags
        {
            get => Property.Get<byte>(this, nameof(StatusFlags));
            set => Property.Set(this, nameof(StatusFlags), value, () => 0x50);
        }

        public byte Gender
        {
            get => Property.Get<byte>(this, nameof(Gender));
            set => Property.Set(this, nameof(Gender), value);
        }

        public byte Sex
        {
            get => Property.Get<byte>(this, nameof(Sex));
            set => Property.Set(this, nameof(Sex), value);
        }

        public short Strength
        {
            get => Property.Get<short>(this, nameof(Strength));
            set => Property.Set(this, nameof(Strength), value);
        }

        public short SkinColor
        {
            get => Property.Get<short>(this, nameof(SkinColor));
            set => Property.Set(this, nameof(SkinColor), value);
        }

        public int UnknownCharacterCreationFirst
        {
            get => Property.Get<int>(this, nameof(UnknownCharacterCreationFirst));
            set => Property.Set(this, nameof(UnknownCharacterCreationFirst), value);
        }

        public int UnknownCharacterCreationSecond
        {
            get => Property.Get<int>(this, nameof(UnknownCharacterCreationSecond));
            set => Property.Set(this, nameof(UnknownCharacterCreationSecond), value);
        }

        public byte SkillFirst
        {
            get => Property.Get<byte>(this, nameof(SkillFirst));
            set => Property.Set(this, nameof(SkillFirst), value);
        }

        public byte SkillFirstValue
        {
            get => Property.Get<byte>(this, nameof(SkillFirstValue));
            set => Property.Set(this, nameof(SkillFirstValue), value);
        }

        public byte SkillSecond
        {
            get => Property.Get<byte>(this, nameof(SkillSecond));
            set => Property.Set(this, nameof(SkillSecond), value);
        }

        public byte SkillSecondValue
        {
            get => Property.Get<byte>(this, nameof(SkillSecondValue));
            set => Property.Set(this, nameof(SkillSecondValue), value);
        }

        public byte SkillThird
        {
            get => Property.Get<byte>(this, nameof(SkillThird));
            set => Property.Set(this, nameof(SkillThird), value);
        }

        public byte SkillThirdValue
        {
            get => Property.Get<byte>(this, nameof(SkillThirdValue));
            set => Property.Set(this, nameof(SkillThirdValue), value);
        }

        public byte SkillFourth
        {
            get => Property.Get<byte>(this, nameof(SkillFourth));
            set => Property.Set(this, nameof(SkillFourth), value);
        }

        public byte SkillFourthValue
        {
            get => Property.Get<byte>(this, nameof(SkillFourthValue));
            set => Property.Set(this, nameof(SkillFourthValue), value);
        }

        public byte[] UnknownCharacterCreationThird
        {
            get => Property.Get<byte[]>(this, nameof(UnknownCharacterCreationThird));
            set => Property.Set(this, nameof(UnknownCharacterCreationThird), value);
        }

        public byte UnknownCharacterCreationFourth
        {
            get => Property.Get<byte>(this, nameof(UnknownCharacterCreationFourth));
            set => Property.Set(this, nameof(UnknownCharacterCreationFourth), value);
        }

        public short HairColor
        {
            get => Property.Get<short>(this, nameof(HairColor));
            set => Property.Set(this, nameof(HairColor), value);
        }

        public short HairStyle
        {
            get => Property.Get<short>(this, nameof(HairStyle));
            set => Property.Set(this, nameof(HairStyle), value);
        }

        public byte UnknownCharacterCreationFifth
        {
            get => Property.Get<byte>(this, nameof(UnknownCharacterCreationFifth));
            set => Property.Set(this, nameof(UnknownCharacterCreationFifth), value);
        }

        public int UnknownCharacterCreationSixth
        {
            get => Property.Get<int>(this, nameof(UnknownCharacterCreationSixth));
            set => Property.Set(this, nameof(UnknownCharacterCreationSixth), value);
        }

        public byte UnknownCharacterCreationSeventh
        {
            get => Property.Get<byte>(this, nameof(UnknownCharacterCreationSeventh));
            set => Property.Set(this, nameof(UnknownCharacterCreationSeventh), value);
        }

        public short ShirtColor
        {
            get => Property.Get<short>(this, nameof(ShirtColor));
            set => Property.Set(this, nameof(ShirtColor), value);
        }

        public short ShirtStyle
        {
            get => Property.Get<short>(this, nameof(ShirtStyle));
            set => Property.Set(this, nameof(ShirtStyle), value);
        }

        public byte UnknownCharacterCreationEighth
        {
            get => Property.Get<byte>(this, nameof(UnknownCharacterCreationEighth));
            set => Property.Set(this, nameof(UnknownCharacterCreationEighth), value);
        }

        public short FaceColor
        {
            get => Property.Get<short>(this, nameof(FaceColor));
            set => Property.Set(this, nameof(FaceColor), value);
        }

        public short FaceStyle
        {
            get => Property.Get<short>(this, nameof(FaceStyle));
            set => Property.Set(this, nameof(FaceStyle), value);
        }

        public byte UnknownCharacterCreationNinth
        {
            get => Property.Get<byte>(this, nameof(UnknownCharacterCreationNinth));
            set => Property.Set(this, nameof(UnknownCharacterCreationNinth), value);
        }

        public short BeardStyle
        {
            get => Property.Get<short>(this, nameof(BeardStyle));
            set => Property.Set(this, nameof(BeardStyle), value);
        }

        public short BeardColor
        {
            get => Property.Get<short>(this, nameof(BeardColor));
            set => Property.Set(this, nameof(BeardColor), value);
        }

        public short Dexterity
        {
            get => Property.Get<short>(this, nameof(Dexterity));
            set => Property.Set(this, nameof(Dexterity), value);
        }

        public short Intelligence
        {
            get => Property.Get<short>(this, nameof(Intelligence));
            set => Property.Set(this, nameof(Intelligence), value);
        }

        public short CurrentStamina
        {
            get => Property.Get<short>(this, nameof(CurrentStamina));
            set => Property.Set(this, nameof(CurrentStamina), value);
        }

        public short MaximumStamina
        {
            get => Property.Get<short>(this, nameof(MaximumStamina));
            set => Property.Set(this, nameof(MaximumStamina), value);
        }

        public short CurrentMana
        {
            get => Property.Get<short>(this, nameof(CurrentMana));
            set => Property.Set(this, nameof(CurrentMana), value);
        }

        public short MaximumMana
        {
            get => Property.Get<short>(this, nameof(MaximumMana));
            set => Property.Set(this, nameof(MaximumMana), value);
        }

        public int GoldInPack
        {
            get => Property.Get<int>(this, nameof(GoldInPack));
            set => Property.Set(this, nameof(GoldInPack), value);
        }

        public short ArmorRating
        {
            get => Property.Get<short>(this, nameof(ArmorRating));
            set => Property.Set(this, nameof(ArmorRating), value);
        }

        public short Weight
        {
            get => Property.Get<short>(this, nameof(Weight));
            set => Property.Set(this, nameof(Weight), value);
        }

        public short MaximumWeight
        {
            get => Property.Get<short>(this, nameof(MaximumWeight));
            set => Property.Set(this, nameof(MaximumWeight), value);
        }

        public byte Race
        {
            get => Property.Get<byte>(this, nameof(Race));
            set => Property.Set(this, nameof(Race), value);
        }

        public short StatsCap
        {
            get => Property.Get<short>(this, nameof(StatsCap));
            set => Property.Set(this, nameof(StatsCap), value);
        }

        public byte Followers
        {
            get => Property.Get<byte>(this, nameof(Followers));
            set => Property.Set(this, nameof(Followers), value);
        }

        public byte MaximumFollowers
        {
            get => Property.Get<byte>(this, nameof(MaximumFollowers));
            set => Property.Set(this, nameof(MaximumFollowers), value);
        }

        public short FireResist
        {
            get => Property.Get<short>(this, nameof(FireResist));
            set => Property.Set(this, nameof(FireResist), value);
        }

        public short ColdResist
        {
            get => Property.Get<short>(this, nameof(ColdResist));
            set => Property.Set(this, nameof(ColdResist), value);
        }

        public short PoisonResist
        {
            get => Property.Get<short>(this, nameof(PoisonResist));
            set => Property.Set(this, nameof(PoisonResist), value);
        }

        public short EnergyResist
        {
            get => Property.Get<short>(this, nameof(EnergyResist));
            set => Property.Set(this, nameof(EnergyResist), value);
        }

        public short Luck
        {
            get => Property.Get<short>(this, nameof(Luck));
            set => Property.Set(this, nameof(Luck), value);
        }

        public short DamageMinimum
        {
            get => Property.Get<short>(this, nameof(DamageMinimum));
            set => Property.Set(this, nameof(DamageMinimum), value);
        }

        public short DamageMaximum
        {
            get => Property.Get<short>(this, nameof(DamageMaximum));
            set => Property.Set(this, nameof(DamageMaximum), value);
        }

        public int TithingPoints
        {
            get => Property.Get<int>(this, nameof(TithingPoints));
            set => Property.Set(this, nameof(TithingPoints), value);
        }

        public short MaximumPhysicalResistance
        {
            get => Property.Get<short>(this, nameof(MaximumPhysicalResistance));
            set => Property.Set(this, nameof(MaximumPhysicalResistance), value);
        }

        public short MaximumFireResistance
        {
            get => Property.Get<short>(this, nameof(MaximumFireResistance));
            set => Property.Set(this, nameof(MaximumFireResistance), value);
        }

        public short MaximumColdResistance
        {
            get => Property.Get<short>(this, nameof(MaximumColdResistance));
            set => Property.Set(this, nameof(MaximumColdResistance), value);
        }

        public short MaximumPoisonResistance
        {
            get => Property.Get<short>(this, nameof(MaximumPoisonResistance));
            set => Property.Set(this, nameof(MaximumPoisonResistance), value);
        }

        public short MaximumEnergyResistance
        {
            get => Property.Get<short>(this, nameof(MaximumEnergyResistance));
            set => Property.Set(this, nameof(MaximumEnergyResistance), value);
        }

        public short HitChanceIncrease
        {
            get => Property.Get<short>(this, nameof(HitChanceIncrease));
            set => Property.Set(this, nameof(HitChanceIncrease), value);
        }

        public short SwingSpeedIncrease
        {
            get => Property.Get<short>(this, nameof(SwingSpeedIncrease));
            set => Property.Set(this, nameof(SwingSpeedIncrease), value);
        }

        public short DamageChanceIncrease
        {
            get => Property.Get<short>(this, nameof(DamageChanceIncrease));
            set => Property.Set(this, nameof(DamageChanceIncrease), value);
        }

        public short LowerReagentCost
        {
            get => Property.Get<short>(this, nameof(LowerReagentCost));
            set => Property.Set(this, nameof(LowerReagentCost), value);
        }

        public short HitPointsRegeneration
        {
            get => Property.Get<short>(this, nameof(HitPointsRegeneration));
            set => Property.Set(this, nameof(HitPointsRegeneration), value);
        }

        public short StaminaRegeneration
        {
            get => Property.Get<short>(this, nameof(StaminaRegeneration));
            set => Property.Set(this, nameof(StaminaRegeneration), value);
        }

        public short ManaRegeneration
        {
            get => Property.Get<short>(this, nameof(ManaRegeneration));
            set => Property.Set(this, nameof(ManaRegeneration), value);
        }

        public short ReflectPhysicalDamage
        {
            get => Property.Get<short>(this, nameof(ReflectPhysicalDamage));
            set => Property.Set(this, nameof(ReflectPhysicalDamage), value);
        }

        public short EnhancePotions
        {
            get => Property.Get<short>(this, nameof(EnhancePotions));
            set => Property.Set(this, nameof(EnhancePotions), value);
        }

        public short DefenseChanceIncrease
        {
            get => Property.Get<short>(this, nameof(DefenseChanceIncrease));
            set => Property.Set(this, nameof(DefenseChanceIncrease), value);
        }

        public short SpellDamageIncrease
        {
            get => Property.Get<short>(this, nameof(SpellDamageIncrease));
            set => Property.Set(this, nameof(SpellDamageIncrease), value);
        }

        public short FasterCastRecovery
        {
            get => Property.Get<short>(this, nameof(FasterCastRecovery));
            set => Property.Set(this, nameof(FasterCastRecovery), value);
        }

        public short FasterCasting
        {
            get => Property.Get<short>(this, nameof(FasterCasting));
            set => Property.Set(this, nameof(FasterCasting), value);
        }

        public short LowerManaCost
        {
            get => Property.Get<short>(this, nameof(LowerManaCost));
            set => Property.Set(this, nameof(LowerManaCost), value);
        }

        public short StrengthIncrease
        {
            get => Property.Get<short>(this, nameof(StrengthIncrease));
            set => Property.Set(this, nameof(StrengthIncrease), value);
        }

        public short DexterityIncrease
        {
            get => Property.Get<short>(this, nameof(DexterityIncrease));
            set => Property.Set(this, nameof(DexterityIncrease), value);
        }

        public short IntelligenceIncrease
        {
            get => Property.Get<short>(this, nameof(IntelligenceIncrease));
            set => Property.Set(this, nameof(IntelligenceIncrease), value);
        }

        public short HitPointsIncrease
        {
            get => Property.Get<short>(this, nameof(HitPointsIncrease));
            set => Property.Set(this, nameof(HitPointsIncrease), value);
        }

        public short StaminaIncrease
        {
            get => Property.Get<short>(this, nameof(StaminaIncrease));
            set => Property.Set(this, nameof(StaminaIncrease), value);
        }

        public short ManaIncrease
        {
            get => Property.Get<short>(this, nameof(ManaIncrease));
            set => Property.Set(this, nameof(ManaIncrease), value);
        }

        public short MaximumHitPointsIncrease
        {
            get => Property.Get<short>(this, nameof(MaximumHitPointsIncrease));
            set => Property.Set(this, nameof(MaximumHitPointsIncrease), value);
        }

        public short MaximumStaminaIncrease
        {
            get => Property.Get<short>(this, nameof(MaximumStaminaIncrease));
            set => Property.Set(this, nameof(MaximumStaminaIncrease), value);
        }

        public short MaximumManaIncrease
        {
            get => Property.Get<short>(this, nameof(MaximumManaIncrease));
            set => Property.Set(this, nameof(MaximumManaIncrease), value);
        }

        public byte Notoriety
        {
            get => Property.Get<byte>(this, nameof(Notoriety));
            set => Property.Set(this, nameof(Notoriety), value);
        }

        public List<Item> Equipment
        {
            get => Property.Get<List<Item>>(this, nameof(Equipment));
            set => Property.Set(this, nameof(Equipment), value);
        }

        public int LoginUnknownThird
        {
            get => Property.Get<int>(this, nameof(LoginUnknownThird));
            set => Property.Set(this, nameof(LoginUnknownThird), value);
        }

        public int LoginUnknownFourth
        {
            get => Property.Get<int>(this, nameof(LoginUnknownFourth));
            set => Property.Set(this, nameof(LoginUnknownFourth), value);
        }

        public byte LoginUnknownFifth
        {
            get => Property.Get<byte>(this, nameof(LoginUnknownFifth));
            set => Property.Set(this, nameof(LoginUnknownFifth), value);
        }

        public ushort BoundaryWidth
        {
            get => Property.Get<ushort>(this, nameof(BoundaryWidth));
            set => Property.Set(this, nameof(BoundaryWidth), value, () => 2304);
        }

        public ushort BoundaryHeight
        {
            get => Property.Get<ushort>(this, nameof(BoundaryHeight));
            set => Property.Set(this, nameof(BoundaryHeight), value, () => 1600);
        }

        public ushort LoginUnknownSixth
        {
            get => Property.Get<ushort>(this, nameof(LoginUnknownSixth));
            set => Property.Set(this, nameof(LoginUnknownSixth), value);
        }

        public int LoginUnknownSeventh
        {
            get => Property.Get<int>(this, nameof(LoginUnknownSeventh));
            set => Property.Set(this, nameof(LoginUnknownSeventh), value);
        }

        public List<Skill> Skills
        {
            get => Property.Get<List<Skill>>(this, nameof(Skills));
            set => Property.Set(this, nameof(Skills), value, () => Enumerable.Range(1, 58).ToList().Select(i =>
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
            get => Property.Get<Map>(this, nameof(Map));
            set => Property.Set(this, nameof(Map), value, () => new Map());
        }

        public short FirstLoginCharacterUnknown
        {
            get => Property.Get<short>(this, nameof(FirstLoginCharacterUnknown));
            set => Property.Set(this, nameof(FirstLoginCharacterUnknown), value);
        }

        public int SecondLoginCharacterUnknown
        {
            get => Property.Get<int>(this, nameof(SecondLoginCharacterUnknown));
            set => Property.Set(this, nameof(SecondLoginCharacterUnknown), value);
        }

        public int LoginCount
        {
            get => Property.Get<int>(this, nameof(LoginCount));
            set => Property.Set(this, nameof(LoginCount), value);
        }

        public byte[] ThirdLoginCharacterUnknown
        {
            get => Property.Get<byte[]>(this, nameof(ThirdLoginCharacterUnknown));
            set => Property.Set(this, nameof(ThirdLoginCharacterUnknown), value);
        }

        public int ClientIpAddress
        {
            get => Property.Get<int>(this, nameof(ClientIpAddress));
            set => Property.Set(this, nameof(ClientIpAddress), value);
        }

        public byte FirstUnknownServerChange
        {
            get => Property.Get<byte>(this, nameof(FirstUnknownServerChange));
            set => Property.Set(this, nameof(FirstUnknownServerChange), value);
        }

        public string ProfileHeader
        {
            get => Property.Get<string>(this, nameof(ProfileHeader));
            set => Property.Set(this, nameof(ProfileHeader), value, () => "Generic Player, Legendary Alchemist");
        }

        public string ProfileBody
        {
            get => Property.Get<string>(this, nameof(ProfileBody));
            set => Property.Set(this, nameof(ProfileBody), value, () => string.Empty);
        }

        public string ProfileFooter
        {
            get => Property.Get<string>(this, nameof(ProfileFooter));
            set => Property.Set(this, nameof(ProfileFooter), value, () => "This account is 689 days old.");
        }
    }
}
