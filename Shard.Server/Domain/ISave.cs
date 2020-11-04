using System;

namespace Shard.Server.Domain
{
    public interface ISave<in TSave, out TMobile, out TItem>
    {
        public Action Process { get; }

        TMobile InitializeMobile();

        TItem InitializeItem();
    }
}
