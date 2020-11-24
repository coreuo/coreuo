using System;
using Shard.Message.Extended.Domain.Incoming;

namespace Shard.Message.Extended.Domain
{
    public interface IState<out TData> : 
        IClientLanguage,
        IStatusClose
        where TData : IData
    {
        void ExtendedData(int size, Action<TData> writer, string name);

        internal void Write(short id, int size, Action<IData> writer)
        {
            ExtendedData(size + 3, data =>
            {
                data.ExtendedOffset = 3;

                data.ExtendedLength = size;

                data.WriteExtended(0, id);

                writer?.Invoke(data);

            }, writer.Method.Name);
        }
    }
}
