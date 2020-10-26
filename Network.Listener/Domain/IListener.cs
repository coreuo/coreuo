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

        internal void OnBeginListen()
        {
            try
            {
                OnBeginListen(EndPoint);

                OnInfo($"listening on {IpAddress}:{Port}");
            }
            catch (Exception exception)
            {
                OnInfo("Cannot begin listen.", exception);

                Locked = false;

                Listening = false;
            }
        }

        internal void OnBeginAccept()
        {
            try
            {
                OnBeginAccept<TSocket>(OnAccept);
            }
            catch (Exception exception)
            {
                OnInfo("Cannot begin accept.", exception);

                Locked = false;

                Listening = false;
            }
        }

        private void OnAccept(Func<TSocket> socketFactory)
        {
            try
            {
                var socket = socketFactory();

                OnProcess(socket);

                OnInfo($"accepted on {socket.IpAddress}:{socket.Port}");
            }
            catch (ObjectDisposedException) when (!Locked)
            {
                OnInfo("closed");

                Listening = false;

                return;
            }
            catch (Exception exception)
            {
                OnInfo("Cannot accept.", exception);

                Locked = false;

                Listening = false;

                return;
            }

            OnContinueAccept();
        }

        private void OnProcess(TSocket state)
        {
            state.Identity = Identity;

            state.IpAddress = state.IpEndPoint.Address.ToString();

            state.Port = state.IpEndPoint.Port;

            ListenQueue.Enqueue(state);
        }

        private void OnContinueAccept()
        {
            try
            {
                OnBeginAccept<TSocket>(OnAccept);
            }
            catch(Exception exception)
            {
                OnInfo("Cannot continue accept.", exception);

                Locked = false;

                Listening = false;
            }
        }

        private void OnInfo(string text, Exception exception = null)
        {
            Output($"Listener: {text}{(exception != null ? $"\n{exception}" : null)}");
        }
    }
}
