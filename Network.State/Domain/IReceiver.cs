using System;
using System.Collections.Concurrent;

namespace Network.State.Domain
{
    public interface IReceiver<TData> : IState<TData>
        where TData : IData, new()
    {
        ConcurrentQueue<TData> ReceiveQueue { get; }

        internal void OnBeginReceive()
        {
            var data = GetBuffer();

            try
            {
                OnBeginReceive(data.Value, data.Offset, data.Length, f => OnReceive(data, f));
            }
            catch (ObjectDisposedException) when (!Locked)
            {
                OnInfo("stopped");

                Receiving = false;
            }
            catch (Exception exception)
            {
                OnInfo("Cannot begin receive.", exception);

                Locked = false;

                Receiving = false;
            }
        }

        private void OnReceive(TData data, Func<int> receive)
        {
            try
            {
                data.Length = receive();

                OnProcess(data);

                Last = DateTime.Now;
            }
            catch (ObjectDisposedException) when (!Locked)
            {
                OnInfo($"stopped on {IpAddress}:{Port}");

                Receiving = false;

                return;
            }
            catch (Exception exception)
            {
                OnInfo("Cannot receive.", exception);

                Locked = false;

                Receiving = false;

                return;
            }

            if (Locked) OnContinueReceive();
        }

        private void OnProcess(TData data)
        {
            if (data.Length > 0)
            {
                ReceiveQueue.Enqueue(data);
            }
            else
            {
                OnInfo($"stopped on {IpAddress}:{Port}");

                Locked = false;

                Receiving = false;
            }
        }

        private void OnContinueReceive()
        {
            try
            {
                OnBeginReceive();
            }
            catch (Exception exception)
            {
                OnInfo("Cannot continue receive.", exception);

                Locked = false;

                Receiving = false;
            }
        }

        private void OnInfo(string text, Exception exception = null)
        {
            Output($"Receiver: {text}{(exception != null ? $"\n{exception}" : null)}");
        }
    }
}
