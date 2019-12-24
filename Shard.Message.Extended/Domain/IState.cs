using System;
using Shard.Message.Extended.Domain.Incoming;
using Shard.Message.Extended.Domain.Outgoing;

namespace Shard.Message.Extended.Domain
{
    public interface IState<TData, TMobile, TMap, TMapPatch> : IClientLanguage
        where TData : IData
        where TMobile : IMobile<TMap, TMapPatch>
        where TMap : IMap<TMapPatch>
        where TMapPatch : IMapPatch
    {
        Action<int, Action<TData>, string> ExtendedData { get; }

        TMobile Mobile { get; }

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
