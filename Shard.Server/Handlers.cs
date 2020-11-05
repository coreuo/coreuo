using System;
using System.Collections.Generic;
using System.Linq;
using Shard.Server.Domain;

namespace Shard.Server
{
    public static class Handlers<TServer, TState, TMobile, TItem, TEntity, TTarget>
        where TServer : IServer<TServer, TState, TMobile, TItem, TEntity, TTarget>
        where TState : IState<TMobile, TItem, TEntity>
        where TEntity : class, TTarget, IEntity<TItem, TEntity>
        where TMobile : class, TEntity, IMobile<TItem, TEntity>, new()
        where TItem : class, TEntity, IItem<TItem, TEntity>, new()
        where TTarget : ITarget
    {
        public static Dictionary<TMobile, Action<TServer, TMobile>[]> Mobiles = new Dictionary<TMobile, Action<TServer, TMobile>[]>();

        public static Dictionary<TItem, Action<TServer, TItem>[]> Items = new Dictionary<TItem, Action<TServer, TItem>[]>();

        //public static Action<TServer, TItem>[] GetItemTypes(TItem item) => Items[item];

        public static TMobile CreateMobile(TServer server, params Action<TServer, TMobile>[] types)
        {
            var mobile = new TMobile{Serial = server.MobileSerialPool.TryDequeue(out var serial) ? serial : ++server.MaximumMobileSerial};

            foreach(var type in types) type(server, mobile);

            server.Entities.Add(mobile);

            Mobiles[mobile] = types;

            return mobile;
        }

        public static TItem CreateItem(TServer server, params Action<TServer, TItem>[] types)
        {
            var item = new TItem{Serial = server.ItemSerialPool.TryDequeue(out var serial) ? serial : ++server.MaximumItemSerial};

            foreach (var type in types) type(server, item);

            server.Entities.Add(item);

            Items[item] = types;

            return item;
        }

        public static void AddItem(TServer server, TEntity parent, params TItem[] items)
        {
            var index = 0;

            foreach (var item in items)
            {
                while (parent.Items.Any(i => i.GridIndex == index)) index++;

                item.GridIndex = item.GridIndex == 0xFF || parent.Items.Any(i => i.GridIndex == item.GridIndex) ? (byte)index : item.GridIndex;

                parent.Items.Add(item);

                item.Parent = parent;
            }
        }

        public static void RemoveItem(TServer server, TEntity parent, TItem item)
        {
            item.GridIndex = 0;

            item.Parent = default;

            parent.Items.Remove(item);
        }

        public static void ClientSeed(TServer server, TState state)
        {
            server.EncryptionRequest(state);
        }

        public static void AccountLogin(TServer server, TState state)
        {
            state.Characters = new List<TMobile> {CreateMobile(server, server.Human, (_, m) => m.Name = "Generic Player")}; //server.Entities.OfType<TMobile>().ToList();

            server.SupportedFeatures(state);

            server.CharacterList(state);
        }

        public static TMobile BeforeCharacterCreate(TServer server, TState state)
        {
            return CreateMobile(server, server.Human);
        }

        public static void CharacterCreate(TServer server, TState state, TMobile mobile)
        {
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

        public static void MobileQuery(TServer server, TState state)
        {
            var action = state.MobileQueryType switch
            {
                0x04 => server.MobileStatus,
                0x05 => server.SkillInfo,
                _ => throw new InvalidOperationException($"Unknown mobile query type {state.MobileQueryType:X}.")
            };

            action(state, server.Entities.OfType<TMobile>().Single(e => e.Serial == state.MobileQuerySerial));
        }

        public static void ClientLanguage(TServer server, TState state)
        {
        }

        public static void ChatRequest(TServer server, TState state)
        {

        }

        public static void PingRequest(TServer server, TState state)
        {
            server.PingResponse(state);
        }

        public static void MoveRequest(TServer server, TState state)
        {
            server.MoveResponse(state, state.Mobile);
        }

        public static TMobile BeforeCharacterLogin(TServer server, TState state, int index)
        {
            return state.Characters[index];
        }

        public static void CharacterLogin(TServer server, TState state, TMobile mobile)
        {
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

            server.EntityInfo(state, mobile);

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

        public static void EntityQuery(TServer server, TState state)
        {
            state.EntityQuerySerialList.ForEach(s => server.EntityAttributes(state, server.Entities.Single(e => e.Serial == s)));
        }

        public static void EntityUse(TServer server, TState state)
        {
            var entity = (state.EntityUseSerial & ~0x7FFFFFFF) == 0 ? server.Entities.Single(e => e.Serial == state.EntityUseSerial) : state.Mobile;

            Action action = entity switch
            {
                TMobile mobile => () =>
                {
                    server.PaperDollOpen(state, mobile);

                    if (!mobile.Items.Any()) return;

                    foreach (var item in mobile.Items) server.EntityInfo(state, item);
                }
                ,
                TItem container when server.IsContainer(container) => () =>
                {
                    server.EntityDisplay(state, container);

                    if (!container.Items.Any()) return;

                    server.EntityContent(state, container);

                    foreach (var item in container.Items) server.EntityInfo(state, item);
                },
                _ => throw new InvalidOperationException($"Unknown entity type {entity.GetType().Name}.")
            };

            action();
        }

        public static void ProfileRequest(TServer server, TState state)
        {
            var entity = server.Entities.Single(e => e.Serial == state.ProfileRequestSerial);

            Action action = entity switch
            {
                TMobile mobile when state.ProfileRequestMode == 0 => () => server.ProfileResponse(state, mobile),
                TMobile when state.ProfileRequestMode == 1 => () => { },
                _ => throw new InvalidOperationException($"Unknown profile request of type {state.ProfileRequestMode} for entity {entity.GetType().Name}.")
            };

            action();
        }

        public static void ItemPick(TServer server, TState state)
        {
            var item = server.Entities.OfType<TItem>().Single(e => e.Serial == state.ItemPickSerial);

            if (item.Parent != null) server.RemoveItem(item.Parent, item);

            server.EntityRemove(state, item);

            state.SoundId = 0x57;

            server.SoundPlay(state, state.Mobile);

            server.MobileStatus(state, state.Mobile);

            if(item.Parent != null) server.EntityInfo(state, item.Parent);
        }

        public static void ItemPlace(TServer server, TState state)
        {
            var item = server.Entities.OfType<TItem>().Single(e => e.Serial == state.ItemPickSerial);

            if (state.ItemPlaceContainerSerial == -1)
            {
                item.LocationX = state.ItemPlaceLocationX;

                item.LocationY = state.ItemPlaceLocationY;

                item.LocationZ = state.ItemPlaceLocationZ;

                server.ItemWorld(state, item);

                server.EntityInfo(state, item);

                state.SoundId = 0x42;

                server.SoundPlay(state, state.Mobile);

                server.ItemPlaceApproved(state);

                server.MobileStatus(state, state.Mobile);
            }
            else
            {
                state.SoundId = 0x48;

                server.SoundPlay(state, state.Mobile);

                server.ItemPlaceApproved(state);

                server.MobileStatus(state, state.Mobile);

                var parent = server.Entities.Single(e => e.Serial == state.ItemPlaceContainerSerial);

                item.GridIndex = state.ItemPlaceGridIndex;

                server.AddItem(parent, item);

                server.EntityContentItem(state, item);

                server.EntityInfo(state, item);

                server.EntityInfo(state, parent);
            }
        }

        public static void ItemWear(TServer server, TState state)
        {
            var item = server.Entities.OfType<TItem>().Single(e => e.Serial == state.ItemWearSerial);

            server.ItemPlaceApproved(state);

            var parent = server.Entities.Single(e => e.Serial == state.ItemWearParentSerial);

            server.AddItem(parent, item);

            server.MobileStatus(state, state.Mobile);

            server.ItemWearUpdate(state, item);

            server.EntityInfo(state, item);
        }
    }
}
