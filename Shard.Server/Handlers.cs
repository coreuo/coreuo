using System;
using System.Collections.Generic;
using System.Linq;
using Shard.Server.Domain;

namespace Shard.Server
{
    public static class Handlers<TServer, TSave, TState, TEntity, TMobile, TItem>
        where TServer : IServer<TServer, TSave, TState, TEntity, TMobile, TItem>
        where TSave : ISave<TSave, TMobile, TItem>
        where TState : IState<TMobile, TItem>
        where TEntity : IEntity
        where TMobile : TEntity, IMobile<TItem>
        where TItem : TEntity, IItem<TItem>
    {
        public static Dictionary<TMobile, Action<TServer, TMobile>[]> Mobiles = new Dictionary<TMobile, Action<TServer, TMobile>[]>();

        public static Dictionary<TItem, Action<TServer, TItem>[]> Items = new Dictionary<TItem, Action<TServer, TItem>[]>();

        //public static Action<TServer, TItem>[] GetItemTypes(TItem item) => Items[item];

        public static TMobile CreateMobile(TServer server, params Action<TServer, TMobile>[] types)
        {
            var mobile = server.Save.InitializeMobile();

            mobile.Serial = server.MobileSerialPool.TryDequeue(out var serial) ? serial : ++server.MaximumMobileSerial;

            foreach(var type in types) type(server, mobile);

            server.Entities.Add(mobile);

            Mobiles[mobile] = types;

            return mobile;
        }

        public static TItem CreateItem(TServer server, params Action<TServer, TItem>[] types)
        {
            var item = server.Save.InitializeItem();

            item.Serial = server.ItemSerialPool.TryDequeue(out var serial) ? serial : ++server.MaximumItemSerial;

            foreach (var type in types) type(server, item);

            server.Entities.Add(item);

            Items[item] = types;

            return item;
        }

        public static void AddItem(TServer server, TItem parent, TItem child)
        {
            var index = 0;

            while (parent.Items.Any(i => i.GridIndex == index)) index++;

            child.GridIndex = (byte)index;

            parent.Items.Add(child);
        }

        public static void ClientSeed(TServer server, TState state)
        {
            server.EncryptionRequest(state);
        }

        public static void AccountLogin(TServer server, TState state)
        {
            state.Characters = server.Entities.OfType<TMobile>().ToList();

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
            state.AttributesQuerySerialList.ForEach(s => server.AttributeList(state, server.Entities.Single(e => e.Serial == s)));
        }

        public static void DoubleClick(TServer server, TState state)
        {
            var entity = (state.DoubleClickSerial & ~0x7FFFFFFF) == 0 ? server.Entities.Single(e => e.Serial == state.DoubleClickSerial) : state.Mobile;

            Action action = entity switch
            {
                TMobile mobile => () =>
                {
                    server.OpenPaperDoll(state, mobile);

                    if (!mobile.Items.Any()) return;

                    foreach (var item in mobile.Items) server.AttributeInfo(state, item);
                }
                ,
                TItem container when server.IsContainer(container) => () =>
                {
                    server.EntityDisplay(state, container);

                    if (!container.Items.Any()) return;

                    server.EntityContent(state, container);

                    foreach (var item in container.Items) server.AttributeInfo(state, item);
                },
                _ => throw new InvalidOperationException($"Unknown entity type {entity.GetType().Name}.")
            };

            action();
        }

        public static void RequestProfile(TServer server, TState state)
        {
            var entity = server.Entities.Single(e => e.Serial == state.RequestProfileSerial);

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
