using Shard.Message.Domain.Shared;

namespace Shard.Message.Domain.Incoming
{
    public interface ICharacterLogin :
        IPattern,
        IName,
        IClientFlags,
        ISlot
    {
        short FirstLoginCharacterUnknown { get; set; }

        int SecondLoginCharacterUnknown { get; set; }

        int LoginCount { get; set; }

        byte[] ThirdLoginCharacterUnknown { get; set; }

        int ClientIpAddress { get; set; }

        internal int OnReadLoginCharacter(IData data)
        {
            Pattern = data.OnReadInt(1);

            Name = data.OnReadString(5, 30);

            FirstLoginCharacterUnknown = data.OnReadShort(35);

            ClientFlags = data.OnReadInt(37);

            SecondLoginCharacterUnknown = data.OnReadInt(41);

            LoginCount = data.OnReadInt(45);

            ThirdLoginCharacterUnknown = data.OnReadByteArray(49, 16);

            Slot = data.OnReadInt(65);

            ClientIpAddress = data.OnReadInt(69);

            return 73;
        }
    }
}
