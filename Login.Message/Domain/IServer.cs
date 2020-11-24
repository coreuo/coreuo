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
        void Decrypt(TState state, TData data);

        void ClientConnect(TState state);

        void AccountLogin(TState state);

        void HardwareInfo(TState state);

        void ShardSelect(TState state);

        void Output(string text);

        internal int Read(TState state, TData data)
        {
            Decrypt(state, data);

            var id = data.ReadByte(0);

            return id switch
            {
                0xEF => Process(state.ReadClientConnect, ClientConnect),
                0x80 => Process(state.ReadAccountLogin, AccountLogin),
                0xD9 => Process(state.ReadHardwareInfo, HardwareInfo),
                0xA0 => Process(state.ReadShardSelect, ShardSelect),
                _ => throw new InvalidOperationException($"Invalid message 0x{id:X2}.")
            };

            int Process(Func<IData, int> reader, Action<TState> @event)
            {
                Info($"0x{id:X2} {reader.Method.Name}");

                var size = reader(data);

                @event(state);

                return size;
            }
        }

        private void Info(string text)
        {
            Output($"Message: {text}");
        }
    }
}
