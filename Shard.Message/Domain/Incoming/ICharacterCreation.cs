using Shard.Message.Domain.Shared;

namespace Shard.Message.Domain.Incoming
{
    public interface ICharacterCreation :
        IPattern,
        ISlot,
        IName,
        IClientFlags,
        IRace,
        IStats
    {
        string Password { get; set; }

        byte Profession { get; set; }

        byte Gender { get; set; }

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

        internal int OnReadCharacterCreation(IData data)
        {
            Pattern = data.OnReadInt(3);

            Slot = data.OnReadInt(7);

            Name = data.OnReadString(11, 30);

            Password = data.OnReadString(41, 30);

            Profession = data.OnReadByte(71);

            ClientFlags = data.OnReadByte(72);

            Gender = data.OnReadByte(73);

            Race = data.OnReadByte(74);

            Strength = data.OnReadByte(75);

            Dexterity = data.OnReadByte(76);

            Intelligence = data.OnReadByte(77);

            SkinColor = data.OnReadShort(78);

            UnknownCharacterCreationFirst = data.OnReadInt(80);

            UnknownCharacterCreationSecond = data.OnReadInt(84);

            SkillFirst = data.OnReadByte(88);

            SkillFirstValue = data.OnReadByte(89);

            SkillSecond = data.OnReadByte(90);

            SkillSecondValue = data.OnReadByte(91);

            SkillThird = data.OnReadByte(92);

            SkillThirdValue = data.OnReadByte(93);

            SkillFourth = data.OnReadByte(94);

            SkillFourthValue = data.OnReadByte(95);

            UnknownCharacterCreationThird = data.OnReadByteArray(96, 25);

            UnknownCharacterCreationFourth = data.OnReadByte(121);

            HairColor = data.OnReadShort(122);

            HairStyle = data.OnReadShort(124);

            UnknownCharacterCreationFifth = data.OnReadByte(126);

            UnknownCharacterCreationSixth = data.OnReadInt(127);

            UnknownCharacterCreationSeventh = data.OnReadByte(131);

            ShirtColor = data.OnReadShort(132);

            ShirtStyle = data.OnReadShort(134);

            UnknownCharacterCreationEighth = data.OnReadByte(136);

            FaceColor = data.OnReadShort(137);

            FaceStyle = data.OnReadShort(139);

            UnknownCharacterCreationNinth = data.OnReadByte(141);

            BeardStyle = data.OnReadShort(142);

            BeardColor = data.OnReadShort(144);

            return data.OnReadShort(1);
        }
    }
}
