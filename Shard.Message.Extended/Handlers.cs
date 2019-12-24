using Shard.Message.Extended.Domain;
using Shard.Message.Extended.Domain.Outgoing;

namespace Shard.Message.Extended
{
    public static class Handlers<TServer, TState, TData, TMobile, TMap, TMapPatch>
        where TServer : IServer<TState, TData, TMobile, TMap, TMapPatch>
        where TState : IState<TData, TMobile, TMap, TMapPatch>
        where TData : IData
        where TMobile : IMobile<TMap, TMapPatch>
        where TMap : IMap<TMapPatch>
        where TMapPatch : IMapPatch
    {
        public static void OnReceived(TServer server, TState state, TData data)
        {
            while (data.ExtendedOffset < data.ExtendedLength)
            {
                var size = server.Read(state, data);

                data.ExtendedOffset += size;
            }
        }

        public static void OnMapChange(TState state)
        {
            state.Write(0x0008, 3, state.Mobile.Map.WriteMapChange);
        }

        public static void OnMapPatch(TState state)
        {
            state.Write(0x0018, 6 + state.Mobile.Map.Patches.Count * 8, state.Mobile.Map.WriteMapPatchList);
        }
    }
}
