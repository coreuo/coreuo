using System;
using System.Collections.Generic;

namespace Login.Server.Domain
{
    public interface IServer<in TState, TShard>
        where TState : IState
        where TShard : IShard
    {
        void ShardList(TState state);

        void ShardServer(TState state);

        List<TShard> Shards { get; }

        Random Random { get; }
    }
}
