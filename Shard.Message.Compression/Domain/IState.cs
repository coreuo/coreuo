using System;
using System.Collections.Concurrent;

namespace Shard.Message.Compression.Domain
{
    public interface IState<TData>
        where TData : IData
    {
        Func<TData> GetBuffer { get; }

        ConcurrentQueue<TData> BufferQueue { get; }
    }
}
