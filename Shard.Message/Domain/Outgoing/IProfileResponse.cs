using Shard.Message.Domain.Shared;

namespace Shard.Message.Domain.Outgoing
{
    public interface IProfileResponse :
        ISerial
    {
        string ProfileHeader { get; }

        string ProfileBody { get; }
         
        string ProfileFooter { get; }

        void OnWriteProfileResponse(IData data)
        {
            data.OnWrite(3, Serial);

            var headerLength = data.OnWriteAsciiTerminated(7, ProfileHeader);

            var footerLength = data.OnWriteBigUnicodeTerminated(7 + headerLength, ProfileFooter);

            var bodyLength = data.OnWriteBigUnicodeTerminated(7 + headerLength + footerLength, ProfileBody);

            data.OnWrite(1, (short)(7 + headerLength + footerLength + bodyLength));
        }
    }
}
