using System;
using Shard.Server.Domain;

namespace Shard.Server
{
    public static class Handlers<TServer, TState, TMobile>
        where TServer : IServer<TState, TMobile>
        where TState : IState<TMobile>
        where TMobile : IMobile
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
            state.Mobile = mobile;

            server.LoginConfirm(state);

            server.MapChange(state);

            server.MapPatches(state);

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
                0x05 => server.SkillInfo,
                _ => throw new InvalidOperationException($"Unknown mobile query type {state.MobileQueryType:X}.")
            };

            action(state, state.Mobile);
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
            server.MoveResponse(state);
        }
    }
}
