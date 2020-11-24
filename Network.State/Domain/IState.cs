using System;
using System.Collections.Concurrent;

namespace Network.State.Domain
{
    public interface IState<TData> : ISocket
        where TData : IData
    {
        TData GetBuffer();

        bool Locked { get; set; }

        bool Receiving { get; set; }

        int Sending { get; set; }

        DateTime Last { set; }

        ConcurrentQueue<TData> BufferQueue { get; }
    }
}
