using System.Linq;
using Shard.Message.Domain.Shared;

namespace Shard.Message.Domain.Outgoing
{
    public interface IAttributeInfo<TAttribute> :
        ISerial,
        IAttributes<TAttribute>
        where TAttribute : IAttribute
    {
        internal void OnWriteAttributeInfo(IData data)
        {
            data.OnWrite(1, Serial);

            data.OnWrite(5, OnGetHash());
        }

        internal int OnGetHash()
        {
            return Attributes.Aggregate(0, (h, p) => h ^ (p.Number & 0x3FFFFFF) ^ ((p.Number >> 26) & 0x3F) ^ (p.Arguments == null ? 0 : (p.Arguments.GetHashCode() & 0x3FFFFFF) ^ ((p.Arguments.GetHashCode() >> 26) & 0x3F)));
        }
    }
}
