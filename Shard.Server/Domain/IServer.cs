using System;

namespace Shard.Server.Domain
{
    public interface IServer<TState, TMobile>
        where TState : IState<TMobile>
        where TMobile : IMobile
    {
        Action<TState> EncryptionRequest { get; }

        Action<TState> SupportedFeatures { get; }

        Action<TState> CharacterList { get; }

        Action<TState> LoginConfirm { get; }

        Action<TState> MapChange { get; }

        Action<TState> MapPatches { get; }

        Action<TState> SeasonChange { get; }

        Action<TState, TMobile> MobileUpdate { get; }

        Action<TState> GlobalLight { get; }

        Action<TState, TMobile> MobileLight { get; }

        Action<TState, TMobile> MobileIncoming { get; }

        Action<TState, TMobile> MobileStatus { get; }

        Action<TState> WarMode { get; }

        Action<TState> LoginComplete { get; }

        Action<TState> ServerTime { get; }

        Action<TState, TMobile> SkillInfo { get; }

        Action<TState> PingResponse { get; }

        Action<TState> MoveResponse { get; }
    }
}
