using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Network.Server.Domain
{
    public interface IServer<TState, in TData>
        where TState : IState<TData>
        where TData : IData
    {
        ConcurrentQueue<TState> ListenQueue { get; }

        List<TState> States { get; }

        bool Locked { get; set; }

        bool Listening { get; set; }

        bool Running { get; set; }

        Action<TState> StateStart { get; }

        Action<TState> StateStop { get; }

        Action<TState, TData> DataReceived { get; }

        Action<string> Output { get; }

        internal void OnProcessListenQueue()
        {
            while (ListenQueue.TryDequeue(out var state))
            {
                States.Add(state);

                StateStart(state);
            }
        }

        internal void OnRemoveInvalidStates()
        {
            States.RemoveAll(s => s.Sending < 0 || !s.Receiving);
        }

        internal void OnProcessStates()
        {
            States.ForEach(OnProcessState);
        }

        private void OnProcessState(TState state)
        {
            while (state.ReceiveQueue.TryDequeue(out var data))
            {
                try
                {
                    DataReceived(state, data);
                }
                catch (Exception exception)
                {
                    OnInfo("Cannot process data.", exception);

                    Locked = false;
                }

                state.BufferQueue.Enqueue(data);
            }
        }

        private void OnInfo(string text, Exception exception = null)
        {
            Output($"Server: {text}{(exception != null ? $"\n{exception}" : null)}");
        }
    }
}
