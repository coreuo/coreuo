using System;
using System.Linq.Expressions;
using Shard.Message.Domain.Outgoing;

namespace Shard.Message.Domain
{
    public interface IServer<in TState, in TData, in TMobile, TCity, TMobileEquip, TSkillInfo, TMap> :
        ICityList<TCity>,
        ICharacterFeatures,
        ICurrentServerTime,
        IGlobalLight,
        ISupportedFeatures
        where TState : IState<TData, TMobile, TMobileEquip, TSkillInfo, TMap>
        where TData : IData, new()
        where TMobile : IMobile<TMobileEquip, TSkillInfo, TMap>, new()
        where TCity : ICityInfo
        where TMobileEquip : IMobileEquip
        where TSkillInfo : ISkill
        where TMap : IMap
    {
        public Action<TState> ClientSeed { get; }

        public Action<TState> EncryptionResponse { get; }

        public Action<TState> AccountLogin { get; }

        public Action<TState, TMobile> CharacterCreate { get; }

        public Action<TState> MobileQuery { get; }

        public Action<TState, TData> ExtendedData { get; }

        public Action<TState> ChatRequest { get; }

        public Action<TState> PingRequest { get; }

        public Action<TState> MoveRequest { get; }

        public Action<TState> ClientType { get; }

        public Action<TState, TMobile> CharacterLogin { get; }

        public Action<TState> AttributesQuery { get; }

        public Action<TState> DoubleClick { get; }

        public Action<TState> RequestProfile { get; }

        Action<string> Output { get; }

        internal int Read(TState state, TData data)
        {
            var id = data.ReadByte(0);

            return id switch
            {
                0xFF => Process(state.ReadClientSeed, ClientSeed),
                0xE4 => Process(state.ReadEncryptionResponse, EncryptionResponse),
                0x91 => Process(state.ReadAccountLogin, AccountLogin),
                0x8D => ProcessWith(new TMobile(), (m, d) => m.ReadCharacterCreation(d), CharacterCreate),
                0x34 => Process(state.ReadMobileQuery, MobileQuery),
                0xBF => ProcessWith(data, (e, d) => e.ReadExtendedData(d), ExtendedData),
                0xB5 => Process(state.ReadChatRequest, ChatRequest),
                0x73 => Process(state.ReadPingRequest, PingRequest),
                0x02 => Process(state.ReadMoveRequest, MoveRequest),
                0xE1 => Process(state.ReadClientType, ClientType),
                0x5D => ProcessWith(state.Characters[data.ReadInt(65)], (m, d) => m.ReadLoginCharacter(d), CharacterLogin),
                0xD6 => Process(state.ReadAttributesQuery, AttributesQuery),
                0x06 => Process(state.ReadDoubleClick, DoubleClick),
                0xB8 => Process(state.ReadRequestProfile, RequestProfile),
                _ => throw new InvalidOperationException($"Invalid message 0x{id:X2}.")
            };

            int ProcessWith<T>(T @object, Expression<Func<T, IData, int>> reader, Action<TState, T> @event)
            {
                var messageName = reader.Body is MethodCallExpression call ? call.Method.Name : null;

                return Process(d => reader.Compile()(@object, d), s => @event(s, @object), messageName);
            }

            int Process(Func<IData, int> reader, Action<TState> @event, string readerName = null)
            {
                Info($"0x{id:X2} {readerName ?? reader.Method.Name}");

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
