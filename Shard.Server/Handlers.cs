using System;
using System.Collections.Generic;
using System.Linq;
using Shard.Server.Domain;

namespace Shard.Server
{
    public static class Handlers<TServer, TState, TMobile, TItem, TEntity, TIdentity, TTarget>
        where TServer : IServer<TServer, TState, TMobile, TItem, TEntity, TIdentity, TTarget>
        where TState : class, IState<TMobile, TItem, TEntity, TIdentity, TTarget>
        where TEntity : class, TTarget, IEntity<TItem, TEntity, TIdentity>
        where TMobile : class, TEntity, IMobile<TItem, TEntity, TIdentity>, new()
        where TItem : class, TEntity, IItem<TItem, TEntity, TIdentity>, new()
        where TTarget : ITarget
    {
        private static IEnumerable<TIdentity> CreateIdentitySet(TServer server, TIdentity baseIdentity, TState state = null, params TIdentity[] additionalIdentities)
        {
            var identitySet = new HashSet<TIdentity>(new[] {baseIdentity}.Union(additionalIdentities));

            if (state != null && identitySet.Contains(server.Mobile))
            {
                identitySet.Add(server.Character);

                server.AssignRace(state, identitySet);

                server.AssignGender(state, identitySet);

                server.AssignProfession(state, identitySet);
            }
            
            server.AssignIdentities(identitySet);

            if (identitySet.Contains(server.Mobile)) identitySet.Add(server.Alive);

            return identitySet;
        }

        private static TMobile CreateMobile(TServer server)
        {
            var mobile = new TMobile{Serial = server.MobileSerialPool.TryDequeue(out var serial) ? serial : ++server.MaximumMobileSerial};

            server.Entities.Add(mobile);

            return mobile;
        }

        private static TItem CreateItem(TServer server)
        {
            var item = new TItem{Serial = server.ItemSerialPool.TryDequeue(out var serial) ? serial : ++server.MaximumItemSerial, LocationX = 0, LocationY = 0};

            server.Entities.Add(item);

            return item;
        }

        private static void AssignEntity(TServer server, TEntity entity, ushort? graphic = null, ushort? hue = null, string name = null)
        {
            server.AssignGraphic(entity, graphic);

            server.AssignHue(entity, hue);

            server.AssignName(entity, name);
        }

        private static void AssignMobile(TServer server, TMobile mobile, TState state = null)
        {
            if (state != null) AssignEntity(server, mobile, null, state.Hue, state.Name);

            else AssignEntity(server, mobile);

            server.AssignMobileItems(mobile, state);

            if (!mobile.Is(server.Humanoid)) return;

            server.UpdateRace(mobile);

            server.UpdateGender(mobile);
        }

        private static void AssignItem(TServer server, TItem item, ushort? graphic = null, ushort? hue = null)
        {
            AssignEntity(server, item, graphic, hue);

            server.AssignLayer(item);

            if (!item.Is(server.Container)) return;

            server.AssignDisplayIndex(item);

            server.AssignDisplay(item);
        }

        private static TMobile CreateMobile(TServer server, TState state = null, params TIdentity[] identities)
        {
            var identitySet = CreateIdentitySet(server, server.Mobile, state, identities);

            var mobile = CreateMobile(server);

            mobile.Assign(identitySet);

            AssignMobile(server, mobile, state);

            return mobile;
        }

        private static TMobile CreateMobile(TServer server, params TIdentity[] identities) => CreateMobile(server, null, identities);

        public static TItem CreateItem(TServer server, ushort? graphic = null, ushort? hue = null, params TIdentity[] identities)
        {
            var item = CreateItem(server);

            item.Assign(CreateIdentitySet(server, server.Item, null, identities));

            AssignItem(server, item, graphic, hue);

            return item;
        }

        public static void SetItemParent(TServer server, TEntity parent, TItem item)
        {
            RemoveItemParent(item);

            if (item.Is(server.Face)) server.AssignHue(item, parent.Hue);

            var index = 0;

            while (parent.Items.Any(i => i.GridIndex == index)) index++;

            item.GridIndex = item.GridIndex == 0xFF || parent.Items.Any(i => i.GridIndex == item.GridIndex) ? (byte)index : item.GridIndex;

            parent.Items.Add(item);

            item.Parent = parent;
        }

        public static void RemoveItemParent(TItem item)
        {
            item.Parent?.Items.Remove(item);

            item.Parent = null;
        }

        public static void ClientSeed(TServer server, TState state)
        {
            server.EncryptionRequest(state);
        }

        public static void AccountLogin(TServer server, TState state)
        {
            var character = CreateMobile(server, server.Humanoid);

            character.Assign(server.Character);

            server.AssignName(character, "Random character");

            state.Characters = new List<TMobile> {character}; //server.Entities.OfType<TMobile>().ToList();

            server.SupportedFeatures(state);

            server.CharacterList(state);
        }

        public static void CharacterCreate(TServer server, TState state)
        {
            var mobile = CreateMobile(server, state);

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

            server.WarModeResponse(state, mobile);

            server.LoginComplete(state);

            server.ServerTime(state);

            server.SeasonChange(state);
        }

        public static void MobileQuery(TServer server, TState state)
        {
            Action<TState,TMobile> action = state.MobileQueryType switch
            {
                0x04 => server.MobileStatus,
                0x05 => server.SkillInfo,
                _ => throw new InvalidOperationException($"Unknown mobile query type {state.MobileQueryType:X2}.")
            };

            action(state, server.Entities.OfType<TMobile>().Single(e => e.Serial == state.Serial));
        }

        /*public static void ClientLanguage(TServer server, TState state)
        {
        }

        public static void ChatRequest(TServer server, TState state)
        {
        }*/

        public static void PingRequest(TServer server, TState state)
        {
            server.PingResponse(state);
        }

        public static void MoveRequest(TServer server, TState state)
        {
            if (state.Mobile == null) throw new InvalidOperationException("Unknown state mobile.");

            state.TransferMove(state.Mobile);

            server.MoveResponse(state, state.Mobile);
        }

        public static void CharacterLogin(TServer server, TState state)
        {
            var mobile = state.Characters[state.Slot];

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

            server.WarModeResponse(state, mobile);

            server.MobileIncoming(state, mobile);

            server.EntityInfo(state, mobile);

            server.SupportedFeatures(state);

            server.MobileUpdate(state, mobile);

            server.MobileStatus(state, mobile);

            server.WarModeResponse(state, mobile);

            server.MobileIncoming(state, mobile);

            server.LoginComplete(state);

            server.ServerTime(state);

            server.SeasonChange(state);

            server.MapChange(state, mobile);
        }

        public static void EntityQuery(TServer server, TState state)
        {
            state.SerialList.ForEach(s => server.EntityAttributes(state, server.Entities.Single(e => e.Serial == s)));
        }

        public static void EntityUse(TServer server, TState state)
        {
            var entity = (state.Serial & (1 << 31)) == 0 ? server.Entities.Single(e => e.Serial == state.Serial) : state.Mobile;

            Action action = entity switch
            {
                TMobile mobile => () =>
                {
                    server.PaperDollOpen(state, mobile);

                    if (!mobile.Items.Any()) return;

                    foreach (var item in mobile.Items) server.EntityInfo(state, item);
                }
                ,
                TItem container when container.Is(server.Container) => () =>
                {
                    server.EntityDisplay(state, container);

                    if (!container.Items.Any()) return;

                    server.EntityContent(state, container);

                    foreach (var item in container.Items) server.EntityInfo(state, item);
                },
                _ => throw new InvalidOperationException($"Unknown entity type ({entity?.GetType().Name}).")
            };

            action();
        }

        public static void ProfileRequest(TServer server, TState state)
        {
            var entity = server.Entities.Single(e => e.Serial == state.Serial);

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
            if (state.Mobile == null) throw new InvalidOperationException("Unknown state mobile.");

            var item = server.Entities.OfType<TItem>().Single(e => e.Serial == state.Serial);

            server.EntityRemove(state, item);

            state.SoundId = 0x57;

            server.SoundPlay(state, state.Mobile);

            server.MobileStatus(state, state.Mobile);

            if(item.Parent != null) server.EntityInfo(state, item.Parent);
        }

        public static void ItemPlace(TServer server, TState state)
        {
            var parent = server.Entities.SingleOrDefault(e => e.Serial == state.ParentSerial);

            var item = server.Entities.OfType<TItem>().Single(e => e.Serial == state.Serial);

            server.MoveItem(state, parent, item);
        }

        public static void ItemWear(TServer server, TState state)
        {
            var parent = server.Entities.Single(e => e.Serial == state.ParentSerial);

            var item = server.Entities.OfType<TItem>().Single(e => e.Serial == state.Serial);

            server.MoveItem(state, parent.Items.Any(i => i.Layer == item.Layer) ? item.Parent : parent, item);
        }

        public static void WarModeRequest(TServer server, TState state)
        {
            if (state.Mobile == null) throw new InvalidOperationException("Unknown state mobile.");

            state.TransferWarMode(state.Mobile);

            server.WarModeResponse(state, state.Mobile);

            server.MobileMoving(state, state.Mobile);
        }

        public static void SpeechRequest(TServer server, TState state)
        {
            if (state.Mobile == null) throw new InvalidOperationException("Unknown state mobile.");

            if (state.SpeechText?.StartsWith(".add") ?? false) server.TargetRequest(state);

            else server.SpeechResponse(state, state.Mobile);
        }

        /*public static void TargetResponse(TServer server, TState state)
        {
            var rat = CreateMobile(server, server.Rat);

            state.TransferLocation(rat);

            server.MobileMoving(state, rat);

            server.EntityInfo(state, rat);

            rat.Items.ForEach(i =>
            {
                server.ItemWearUpdate(state, i);

                server.EntityInfo(state, i);
            });
        }*/
    }
}
