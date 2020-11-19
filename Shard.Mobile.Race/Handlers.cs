using System;
using System.Collections.Generic;
using System.Linq;
using Shard.Mobile.Race.Domain;

namespace Shard.Mobile.Race
{
    public static class Handlers<TServer, TState, TMobile, TItem, TEntity, TIdentity>
        where TServer : IServer<TState, TItem, TEntity, TIdentity>
        where TState : IState
        where TMobile : class, TEntity, IMobile
        where TItem : class, TEntity, IItem
        where TEntity : class, IEntity<TIdentity>
    {
        public static void UpdateRace(TServer server, TMobile mobile)
        {
            if (mobile.Is(server.Human)) mobile.Race = 0;
            else if (mobile.Is(server.Elf)) mobile.Race = 1;
            else throw new InvalidOperationException($"Unable to update mobile ({mobile}) race");
        }

        public static void UpdateGender(TServer server, TMobile mobile)
        {
            if (mobile.Is(server.Male)) mobile.Gender = 0;
            else if (mobile.Is(server.Female)) mobile.Gender = 1;
            else throw new InvalidOperationException($"Unable to update mobile ({mobile}) gender");
        }

        public static void AssignRace(TServer server, TState state, HashSet<TIdentity> identities)
        {
            identities.Add(state.Race switch
            {
                0 => server.Human,
                1 => server.Elf,
                _ => throw new InvalidOperationException($"Invalid state race ({state.Race})")
            });
        }

        public static void AssignGender(TServer server, TState state, HashSet<TIdentity> identities)
        {
            identities.Add(state.Gender switch
            {
                0 => server.Male,
                1 => server.Female,
                _ => throw new InvalidOperationException($"Invalid state gender ({state.Gender})")
            });
        }

        private static void Transfer(TEntity parent, ISet<TIdentity> set, params TIdentity[] identities)
        {
            foreach (var identity in identities) if(parent.Is(identity)) set.Add(identity);
        }

        private static void TransferRace(TServer server, TMobile parent, ISet<TIdentity> set)
        {
            Transfer(parent, set, server.Human, server.Elf);
        }

        private static void TransferGender(TServer server, TMobile parent, ISet<TIdentity> set)
        {
            Transfer(parent, set, server.Male, server.Female);
        }

        private static void AssignItem(TServer server, TState state, TMobile parent, TIdentity identity, bool randomAssign)
        {
            var set = new HashSet<TIdentity> {identity};

            TransferRace(server, parent, set);

            TransferGender(server, parent, set);

            if (randomAssign && server.GraphicRanges.TryGetValue(set, out var ranges) && server.Random.Next(ranges.Size() + 1) == 0) return;

            var item = server.CreateItem(state, set.ToArray());

            server.SetItemParent(parent, item);
        }

        public static void AssignFace(TServer server, TState state, TMobile parent)
        {
            if (state?.FaceGraphic == 0) throw new InvalidOperationException($"Invalid state face ({state.FaceGraphic})");

            AssignItem(server, state, parent, server.Face, false);
        }

        public static void AssignHair(TServer server, TState state, TMobile parent)
        {
            if (state?.HairGraphic == 0) return;

            AssignItem(server, state, parent, server.Hair, state == null);
        }

        public static void AssignBeard(TServer server, TState state, TMobile parent)
        {
            if (!parent.Is(server.Human) || !parent.Is(server.Male) || state?.BeardGraphic == 0) return;

            AssignItem(server, state, parent, server.Beard, state == null);
        }
    }
}