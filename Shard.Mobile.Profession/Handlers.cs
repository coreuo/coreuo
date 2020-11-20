using System;
using System.Collections.Generic;
using System.Linq;
using Shard.Mobile.Profession.Domain;

namespace Shard.Mobile.Profession
{
    public static class Handlers<TServer, TState, TMobile, TItem, TEntity, TIdentity>
        where TServer : IServer<TItem, TEntity, TIdentity>
        where TState : IState
        where TMobile : TEntity, IMobile<TIdentity>
    {
        private static void AddProfessionItems(TServer server, sbyte id, IReadOnlyList<ushort> values, params TIdentity[] identities)
        {
            var list = new List<(HashSet<TIdentity>, ushort)>();

            for (var i = 0; i < values.Count; i += 2)
            {
                var graphic = values[i];

                if (graphic == 0) continue;

                var hue = values[i + 1];

                var item = server.GetIdentitiesByGraphic(graphic);

                list.Add((item, hue));
            }

            var profession = new HashSet<TIdentity>(identities);

            AssignProfession(server, id, profession);

            server.Professions.Add(profession, list);
        }

        public static void AddHumanMaleProfessionItems(TServer server, sbyte id, IReadOnlyList<ushort> values)
        {
            AddProfessionItems(server, id, values, server.Human, server.Male);
        }

        public static void AddHumanFemaleProfessionItems(TServer server, sbyte id, IReadOnlyList<ushort> values)
        {
            AddProfessionItems(server, id, values, server.Human, server.Female);
        }

        public static void AddElfMaleProfessionItems(TServer server, sbyte id, IReadOnlyList<ushort> values)
        {
            AddProfessionItems(server, id, values, server.Elf, server.Male);
        }

        public static void AddElfFemaleProfessionItems(TServer server, sbyte id, IReadOnlyList<ushort> values)
        {
            AddProfessionItems(server, id, values, server.Elf, server.Female);
        }

        private static void AssignProfession(TServer server, sbyte profession, ISet<TIdentity> identities)
        {
            identities.Add(profession switch
            {
                -1 => server.CustomProfession,
                0 => server.CustomProfession,
                1 => server.Warrior,
                2 => server.Mage,
                3 => server.Blacksmith,
                4 => server.Necromancer,
                5 => server.Paladin,
                6 => server.Samurai,
                7 => server.Ninja,
                _ => throw new InvalidOperationException($"Unknown profession ({profession})")
            });
        }

        public static void AssignProfession(TServer server, TState state, HashSet<TIdentity> identities) => AssignProfession(server, state.Profession, identities);

        public static void AssignProfessionItems(TServer server, TMobile mobile)
        {
            KeyValuePair<HashSet<TIdentity>, List<(HashSet<TIdentity> identities, ushort hue)>> pair;

            try
            {
                pair = server.Professions.Single(p => mobile.Is(p.Key));
            }
            catch (Exception e)
            {
                throw new InvalidOperationException($"Unknown profession items for mobile ({mobile}) {e}");
            }

            foreach (var (identities, hue) in pair.Value) server.AddItem(mobile, hue, identities);
        }
    }
}
