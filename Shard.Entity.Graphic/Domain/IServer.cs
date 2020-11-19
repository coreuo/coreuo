using System;
using System.Collections.Generic;
using System.Linq;

namespace Shard.Entity.Graphic.Domain
{
    public interface IServer<TIdentity>
    {
        Random Random { get; }

        TIdentity Male { get; }

        TIdentity Female { get; }

        TIdentity Human { get; }

        TIdentity Elf { get; }

        TIdentity Humanoid { get; }

        TIdentity Ghost { get; }

        TIdentity Mobile { get; }

        TIdentity Alive { get; }

        TIdentity Corpse { get; }

        TIdentity Dye { get; }

        TIdentity Pants { get; }

        TIdentity Shirt { get; }

        TIdentity Shoes { get; }

        TIdentity Backpack { get; }

        TIdentity Gold { get; }

        TIdentity RedBook { get; }

        TIdentity Candle { get; }

        TIdentity Dagger { get; }

        TIdentity Robe { get; }

        TIdentity Hair { get; }

        TIdentity Face { get; }

        TIdentity Beard { get; }

        TIdentity Item { get; }

        Dictionary<HashSet<TIdentity>, List<Range>> GraphicRanges { get; set; }

        Dictionary<HashSet<TIdentity>, List<Range>> HueRanges { get; set; }

        List<TIdentity> Containers { get; set; }

        internal void LoadGraphicRanges()
        {
            GraphicRanges = new LimitCollection<TIdentity>()
                .Entity(Alive, Human, Male).Limit(400)
                .Entity(Alive, Human, Female).Limit(401)
                .Entity(Ghost, Human, Male).Limit(402)
                .Entity(Ghost, Human, Female).Limit(403)
                .Entity(Alive, Elf, Male).Limit(605)
                .Entity(Alive, Elf, Female).Limit(606)
                .Entity(Ghost, Elf, Male).Limit(607)
                .Entity(Ghost, Elf, Female).Limit(608)
                .Entity(Backpack).Limit(0xE75)
                .Entity(Gold).Limit(0xEED)
                .Entity(RedBook).Limit(0xFF1)
                .Entity(Candle).Limit(0xA28)
                .Entity(Dagger).Limit(0xF52)
                .Entity(Robe).Limit(0x1F03)
                .ToDictionary();
        }

        internal void LoadHueRanges()
        {
            HueRanges = new LimitCollection<TIdentity>()
                .Entity(Mobile).Limit(0)
                .Entity(Item).Limit(0)
                .ToDictionary();
        }

        internal void LoadContainers()
        {
            Containers = new List<TIdentity>
            {
                Corpse,
                Backpack
            };
        }

        internal void AddRange(Dictionary<HashSet<TIdentity>, List<Range>> rangesDictionary, IEnumerable<Range> values, params TIdentity[] identities)
        {
            var set = identities.ToHashSet();

            if (rangesDictionary.TryGetValue(set, out var ranges)) ranges.AddRange(values);

            else rangesDictionary.Add(set, values.ToList());
        }

        internal void AddRange(Dictionary<HashSet<TIdentity>, List<Range>> rangesDictionary, IEnumerable<ushort> values, params TIdentity[] identities) => AddRange(rangesDictionary, values.Select(v => v..v).ToArray(), identities);

        internal void AddGraphicRange(IEnumerable<ushort> values, params TIdentity[] identities) => AddRange(GraphicRanges, values, identities);

        internal void AddHueRange(Range range, params TIdentity[] identities) => AddRange(HueRanges, new[]{range}, identities);

        internal void AddHueRange(IEnumerable<ushort> values, params TIdentity[] identities) => AddRange(HueRanges, values, identities);
    }
}
