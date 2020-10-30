using System;
using System.Collections.Generic;
using System.Linq;
using Shard.Server.Domain;

namespace Shard.Server
{
    public static class Handlers<TServer, TState, TEntity, TMobile, TItem>
        where TServer : IServer<TServer, TState, TEntity, TMobile, TItem>
        where TState : IState<TMobile>
        where TEntity : IEntity
        where TMobile : TEntity, IMobile, new()
        where TItem : TEntity, IItem, new()
    {
        public static Dictionary<TMobile, Action<TServer, TMobile>[]> Mobiles = new Dictionary<TMobile, Action<TServer, TMobile>[]>();

        public static Dictionary<TItem, Action<TServer, TItem>[]> Items = new Dictionary<TItem, Action<TServer, TItem>[]>();

        public static Action<TServer, TItem>[] GetItemTypes(TItem item) => Items[item];

        public static TMobile CreateMobile(TServer server, params Action<TServer, TMobile>[] types)
        {
            var mobile = new TMobile {Serial = server.MobileSerialPool.Pop()};

            types.ToList().ForEach(t => t(server, mobile));

            server.Entities[mobile.Serial] = mobile;

            Mobiles[mobile] = types;

            return mobile;
        }

        public static TItem CreateItem(TServer server, params Action<TServer, TItem>[] types)
        {
            var item = new TItem {Serial = server.ItemSerialPool.Pop()};

            types.ToList().ForEach(t => t(server, item));

            server.Entities[item.Serial] = item;

            Items[item] = types;

            return item;
        }

        public static void ClientSeed(TServer server, TState state)
        {
            server.EncryptionRequest(state);
        }

        public static void AccountLogin(TServer server, TState state)
        {
            state.Characters.Add(CreateMobile(server, server.Human, (_, m) =>
            {
                m.Serial = 1;

                m.Name = "Generic Player";
            }));

            server.SupportedFeatures(state);

            server.CharacterList(state);
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
            if ((state.DoubleClickSerial & ~0x7FFFFFFF) != 0)
            {
                server.OpenPaperDoll(state, state.Mobile);

                return;
            }

            var entity = server.Entities[state.DoubleClickSerial];

            Action action = entity switch
            {
                TMobile mobile => () => server.OpenPaperDoll(state, mobile),
                TItem item when server.IsContainer(item) => () => server.EntityDisplay(state, item),
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
