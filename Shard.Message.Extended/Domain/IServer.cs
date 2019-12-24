using System;
using Shard.Message.Extended.Domain.Outgoing;

namespace Shard.Message.Extended.Domain
{
    public interface IServer<TState, TData, TMobile, TMap, TMapPatch>
        where TState : IState<TData, TMobile, TMap, TMapPatch>
        where TData : IData
        where TMobile : IMobile<TMap, TMapPatch>
        where TMap : IMap<TMapPatch>
        where TMapPatch : IMapPatch
    {
        Action<TState> ClientLanguage { get; }

        public string Identity { get; set; }

        internal int Read(TState state, TData data)
        {
            var id = data.ReadShort(0);

            return id switch
            {
                0x000B => Process(state.ReadClientLanguage, ClientLanguage),
                _ => throw new InvalidOperationException($"{Identity}.Message.Extended: Invalid message 0x{id:X}.")
            };

            int Process(Func<IData, int> message, Action<TState> @event)
            {
                var size = message(data);

                @event(state);

                return size;
            }
        }
    }
}
