using System;
using System.Collections.Generic;

namespace Shard.Server.Domain
{
    public interface IServer<in TServer, in TState, in TMobile, in TItem, TEntity, in TTarget>
        where TServer : IServer<TServer, TState, TMobile, TItem, TEntity, TTarget>
        where TState : IState<TMobile, TItem, TEntity>
        where TEntity : IEntity<TItem, TEntity>
        where TMobile : IMobile<TItem, TEntity>
        where TItem : IItem<TItem, TEntity>
        where TTarget : ITarget
    {
        HashSet<TEntity> Entities { get; }

        Queue<int> MobileSerialPool { get; }

        int MaximumMobileSerial { get; set; }

        Queue<int> ItemSerialPool { get; }

        int MaximumItemSerial { get; set; }

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

        Action<TState, TEntity> EntityInfo { get; }

        Action<TState, TEntity> EntityAttributes { get; }

        //Action<TState, TMobile> MobileAttributes { get; }

        Action<TState, TMobile> PaperDollOpen { get; }

        Action<TState, TMobile> ProfileResponse { get; }

        //HashSet<Action<TServer, TItem>> Containers { get; }

        internal bool IsContainer(TItem item) => item.ItemId == 3701;

        Action<TState, TEntity> EntityDisplay { get; }

        Action<TState, TEntity> EntityContent { get; }

        Action<TServer, TMobile> Human { get; }

        //Action<TServer, TItem>[] GetItemTypes(TItem item);

        Action<TState, TEntity> EntityRemove { get; }

        Action<TState, TTarget> SoundPlay { get; }

        Action<TEntity, TItem> RemoveItem { get; }

        Action<TState> ItemPlaceApproved { get; }

        Action<TState, TItem> EntityContentItem { get; }

        void AddItem(TEntity parent, params TItem[] items);

        Action<TState, TItem> ItemWorld { get; }

        Action<TState, TItem> ItemWearUpdate { get; }
    }
}
