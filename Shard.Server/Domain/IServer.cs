using System;
using System.Collections.Generic;
using System.Linq;

namespace Shard.Server.Domain
{
    public interface IServer<TServer, in TState, TEntity, in TMobile, TItem>
        where TServer : IServer<TServer, TState, TEntity, TMobile, TItem>
        where TState : IState<TMobile>
        where TEntity : IEntity
        where TMobile : IMobile
        where TItem : IItem<TItem>
    {
        Dictionary<int, TEntity> Entities { get; }

        Stack<int> MobileSerialPool { get; }

        Stack<int> ItemSerialPool { get; }

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

        //Action<TState, TMobile> ServerChange { get; }

        Action<TState, TEntity> AttributeInfo { get; }

        Action<TState, TEntity> AttributeList { get; }

        //Action<TState, TMobile> MobileAttributes { get; }

        Action<TState, TMobile> OpenPaperDoll { get; }

        Action<TState, TMobile> ProfileResponse { get; }

        HashSet<Action<TServer, TItem>> Containers { get; }

        internal bool IsContainer(TItem item) => GetItemTypes(item).Any(t => Containers.Contains(t));

        Action<TState, TEntity> EntityDisplay { get; }

        Action<TState, TEntity> EntityContent { get; }

        Action<TServer, TMobile> Human { get; }

        Action<TServer, TItem>[] GetItemTypes(TItem item);
    }
}
