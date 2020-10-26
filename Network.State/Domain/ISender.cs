using System;

namespace Network.State.Domain
{
    public interface ISender<TData> : IState<TData>
        where TData : IData
    {
        internal void OnBeginSend(TData data)
        {
            try
            {
                OnBeginSend(data.Value, data.Offset, data.Length, f => OnSend(data, f));
            }
            catch (Exception exception)
            {
                OnInfo("Cannot begin send.", exception);

                Locked = false;

                Sending = -1;
            }
        }

        private void OnSend(TData data, Func<int> send)
        {
            try
            {
                data.Length = send();

                OnProcess(data);

                Last = DateTime.Now;
            }
            catch (ObjectDisposedException) when (!Locked)
            {
                OnInfo("stopped");

                Sending = -1;
            }
            catch(Exception exception)
            {
                OnInfo("Cannot send.", exception);

                Locked = false;

                Sending = -1;
            }
        }

        private void OnProcess(TData data)
        {
            if (data.Length > 0)
            {
                BufferQueue.Enqueue(data);

                return;
            }

            OnInfo("Cannot process send.");

            Locked = false;
        }

        private void OnInfo(string text, Exception exception = null)
        {
            Output($"Sender: {text}{(exception != null ? $"\n{exception}" : null)}");
        }
    }
}
