using System;
using System.Collections.Generic;
using System.Linq;

namespace Shard.Mobile.Race
{
    public static class Extensions
    {
        private static int Size(this Range range) => range.End.Value - range.Start.Value + 1;

        public static int Size(this IEnumerable<Range> ranges) => ranges.Sum(r => r.Size());
    }
}
