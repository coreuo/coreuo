using System;
using System.Collections.Generic;
using System.Linq;
using Shard.Server.Domain;

namespace Shard.Server
{
    public static class Handlers<TServer, TState, TEntity, TMobile, TItem>
        where TServer : IServer<TServer, TState, TEntity, TMobile, TItem>
        where TState : IState<TMobile, TItem>
        where TEntity : IEntity
        where TMobile : TEntity, IMobile<TItem>, new()
        where TItem : TEntity, IItem<TItem>, new()
    {
        public static Dictionary<TMobile, Action<TServer, TMobile>[]> Mobiles = new Dictionary<TMobile, Action<TServer, TMobile>[]>();

        public static Dictionary<TItem, Action<TServer, TItem>[]> Items = new Dictionary<TItem, Action<TServer, TItem>[]>();

        public static Action<TServer, TItem>[] GetItemTypes(TItem item) => Items[item];

        public static TMobile CreateMobile(TServer server, params Action<TServer, TMobile>[] types)
        {
            var mobile = new TMobile {Serial = server.MobileSerialPool.TryDequeue(out var serial) ? serial : ++server.MaximumMobileSerial};

            foreach(var type in types) type(server, mobile);

            server.Entities[mobile.Serial] = mobile;

            Mobiles[mobile] = types;

            return mobile;
        }

        public static TItem CreateItem(TServer server, params Action<TServer, TItem>[] types)
        {
            var item = new TItem {Serial = server.ItemSerialPool.TryDequeue(out var serial) ? serial : ++server.MaximumItemSerial};

            foreach (var type in types) type(server, item);

            server.Entities[item.Serial] = item;

            Items[item] = types;

            return item;
        }

        public static void AddItem(TServer server, TItem parent, TItem child)
        {
            var index = 0;

            while (parent.Items.ContainsKey(index)) index++;

            child.GridIndex = (byte)index;

            parent.Items[index] = child;
        }

        public static void ClientSeed(TServer server, TState state)
        {
            server.EncryptionRequest(state);
        }

        public static void AccountLogin(TServer server, TState state)
        {
            state.Characters.Add(CreateMobile(server, server.Human, (_, m) => m.Name = "Generic Player"));

            server.SupportedFeatures(state);

            server.CharacterList(state);
        }

        public static TMobile BeforeCharacterCreate(TServer server, TState state)
        {
            return CreateMobile(server, server.Human);
        }

        public static void CharacterCreate(TServer server, TState state, TMobile mobile)
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

        public static void MobileQuery(TServer server, TState state)
        {
            var action = state.MobileQueryType switch
            {
                0x04 => server.MobileStatus,
                0x05 => server.SkillInfo,
                _ => throw new InvalidOperationException($"Unknown mobile query type {state.MobileQueryType:X}.")
            };

            action(state, (TMobile)server.Entities[state.MobileQuerySerial]);
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

        public static void AttributesQuery(TServer server, TState state)
        {
            state.AttributesQuerySerialList.ForEach(s => server.AttributeList(state, server.Entities[s]));
        }

        public static void DoubleClick(TServer server, TState state)
        {
            var entity = (state.DoubleClickSerial & ~0x7FFFFFFF) == 0 ? server.Entities[state.DoubleClickSerial] : state.Mobile;

            Action action = entity switch
            {
                TMobile mobile => () =>
                {
                    server.OpenPaperDoll(state, mobile);

                    if (!mobile.Equipment.Any()) return;

                    foreach (var item in mobile.Equipment) server.AttributeInfo(state, item);
                }
                ,
                TItem container when server.IsContainer(container) => () =>
                {
                    server.EntityDisplay(state, container);

                    if (!container.Items.Any()) return;

                    server.EntityContent(state, container);

                    foreach (var item in container.Items.Values) server.AttributeInfo(state, item);
                },
                _ => throw new InvalidOperationException($"Unknown entity type {entity.GetType().Name}.")
            };

            action();
        }

        public static void RequestProfile(TServer server, TState state)
        {
            var entity = server.Entities[state.RequestProfileSerial];

            Action action = entity switch
            {
                TMobile mobile when state.RequestProfileMode == 0 => () => server.ProfileResponse(state, mobile),
                TMobile when state.RequestProfileMode == 1 => () => { },
                _ => throw new InvalidOperationException($"Unknown profile request of type {state.RequestProfileMode} for entity {entity.GetType().Name}.")
            };

            action();
        }
    }
}
