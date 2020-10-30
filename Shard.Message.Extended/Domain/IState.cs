using System;
using Shard.Message.Extended.Domain.Incoming;

namespace Shard.Message.Extended.Domain
{
    public interface IState<out TData> : IClientLanguage
        where TData : IData
    {
        Action<int, Action<TData>, string> ExtendedData { get; }

        internal void Write(short id, int size, Action<IData> writer)
        {
            ExtendedData(size + 3, data =>
            {
                data.ExtendedOffset = 3;

                data.ExtendedLength = size;

                data.Write(0, id);

                writer?.Invoke(data);

            }, writer.Method.Name);
        }
    }
}
