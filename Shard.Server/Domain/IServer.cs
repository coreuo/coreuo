using System;
using System.Collections.Generic;

namespace Shard.Server.Domain
{
    public interface IServer<in TState, TEntity, in TMobile>
        where TState : IState<TMobile>
        where TEntity : IEntity
        where TMobile : IMobile
    {
        Dictionary<int, TEntity> Entities { get; }

        Action<TState> EncryptionRequest { get; }

        Action<TState> SupportedFeatures { get; }

        Action<TState> CharacterList { get; }

        Action<TState, TMobile> LoginConfirm { get; }

        Action<TState, TMobile> MapChange { get; }

        Action<TState, TMobile> MapPatches { get; }

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

        Action<TState, TMobile> MoveResponse { get; }

        Action<TState> ClientVersionRequest { get; }

        Action<TState, TMobile> ServerChange { get; }

        Action<TState, TEntity> AttributeInfo { get; }

        Action<TState, TEntity> AttributeList { get; }

        Action<TState, TMobile> MobileAttributes { get; }

        Action<TState, TMobile> OpenPaperDoll { get; }

        Action<TState, TMobile> ProfileResponse { get; }
    }
}
