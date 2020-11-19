using System;
using System.Collections.Generic;
using System.Linq;

namespace Shard.Entity.Graphic
{
    public static class Extensions
    {
        private static int Size(this Range range) => range.End.Value - range.Start.Value + 1;

        public static int Size(this IEnumerable<Range> ranges) => ranges.Sum(r => r.Size());

        private static bool Contains(this Range range, int value) => range.Start.Value <= value && range.End.Value >= value;

        private static int IndexOf(this Range range, int value) => range.Contains(value) ? range.End.Value - value : -1;

        public static bool Contains(this IEnumerable<Range> ranges, int value) => ranges.Any(r => r.Contains(value));

        public static int IndexOf(this IEnumerable<Range> ranges, int value)
        {
            var total = 0;

            foreach (var entry in ranges)
            {
                var index = entry.IndexOf(value);

                if (index < 0) total += entry.Size();

                else return total + index;
            }

            return -1;
        }

        private static T ElementAt<T>(this Range range, int index) => (T)Convert.ChangeType(range.End.Value - index, typeof(T));

        public static T ElementAt<T>(this IEnumerable<Range> ranges, int index)
        {
            foreach (var entry in ranges)
            {
                var size = entry.Size();

                if (index < size) return entry.ElementAt<T>(index);

                index -= size;
            }

            return default;
        }
    }
}
