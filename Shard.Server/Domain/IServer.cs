using System;
using System.Collections.Generic;

namespace Shard.Server.Domain
{
    public interface IServer<TServer, in TState, in TMobile, in TItem, TEntity, TIdentity, in TTarget>
        where TServer : IServer<TServer, TState, TMobile, TItem, TEntity, TIdentity, TTarget>
        where TState : class, IState<TMobile, TItem, TEntity, TIdentity, TTarget>
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

        void EncryptionRequest(TState state);

        void SupportedFeatures(TState state);

        void CharacterList(TState state);

        void LoginConfirm(TState state, TMobile mobile);

        void MapChange(TState state, TMobile mobile);

        void MapPatches(TState state, TMobile mobile);

        void SeasonChange(TState state);

        void MobileUpdate(TState state, TMobile mobile);

        void GlobalLight(TState state);

        void MobileLight(TState state, TMobile mobile);

        void MobileIncoming(TState state, TMobile mobile);

        void MobileStatus(TState state, TMobile mobile);

        void WarModeResponse(TState state, TMobile mobile);

        void LoginComplete(TState state);

        void ServerTime(TState state);

        void SkillInfo(TState state, TMobile mobile);

        void PingResponse(TState state);

        void MoveResponse(TState state, TMobile mobile);

        void ClientVersionRequest(TState state);

        //void ServerChange(TState state, TMobile mobile);

        void EntityInfo(TState state, TEntity entity);

        void EntityAttributes(TState state, TEntity entity);

        //void MobileAttributes(TState state, TMobile mobile);

        void PaperDollOpen(TState state, TMobile mobile);

        void ProfileResponse(TState state, TMobile mobile);

        void EntityDisplay(TState state, TEntity entity);

        void EntityContent(TState state, TEntity entity);

        void EntityRemove(TState state, TEntity entity);

        void SoundPlay(TState state, TTarget target);

        void ItemPlaceApproved(TState state);

        void EntityContentItem(TState state, TItem item);

        void SetItemParent(TEntity entity, TItem item);

        void RemoveItemParent(TItem item);

        void ItemWorld(TState state, TItem item);

        void ItemWearUpdate(TState state, TItem item);

        void MobileMoving(TState state, TMobile mobile);

        void SpeechResponse(TState state, TMobile mobile);

        void TargetRequest(TState state);

        void AssignName(TEntity entity, string name);

        void AssignGraphic(TEntity entity, ushort? graphic);

        void AssignHue(TEntity entity, ushort? hue);

        void AssignMobileItems(TMobile mobile, TState state = null);

        void AssignRace(TState state, HashSet<TIdentity> identitySet);

        void AssignGender(TState state, HashSet<TIdentity> identitySet);

        void UpdateRace(TMobile mobile);

        void UpdateGender(TMobile mobile);

        void AssignLayer(TItem item);

        void AssignDisplayIndex(TItem item);

        void AssignDisplay(TItem item);

        void AssignIdentities(HashSet<TIdentity> identitySet);

        TIdentity Humanoid { get; }

        TIdentity Mobile { get; }

        TIdentity Alive { get; }

        TIdentity Character { get; }

        TIdentity Face { get; }

        TIdentity Container { get; }

        TIdentity Item { get; }

        void AssignProfession(TState state, HashSet<TIdentity> identities);

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
