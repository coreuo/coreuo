using System;

namespace Shard.Message.Extended.Domain
{
    public interface IServer<in TState, in TData>
        where TState : IState<TData>
        where TData : IData
    {
        Action<TState> ClientLanguage { get; }

        Action<TState> StatusClose { get; }

        public string Identity { get; }

        internal int Read(TState state, TData data)
        {
            var id = data.ReadExtendedShort(0);

            return id switch
            {
                0x000B => Process(state.ReadClientLanguage, ClientLanguage),
                0x000C => Process(state.ReadStatusClose, StatusClose),
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
