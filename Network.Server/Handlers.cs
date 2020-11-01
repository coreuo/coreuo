using System.Linq;
using Network.Server.Domain;

namespace Network.Server
{
    public static class Handlers<TState, TData>
        where TState : IState<TData>
        where TData : IData
    {
        public static void Slice(IServer<TState, TData> server)
        {
            server.ProcessListenQueue();

            server.RemoveInvalidStates();

            server.ProcessStates();

            if (!server.Locked && !server.Listening && !server.States.Any())
                server.Running = false;
        }

        public static void Stop(IServer<TState, TData> server)
        {
            server.States.ForEach(server.StateStop);
        }
    }
}
