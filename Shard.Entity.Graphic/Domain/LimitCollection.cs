using System;
using System.Collections.Generic;
using System.Linq;

namespace Shard.Entity.Graphic.Domain
{
    public class LimitCollection<TIdentity>
    {
        private readonly IEqualityComparer<HashSet<TIdentity>> _comparer = HashSet<TIdentity>.CreateSetComparer();

        private HashSet<TIdentity> _pointer;

        private readonly Dictionary<HashSet<TIdentity>, RangeLimit[]> _collection = new();

        public LimitCollection<TIdentity> Entity(params TIdentity[] identities)
        {
            _pointer = identities.ToHashSet();

            return this;
        }

        public LimitCollection<TIdentity> Limit(params RangeLimit[] entries)
        {
            _collection.Add(_pointer, entries);

            return this;
        }

        public Dictionary<HashSet<TIdentity>, List<Range>> ToDictionary() => _collection.ToDictionary(c => c.Key, c => c.Value.Select(t => t.Range).ToList(), _comparer);
    }
}
