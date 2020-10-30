using System;

namespace Shard.Message.Extended.Domain
{
    public interface IServer<in TState, in TData>
        where TState : IState<TData>
        where TData : IData
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
