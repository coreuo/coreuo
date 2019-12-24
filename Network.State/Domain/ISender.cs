using System;

namespace Network.State.Domain
{
    public interface ISender<TData> : IState<TData>
        where TData : IData
    {
        internal void BeginSend(TData data)
        {
            try
            {
                BeginSend(data.Value, data.Offset, data.Length, f => OnSend(data, f));
            }
            catch (Exception exception)
            {
                Info("Cannot begin send.", exception);

                Locked = false;

                Sending = -1;
            }
        }

        private void OnSend(TData data, Func<int> send)
        {
            try
            {
                data.Length = send();

                Process(data);

                Last = DateTime.Now;
            }
            catch (ObjectDisposedException) when (!Locked)
            {
                Info("stopped");

                Sending = -1;
            }
            catch(Exception exception)
            {
                Info("Cannot send.", exception);

                Locked = false;

                Sending = -1;
            }
        }

        private void Process(TData data)
        {
            if (data.Length > 0)
            {
                BufferQueue.Enqueue(data);

                return;
            }

            Info("Cannot process send.");

            Locked = false;
        }

        private void Info(string text, Exception exception = null)
        {
            Output($"Sender: {text}{(exception != null ? $"\n{exception}" : null)}");
        }
    }
}
