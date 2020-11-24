using System;
using System.Collections.Concurrent;

namespace Network.Listener.Domain
{
    public interface IListener<TSocket> : ISocket
        where TSocket : ISocket, new()
    {
        ConcurrentQueue<TSocket> ListenQueue { get; }

        bool Locked { get; set; }

        bool Listening { get; set; }

        internal void BeginListen()
        {
            if(EndPoint == null) throw new InvalidOperationException("Unable to begin listen, please initialize first.");

            try
            {
                BeginListen(EndPoint);

                Info($"listening on {IpAddress}:{Port}");
            }
            catch (Exception exception)
            {
                Info("Cannot begin listen.", exception);

                Locked = false;

                Listening = false;
            }
        }

        internal void BeginAccept()
        {
            try
            {
                BeginAccept<TSocket>(Accept);
            }
            catch (Exception exception)
            {
                Info("Cannot begin accept.", exception);

                Locked = false;

                Listening = false;
            }
        }

        private void Accept(Func<TSocket> socketFactory)
        {
            try
            {
                var socket = socketFactory();

                Process(socket);

                Info($"accepted on {socket.IpAddress}:{socket.Port}");
            }
            catch (ObjectDisposedException) when (!Locked)
            {
                Info("closed");

                Listening = false;

                return;
            }
            catch (Exception exception)
            {
                Info("Cannot accept.", exception);

                Locked = false;

                Listening = false;

                return;
            }

            ContinueAccept();
        }

        private void Process(TSocket state)
        {
            state.Identity = Identity;

            state.IpAddress = state.IpEndPoint.Address.ToString();

            state.Port = state.IpEndPoint.Port;

            ListenQueue.Enqueue(state);
        }

        private void ContinueAccept()
        {
            try
            {
                BeginAccept<TSocket>(Accept);
            }
            catch(Exception exception)
            {
                Info("Cannot continue accept.", exception);

                Locked = false;

                Listening = false;
            }
        }

        private void Info(string text, Exception exception = null)
        {
            Output($"Listener: {text}{(exception != null ? $"\n{exception}" : null)}");
        }
    }
}
