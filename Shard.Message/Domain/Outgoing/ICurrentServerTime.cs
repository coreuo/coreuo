using System;

namespace Shard.Message.Domain.Outgoing
{
    public interface ICurrentServerTime
    {
        DateTime DateTime { get; }

        internal void OnWriteCurrentServerTime(IData data)
        {
            data.OnWrite(1, (byte)DateTime.Hour);

            data.OnWrite(2, (byte)DateTime.Minute);

            data.OnWrite(3, (byte)DateTime.Second);
        }
    }
}