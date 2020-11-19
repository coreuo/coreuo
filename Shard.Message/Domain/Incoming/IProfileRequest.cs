using Shard.Message.Domain.Shared;

namespace Shard.Message.Domain.Incoming
{
    public interface IProfileRequest :
        ISerialSet
    {
        byte ProfileRequestMode { get; set; }

        short ProfileRequestEditType { set; }

        string ProfileRequestEditText { set; }

        internal int ReadProfileRequest(IData data)
        {
            var length = data.ReadShort(1);

            ProfileRequestMode = data.ReadByte(3);

            Serial = data.ReadInt(4);

            if (ProfileRequestMode == 0) return length;

            ProfileRequestEditType = data.ReadShort(8);

            var textLength = data.ReadShort(10);

            ProfileRequestEditText = data.ReadUnicode(12, textLength);

            return length;
        }
    }
}
