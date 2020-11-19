using System.Collections.Concurrent;

namespace Network.Server.Domain
{
    public interface IState<TData>
        where TData : IData
    {
        ConcurrentQueue<TData> BufferQueue { get; }

        ConcurrentQueue<TData> ReceiveQueue { get; }

        bool Receiving { get; }

        int Sending { get; }
    }
}
