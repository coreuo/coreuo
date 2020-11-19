using System;
using System.Net.Sockets;

namespace Network.State.Domain
{
    public interface ISocket : ISettings
    {
        Socket Socket { get; }

        internal void BeginReceive(byte[] buffer, int offset, int length, Action<Func<int>> onReceive)
        {
            Socket.BeginReceive(buffer, offset, length, SocketFlags.None, r => onReceive(() => Socket.EndReceive(r)), null);
        }

        internal void BeginSend(byte[] buffer, int offset, int length, Action<Func<int>> onSend)
        {
            Socket.BeginSend(buffer, offset, length, SocketFlags.None, r => onSend(() => Socket.EndSend(r)), null);
        }

        internal void BeginClose()
        {
            Socket.Close();
        }
    }
}
