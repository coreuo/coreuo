using System.Collections.Concurrent;

namespace Shard.Message.Compression.Domain
{
    public interface IState<TData>
        where TData : IData
    {
        TData GetBuffer();

        ConcurrentQueue<TData> BufferQueue { get; }
    }
}
