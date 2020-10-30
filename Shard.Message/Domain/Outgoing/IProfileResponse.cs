using Shard.Message.Domain.Shared;

namespace Shard.Message.Domain.Outgoing
{
    public interface IProfileResponse :
        ISerial
    {
        public string ProfileHeader { get; }

        public string ProfileBody { get; }

        public string ProfileFooter { get; }

        void WriteProfileResponse(IData data)
        {
            data.Write(3, Serial);

            var headerLength = data.WriteAsciiTerminated(7, ProfileHeader);

            var footerLength = data.WriteBigUnicodeTerminated(7 + headerLength, ProfileFooter);

            var bodyLength = data.WriteBigUnicodeTerminated(7 + headerLength + footerLength, ProfileBody);

            data.Write(1, (short)(7 + headerLength + footerLength + bodyLength));
        }
    }
}
