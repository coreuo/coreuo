using Network.Listener.Domain;

namespace Network.Listener
{
    public static class Handlers<TSocket>
        where TSocket : ISocket, new()
    {
        public static void OnStart(IListener<TSocket> listener)
        {
            listener.Listening = true;

            listener.Initialize();

            listener.BeginListen();

            if(listener.Listening) listener.BeginAccept();
        }

        public static void OnStop(IListener<TSocket> listener)
        {
            if (!listener.Listening)
                return;

            listener.BeginClose();
        }
    }
}
