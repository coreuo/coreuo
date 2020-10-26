using Network.Listener.Domain;

namespace Network.Listener
{
    public static class Handlers<TSocket>
        where TSocket : ISocket, new()
    {
        public static void OnStart(IListener<TSocket> listener)
        {
            listener.Listening = true;

            listener.OnInitialize();

            listener.OnBeginListen();

            if(listener.Listening) listener.OnBeginAccept();
        }

        public static void OnStop(IListener<TSocket> listener)
        {
            if (!listener.Listening)
                return;

            listener.OnBeginClose();
        }
    }
}
