namespace Shard.Message.Domain.Incoming
{
    public interface ICharacterCreation
    {
        public int Pattern { get; set; }

        int Index { get; set; }

        string Name { get; set; }

        string Password { get; set; }

        byte Profession { get; set; }

        byte ClientFlags { get; set; }

        byte Gender { get; set; }

        byte Race { get; set; }

        short Strength { get; set; }

        short Dexterity { get; set; }

        short Intelligence { get; set; }

        short SkinColor { get; set; }

        int UnknownCharacterCreationFirst { get; set; }

        int UnknownCharacterCreationSecond { get; set; }

        byte SkillFirst { get; set; }

        byte SkillFirstValue { get; set; }

        byte SkillSecond { get; set; }

        byte SkillSecondValue { get; set; }

        byte SkillThird { get; set; }

        byte SkillThirdValue { get; set; }

        byte SkillFourth { get; set; }

        byte SkillFourthValue { get; set; }

        byte[] UnknownCharacterCreationThird { get; set; }

        byte UnknownCharacterCreationFourth { get; set; }

        short HairColor { get; set; }

        short HairStyle { get; set; }

        byte UnknownCharacterCreationFifth { get; set; }

        int UnknownCharacterCreationSixth { get; set; }

        byte UnknownCharacterCreationSeventh { get; set; }

        short ShirtColor { get; set; }

        short ShirtStyle { get; set; }

        byte UnknownCharacterCreationEighth { get; set; }

        short FaceColor { get; set; }

        short FaceStyle { get; set; }

        byte UnknownCharacterCreationNinth { get; set; }

        short BeardStyle { get; set; }

        short BeardColor { get; set; }

        internal int ReadCharacterCreation(IData data)
        {
            Pattern = data.ReadInt(3);

            Index = data.ReadInt(7);

            Name = data.ReadString(11, 30);

            Password = data.ReadString(41, 30);

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
