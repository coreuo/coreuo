using System;
using System.Linq.Expressions;
using Shard.Message.Domain.Outgoing;

namespace Shard.Message.Domain
{
    public interface IServer<in TState, in TData, TMobile, TCity, TItem, TEntity, TAttribute, TSkillInfo> :
        ICityList<TCity>,
        ICharacterFeatures,
        ICurrentServerTime,
        IGlobalLight,
        ISupportedFeatures
        where TState : IState<TData, TMobile, TItem, TEntity, TAttribute, TSkillInfo>
        where TData : IData, new()
        where TMobile : IMobile<TItem, TSkillInfo>
        where TCity : ICityInfo
        where TItem : IItem<TAttribute, TItem, TEntity>
        where TEntity : IEntity<TAttribute, TItem, TEntity>
        where TAttribute : IAttribute
        where TSkillInfo : ISkill
    {
        public Action<TState> ClientSeed { get; }

        public Action<TState> EncryptionResponse { get; }

        public Action<TState> AccountLogin { get; }

        public Action<TState> CharacterCreate { get; }

        public Action<TState> MobileQuery { get; }

        public Action<TState, TData> ExtendedData { get; }

        public Action<TState> ChatRequest { get; }

        public Action<TState> PingRequest { get; }

        public Action<TState> MoveRequest { get; }

        public Action<TState> ClientType { get; }

        public Action<TState> CharacterLogin { get; }

        public Action<TState> EntityQuery { get; }

        public Action<TState> EntityUse { get; }

        public Action<TState> ProfileRequest { get; }

        public Action<TState> ItemPick { get; }

        public Action<TState> ItemPlace { get; }

        public Action<TState> ItemWear { get; }

        public Action<TState> WarModeRequest { get; }

        public Action<TState> SpeechRequest { get; }

        public Action<TState> TargetResponse { get; }

        Action<string> Output { get; }

        internal int Read(TState state, TData data)
        {
            var id = data.ReadByte(0);

            return id switch
            {
                0xFF => Process(state.ReadClientSeed, ClientSeed),
                0xE4 => Process(state.ReadEncryptionResponse, EncryptionResponse),
                0x91 => Process(state.ReadAccountLogin, AccountLogin),
                0x8D => Process(state.ReadCharacterCreation, CharacterCreate),
                0x34 => Process(state.ReadMobileQuery, MobileQuery),
                0xBF => ProcessWith(data, (e, d) => e.ReadExtendedData(d), ExtendedData),
                0xB5 => Process(state.ReadChatRequest, ChatRequest),
                0x73 => Process(state.ReadPingRequest, PingRequest),
                0x02 => Process(state.ReadMoveRequest, MoveRequest),
                0xE1 => Process(state.ReadClientType, ClientType),
                0x5D => Process(state.ReadLoginCharacter, CharacterLogin),
                0xD6 => Process(state.ReadEntityQuery, EntityQuery),
                0x06 => Process(state.ReadEntityUse, EntityUse),
                0xB8 => Process(state.ReadProfileRequest, ProfileRequest),
                0x07 => Process(state.ReadItemPick, ItemPick),
                0x08 => Process(state.ReadItemPlace, ItemPlace),
                0x13 => Process(state.ReadItemWear, ItemWear),
                0x72 => Process(state.ReadWarModeRequest, WarModeRequest),
                0xAD => Process(state.ReadSpeechRequest, SpeechRequest),
                0x6C => Process(state.ReadTargetResponse, TargetResponse),
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
