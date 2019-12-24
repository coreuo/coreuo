using System;
using System.Collections.Generic;

namespace Login.Server.Domain
{
    public interface IServer<TState, TShard>
        where TState : IState
        where TShard : IShard
    {
        Action<TState> ShardList { get; }

        Action<TState> ShardServer { get; }

        List<TShard> Shards { get; }

        Random Random { get; set; }
    }
}
