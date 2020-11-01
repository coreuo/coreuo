using System.Collections.Generic;
using System.Linq;
using Shard.Message.Domain.Shared;

namespace Shard.Message.Domain.Outgoing
{
    public interface IEntityContent<TItem> : 
        ISerial
        where TItem : IEntityContentItem
    {
        Dictionary<int, TItem> Items { get; }

        internal void WriteEntityContent(IData data)
        {
            data.Write(3, (ushort)Items.Count);

            foreach (var (pair, index) in Items.Select((e, i) => (e, i))) pair.Value.WriteEntityContentItem(Serial, 20 * index, data);
        }
    }
}
