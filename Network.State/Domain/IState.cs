using System;
using System.Collections.Concurrent;

namespace Network.State.Domain
{
    public interface IState<TData> : ISocket
        where TData : IData
    {
        Func<TData> GetBuffer { get; }

        bool Locked { get; set; }

        bool Receiving { get; set; }

        int Sending { get; set; }

        DateTime Last { get; set; }

        ConcurrentQueue<TData> BufferQueue { get; }
    }
}
