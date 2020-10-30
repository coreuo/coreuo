using System;

namespace Shard.Message.Domain.Outgoing
{
    public interface ICurrentServerTime
    {
        DateTime DateTime { get; }

        internal void WriteCurrentServerTime(IData data)
        {
            data.Write(1, (byte)DateTime.Hour);

            data.Write(2, (byte)DateTime.Minute);

            data.Write(3, (byte)DateTime.Second);
        }
    }
}