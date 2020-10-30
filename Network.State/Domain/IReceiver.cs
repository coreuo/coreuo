using System;
using System.Collections.Concurrent;

namespace Network.State.Domain
{
    public interface IReceiver<TData> : IState<TData>
        where TData : IData, new()
    {
        ConcurrentQueue<TData> ReceiveQueue { get; }

        internal void BeginReceive()
        {
            var data = GetBuffer();

            try
            {
                BeginReceive(data.Value, data.Offset, data.Length, f => Receive(data, f));
            }
            catch (ObjectDisposedException) when (!Locked)
            {
                Info("stopped");

                Receiving = false;
            }
            catch (Exception exception)
            {
                Info("Cannot begin receive.", exception);

                Locked = false;

                Receiving = false;
            }
        }

        private void Receive(TData data, Func<int> receive)
        {
            try
            {
                data.Length = receive();

                Process(data);

                Last = DateTime.Now;
            }
            catch (ObjectDisposedException) when (!Locked)
            {
                Info($"stopped on {IpAddress}:{Port}");

                Receiving = false;

                return;
            }
            catch (Exception exception)
            {
                Info("Cannot receive.", exception);

                Locked = false;

                Receiving = false;

                return;
            }

            if (Locked) ContinueReceive();
        }

        private void Process(TData data)
        {
            if (data.Length > 0)
            {
                ReceiveQueue.Enqueue(data);
            }
            else
            {
                Info($"stopped on {IpAddress}:{Port}");

                Locked = false;

                Receiving = false;
            }
        }

        private void ContinueReceive()
        {
            try
            {
                BeginReceive();
            }
            catch (Exception exception)
            {
                Info("Cannot continue receive.", exception);

                Locked = false;

                Receiving = false;
            }
        }

        private void Info(string text, Exception exception = null)
        {
            Output($"Receiver: {text}{(exception != null ? $"\n{exception}" : null)}");
        }
    }
}
