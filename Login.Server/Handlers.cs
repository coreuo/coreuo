using System;
using Login.Server.Domain;

namespace Login.Server
{
    public static class Handlers<TServer, TState, TShard>
        where TServer : IServer<TState, TShard>
        where TState : IState
        where TShard : IShard
    {
        public static void OnAccountLogin(TServer server, TState state)
        {
            server.ShardList(state);
        }

        public static void OnShardSelect(TServer server, TState state)
        {
            if(state.ShardIndex < 0 || !(state.ShardIndex < server.Shards.Count))
                throw new InvalidOperationException("Invalid shard index.");

            var shard = server.Shards[state.ShardIndex];

            shard.AuthorizationId = server.Random.Next() | (server.Random.Next() % 2 > 0 ? 1 << 31 : 0);

            server.ShardServer(state);
        }
    }
}
