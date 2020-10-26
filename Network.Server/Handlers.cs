﻿using System.Linq;
using Network.Server.Domain;

namespace Network.Server
{
    public static class Handlers<TState, TData>
        where TState : IState<TData>
        where TData : IData
    {
        public static void OnSlice(IServer<TState, TData> server)
        {
            server.OnProcessListenQueue();

            server.OnRemoveInvalidStates();

            server.OnProcessStates();

            if (!server.Locked && !server.Listening && !server.States.Any())
                server.Running = false;
        }

        public static void OnStop(IServer<TState, TData> server)
        {
            server.States.ForEach(s => server.StateStop(s));
        }
    }
}
