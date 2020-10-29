using System;
using Shard.Server.Domain;

namespace Shard.Server
{
    public static class Handlers<TServer, TState, TEntity, TMobile>
        where TServer : IServer<TState, TEntity, TMobile>
        where TState : IState<TMobile>
        where TEntity : IEntity
        where TMobile : TEntity, IMobile
    {
        public static void OnClientSeed(TServer server, TState state)
        {
            server.EncryptionRequest(state);
        }

        public static void OnAccountLogin(TServer server, TState state)
        {
            server.SupportedFeatures(state);

            server.CharacterList(state);
        }

        public static void OnCharacterCreate(TServer server, TState state, TMobile mobile)
        {
            server.Entities[mobile.Serial] = mobile;

            state.Mobile = mobile;

            server.LoginConfirm(state, mobile);

            server.MapChange(state, mobile);

            server.MapPatches(state, mobile);

            server.SeasonChange(state);

            server.SupportedFeatures(state);

            server.MobileUpdate(state, mobile);

            server.GlobalLight(state);

            server.MobileLight(state, mobile);

            server.MobileIncoming(state, mobile);

            server.MobileStatus(state, mobile);

            server.WarMode(state);

            server.LoginComplete(state);

            server.ServerTime(state);

            server.SeasonChange(state);
        }

        public static void OnMobileQuery(TServer server, TState state)
        {
            var action = state.MobileQueryType switch
            {
                0x04 => server.MobileStatus,
                0x05 => server.SkillInfo,
                _ => throw new InvalidOperationException($"Unknown mobile query type {state.MobileQueryType:X}.")
            };

            action(state, (TMobile)server.Entities[state.MobileQuerySerial]);
        }

        public static void OnClientLanguage(TServer server, TState state)
        {
        }

        public static void OnChatRequest(TServer server, TState state)
        {

        }

        public static void OnPingRequest(TServer server, TState state)
        {
            server.PingResponse(state);
        }

        public static void OnMoveRequest(TServer server, TState state)
        {
            server.MoveResponse(state, state.Mobile);
        }

        public static void OnCharacterLogin(TServer server, TState state, TMobile mobile)
        {
            server.Entities[mobile.Serial] = mobile;

            state.Mobile = mobile;

            server.ClientVersionRequest(state);

            server.LoginConfirm(state, mobile);

            server.MapChange(state, mobile);

            server.MapPatches(state, mobile);

            server.SeasonChange(state);

            server.SupportedFeatures(state);

            server.MobileUpdate(state, mobile);

            server.MobileUpdate(state, mobile);

            server.GlobalLight(state);

            server.MobileLight(state, mobile);

            server.MobileUpdate(state, mobile);

            server.MobileIncoming(state, mobile);

            server.MobileStatus(state, mobile);

            server.WarMode(state);

            server.MobileIncoming(state, mobile);

            server.AttributeInfo(state, mobile);

            server.SupportedFeatures(state);

            server.MobileUpdate(state, mobile);

            server.MobileStatus(state, mobile);

            server.WarMode(state);

            server.MobileIncoming(state, mobile);

            server.LoginComplete(state);

            server.ServerTime(state);

            server.SeasonChange(state);

            server.MapChange(state, mobile);
        }

        public static void OnAttributesQuery(TServer server, TState state)
        {
            state.AttributesQuerySerialList.ForEach(s => server.AttributeList(state, server.Entities[s]));
        }

        public static void OnDoubleClick(TServer server, TState state)
        {
            if ((state.DoubleClickSerial & ~0x7FFFFFFF) != 0)
            {
                server.OpenPaperDoll(state, state.Mobile);

                return;
            }

            var entity = server.Entities[state.DoubleClickSerial];

            Action action = entity switch
            {
                TMobile mobile => () => server.OpenPaperDoll(state, mobile),
                _ => throw new InvalidOperationException($"Unknown entity type {entity.GetType().Name}.")
            };

            action();
        }

        public static void OnRequestProfile(TServer server, TState state)
        {
            var entity = server.Entities[state.RequestProfileSerial];

            Action action = entity switch
            {
                TMobile mobile when state.RequestProfileMode == 0 => () => server.ProfileResponse(state, mobile),
                TMobile _ when state.RequestProfileMode == 1 => () => { },
                _ => throw new InvalidOperationException($"Unknown profile request of type {state.RequestProfileMode} for entity {entity.GetType().Name}.")
            };

            action();
        }
    }
}
