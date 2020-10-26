using System;
using Login.Message.Domain.Outgoing;

namespace Login.Message.Domain
{
    public interface IServer<in TState, in TData, TShard> :
        IShardList<TShard>
        where TState : IState<TData>
        where TData : IData, new()
        where TShard : IShard, IShardServer
    {
        Action<TState, TData> Decrypt { get; }

        Action<TState> ClientConnect { get; }

        Action<TState> AccountLogin { get; }

        Action<TState> HardwareInfo { get; }

        Action<TState> ShardSelect { get; }

        Action<string> Output { get; }

        internal int OnRead(TState state, TData data)
        {
            Decrypt(state, data);

            var id = data.OnReadByte(0);

            return id switch
            {
                0xEF => Process(state.OnReadClientConnect, ClientConnect),
                0x80 => Process(state.OnReadAccountLogin, AccountLogin),
                0xD9 => Process(state.OnReadHardwareInfo, HardwareInfo),
                0xA0 => Process(state.OnReadShardSelect, ShardSelect),
                _ => throw new InvalidOperationException($"Invalid message 0x{id:X2}.")
            };

            int Process(Func<IData, int> reader, Action<TState> @event)
            {
                OnInfo($"0x{id:X2} {reader.Method.Name}");

                var size = reader(data);

                @event(state);

                return size;
            }
        }

        private void OnInfo(string text)
        {
            Output($"Message: {text}");
        }
    }
}
