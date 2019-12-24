using Login.Message.Domain;
using Login.Message.Domain.Outgoing;

namespace Login.Message
{
    public static class Handlers<TServer, TState, TData, TShard>
        where TServer : IServer<TState, TData, TShard>
        where TState : IState<TData>
        where TData : IData, new()
        where TShard : IShard, IShardServer
    {
        public static void OnReceived(TServer server, TState state, TData data)
        {
            while (data.Offset < data.Length)
            {
                var size = server.Read(state, data);

                data.Offset += size;
            }
        }

        public static void OnShardList(TServer server, TState state)
        {
            state.Write(0xA8, 6 + 40 * server.Shards.Count, server.WriteShardList);
        }

        public static void OnShardServer(TServer server, TState state)
        {
            state.Write(0x8C, 11, server.Shards[state.ShardIndex].WriteShardServer);
        }
    }
}
