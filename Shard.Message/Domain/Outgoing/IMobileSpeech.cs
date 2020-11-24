using Shard.Message.Domain.Shared;
using System;

namespace Shard.Message.Domain.Outgoing
{
    public interface IMobileSpeech :
        ISerialGet,
        IName
    {
        internal void WriteMobileSpeech(IData data)
        {
            if (Name == null) throw new InvalidOperationException($"Unknown mobile ({this}) name.");

            data.Write(3, Serial);

            data.WriteAscii(18, Name, 30);
        }
    }
}
