using Shard.Message.Domain.Shared;

namespace Shard.Message.Domain.Incoming
{
    public interface ICharacterCreation :
        IPattern,
        ISlot,
        IName,
        IPassword,
        IClientFlags,
        IRace,
        IHue,
        IMobileStats
    {
        public byte Profession { set; }

        public byte Gender { set; }

        public int UnknownCharacterCreationFirst { set; }

        public int UnknownCharacterCreationSecond { set; }

        public byte SkillFirst { set; }

        public byte SkillFirstValue { set; }

        public byte SkillSecond { set; }

        public byte SkillSecondValue { set; }

        public byte SkillThird { set; }

        public byte SkillThirdValue { set; }

        public byte SkillFourth { set; }

        public byte SkillFourthValue { set; }

        public byte[] UnknownCharacterCreationThird { set; }

        public byte UnknownCharacterCreationFourth { set; }

        public ushort HairHue { set; }

        public ushort HairGraphic { set; }

        public byte UnknownCharacterCreationFifth { set; }

        public int UnknownCharacterCreationSixth { set; }

        public byte UnknownCharacterCreationSeventh { set; }

        public short ShirtColor { set; }

        public short ShirtStyle { set; }

        public byte UnknownCharacterCreationEighth { set; }

        public ushort FaceHue { set; }

        public ushort FaceGraphic { set; }

        public byte UnknownCharacterCreationNinth { set; }

        public ushort BeardGraphic { set; }

        public ushort BeardHue { set; }

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

            Hue = data.ReadUShort(78);

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

            HairHue = data.ReadUShort(122);

            HairGraphic = data.ReadUShort(124);

            UnknownCharacterCreationFifth = data.ReadByte(126);

            UnknownCharacterCreationSixth = data.ReadInt(127);

            UnknownCharacterCreationSeventh = data.ReadByte(131);

            ShirtColor = data.ReadShort(132);

            ShirtStyle = data.ReadShort(134);

            UnknownCharacterCreationEighth = data.ReadByte(136);

            FaceHue = data.ReadUShort(137);

            FaceGraphic = data.ReadUShort(139);

            UnknownCharacterCreationNinth = data.ReadByte(141);

            BeardHue = data.ReadUShort(142);

            BeardGraphic = data.ReadUShort(144);

            return data.ReadShort(1);
        }
    }
}
