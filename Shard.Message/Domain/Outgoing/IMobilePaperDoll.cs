using Shard.Message.Domain.Shared;
using System;

namespace Shard.Message.Domain.Outgoing
{
    public interface IMobilePaperDoll :
        ISerialGet,
        IName
    {
        internal void WriteMobilePaperDoll(IData data)
        {
            if (Name == null) throw new InvalidOperationException($"Unknown mobile ({this}) name.");

            data.Write(1, Serial);

            data.WriteAscii(5, Name, 60);
        }
    }
}
