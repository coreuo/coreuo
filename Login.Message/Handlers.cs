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
                var size = server.OnRead(state, data);

                data.Offset += size;
            }
        }

        public static void OnShardList(TServer server, TState state)
        {
            state.OnWrite(0xA8, 6 + 40 * server.Shards.Count, server.OnWriteShardList);
        }

        public static void OnShardServer(TServer server, TState state)
        {
            state.OnWrite(0x8C, 11, server.Shards[state.ShardIndex].OnWriteShardServer);
        }
    }
}
