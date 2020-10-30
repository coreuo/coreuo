using Shard.Message.Domain.Shared;

namespace Shard.Message.Domain.Incoming
{
    public interface ICharacterLogin :
        IPattern,
        IName,
        IClientFlags,
        ISlot
    {
        public short FirstLoginCharacterUnknown { get; set; }

        public int SecondLoginCharacterUnknown { get; set; }

        public int LoginCount { get; set; }

        public byte[] ThirdLoginCharacterUnknown { get; set; }

        public int ClientIpAddress { get; set; }

        internal int ReadLoginCharacter(IData data)
        {
            Pattern = data.ReadInt(1);

            Name = data.ReadAscii(5, 30);

            FirstLoginCharacterUnknown = data.ReadShort(35);

            ClientFlags = data.ReadInt(37);

            SecondLoginCharacterUnknown = data.ReadInt(41);

            LoginCount = data.ReadInt(45);

            ThirdLoginCharacterUnknown = data.ReadByteArray(49, 16);

            Slot = data.ReadInt(65);

            ClientIpAddress = data.ReadInt(69);

            return 73;
        }
    }
}
