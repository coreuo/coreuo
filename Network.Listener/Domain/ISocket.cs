using System;
using System.Net;
using System.Net.Sockets;

namespace Network.Listener.Domain
{
    public interface ISocket : ISettings
    {
        Socket Socket { get; set; }

        EndPoint EndPoint { get; set; }

        IPEndPoint IpEndPoint => (IPEndPoint) EndPoint;

        internal void Initialize()
        {
            Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            EndPoint = new IPEndPoint(IPAddress.Parse(IpAddress), Port);
        }

        internal void BeginListen(EndPoint endpoint)
        {
            Socket.Bind(endpoint);

            Socket.Listen(100);
        }

        internal void BeginAccept<TState>(Action<Func<TState>> onAccept)
            where TState : ISocket, new()
        {
            Socket.BeginAccept(r => onAccept(() => CreateState(r)), Socket);

            TState CreateState(IAsyncResult result)
            {
                var state = new TState {Socket = Socket.EndAccept(result)};

                state.EndPoint = state.Socket.RemoteEndPoint;

                return state;
            }
        }

        internal void BeginClose()
        {
            Socket.Close();
        }
    }
}
