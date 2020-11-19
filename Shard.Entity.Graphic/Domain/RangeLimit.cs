using System;

namespace Shard.Entity.Graphic.Domain
{
    public readonly struct RangeLimit
    {
        public Range Range { get; }

        private RangeLimit(int number)
        {
            Range = number..number;
        }

        private RangeLimit(Range range)
        {
            Range = range;
        }

        public static implicit operator RangeLimit(int number)
        {
            return new(number);
        }

        public static implicit operator RangeLimit(Range range)
        {
            return new(range);
        }
    }
}
