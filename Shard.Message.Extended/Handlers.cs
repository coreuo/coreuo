using Shard.Message.Extended.Domain;
using Shard.Message.Extended.Domain.Outgoing;

namespace Shard.Message.Extended
{
    public static class Handlers<TServer, TState, TData, TMobile, TMap, TMapPatch>
        where TServer : IServer<TState, TData>
        where TState : IState<TData>
        where TData : IData
        where TMobile : IMobile<TMap, TMapPatch>
        where TMap : IMap<TMapPatch>
        where TMapPatch : IMapPatch
    {
        public static void Received(TServer server, TState state, TData data)
        {
            while (data.ExtendedOffset < data.ExtendedLength)
            {
                var size = server.Read(state, data);

                data.ExtendedOffset += size;
            }
        }

        public static void MapChange(TState state, TMobile mobile)
        {
            state.Write(0x0008, 3, mobile.Map.WriteMapChange);
        }

        public static void MapPatch(TState state, TMobile mobile)
        {
            state.Write(0x0018, 6 + mobile.Map.Patches.Count * 8, mobile.Map.WriteMapPatchList);
        }
    }
}
