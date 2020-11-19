using System;
using System.Collections.Generic;

namespace Shard.Server.Domain
{
    public interface IServer<TServer, in TState, in TMobile, in TItem, TEntity, TIdentity, in TTarget>
        where TServer : IServer<TServer, TState, TMobile, TItem, TEntity, TIdentity, TTarget>
        where TState : IState<TMobile, TItem, TEntity, TIdentity, TTarget>
        where TMobile : TEntity, IMobile<TItem, TEntity, TIdentity>
        where TItem : TEntity, IItem<TItem, TEntity, TIdentity>
        where TEntity : class, TTarget, IEntity<TItem, TEntity, TIdentity>
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

        Action<TState, TMobile> WarModeResponse { get; }

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

        Action<TState, TEntity> EntityDisplay { get; }

        Action<TState, TEntity> EntityContent { get; }

        Action<TState, TEntity> EntityRemove { get; }

        Action<TState, TTarget> SoundPlay { get; }

        Action<TState> ItemPlaceApproved { get; }

        Action<TState, TItem> EntityContentItem { get; }

        void SetItemParent(TEntity entity, TItem item);

        Action<TItem> RemoveItemParent { get; }

        Action<TState, TItem> ItemWorld { get; }

        Action<TState, TItem> ItemWearUpdate { get; }

        Action<TState, TMobile> MobileMoving { get; }

        Action<TState, TMobile> SpeechResponse { get; }

        Action<TState> TargetRequest { get; }

        Action<TEntity, string> AssignName { get; }

        Action<TEntity, ushort?> AssignGraphic { get; }

        Action<TEntity, ushort?> AssignHue { get; }

        Action<TState, TMobile> AssignMobileItems { get; }

        Action<TState, HashSet<TIdentity>> AssignRace { get; }

        Action<TState, HashSet<TIdentity>> AssignGender { get; }

        Action<TMobile> UpdateRace { get; }

        Action<TMobile> UpdateGender { get; }

        Action<TItem> AssignLayer { get; }

        Action<TItem> AssignDisplayIndex { get; }

        Action<TItem> AssignDisplay { get; }

        Action<HashSet<TIdentity>> AssignIdentities { get; }

        TIdentity Humanoid { get; }

        TIdentity Mobile { get; }

        TIdentity Alive { get; }

        TIdentity Character { get; }

        TIdentity Hair { get; }

        TIdentity Face { get; }

        TIdentity Beard { get; }

        TIdentity Container { get; }

        TIdentity Item { get; }

        internal void MoveItem(TState state, TEntity parent, TItem item)
        {
            Action action = parent switch
            {
                null => () =>
                {
                    RemoveItemParent(item);

                    state.TransferLocation(item);

                    ItemWorld(state, item);

                    EntityInfo(state, item);

                    state.SoundId = 0x42;

                    SoundPlay(state, state.Mobile);

                    ItemPlaceApproved(state);

                    MobileStatus(state, state.Mobile);
                },
                TItem => () =>
                {
                    state.SoundId = 0x48;

                    SoundPlay(state, state.Mobile);

                    ItemPlaceApproved(state);

                    MobileStatus(state, state.Mobile);

                    item.GridIndex = state.GridIndex;

                    SetItemParent(parent, item);

                    EntityContentItem(state, item);

                    EntityInfo(state, item);

                    EntityInfo(state, parent);
                },
                TMobile => () =>
                {
                    ItemPlaceApproved(state);

                    SetItemParent(parent, item);

                    MobileStatus(state, state.Mobile);

                    ItemWearUpdate(state, item);

                    EntityInfo(state, item);
                },
                _ => throw new InvalidOperationException($"Unknown parent of type {parent.GetType().Name}.")
            };

            action();
        }
    }
}
