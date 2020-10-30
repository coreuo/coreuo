using Shard.Message.Domain.Shared;

namespace Shard.Message.Domain.Incoming
{
    public interface ICharacterCreation :
        IPattern,
        ISlot,
        IName,
        IClientFlags,
        IRace,
        IMobileStats
    {
        public string Password { get; set; }

        public byte Profession { get; set; }

        public byte Gender { get; set; }

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

        internal int ReadCharacterCreation(IData data)
        {
            Pattern = data.ReadInt(3);

            Slot = data.ReadInt(7);

            Name = data.ReadAscii(11, 30);

            Password = data.ReadAscii(41, 30);

            Profession = data.ReadByte(71);

            ClientFlags = data.ReadByte(72);

            Gender = data.ReadByte(73);

            Race = data.ReadByte(74);

            Strength = data.ReadByte(75);

            Dexterity = data.ReadByte(76);

            Intelligence = data.ReadByte(77);

            SkinColor = data.ReadShort(78);

            UnknownCharacterCreationFirst = data.ReadInt(80);

            UnknownCharacterCreationSecond = data.ReadInt(84);

            SkillFirst = data.ReadByte(88);

            SkillFirstValue = data.ReadByte(89);

            SkillSecond = data.ReadByte(90);

            SkillSecondValue = data.ReadByte(91);

            SkillThird = data.ReadByte(92);

            SkillThirdValue = data.ReadByte(93);

            SkillFourth = data.ReadByte(94);

            SkillFourthValue = data.ReadByte(95);

            UnknownCharacterCreationThird = data.ReadByteArray(96, 25);

            UnknownCharacterCreationFourth = data.ReadByte(121);

            HairColor = data.ReadShort(122);

            HairStyle = data.ReadShort(124);

            UnknownCharacterCreationFifth = data.ReadByte(126);

            UnknownCharacterCreationSixth = data.ReadInt(127);

            UnknownCharacterCreationSeventh = data.ReadByte(131);

            ShirtColor = data.ReadShort(132);

            ShirtStyle = data.ReadShort(134);

            UnknownCharacterCreationEighth = data.ReadByte(136);

            FaceColor = data.ReadShort(137);

            FaceStyle = data.ReadShort(139);

            UnknownCharacterCreationNinth = data.ReadByte(141);

            BeardStyle = data.ReadShort(142);

            BeardColor = data.ReadShort(144);

            return data.ReadShort(1);
        }
    }
}
