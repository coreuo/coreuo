using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shard.Message.Domain.Outgoing
{
    public interface IEntityAttributes<TAttribute> : IEntityInfo<TAttribute>
        where TAttribute : IAttribute
    {
        internal void WriteEntityAttributes(IData data)
        {
            data.Write(3, (short)1);

            data.Write(5, Serial);

            data.Write(9, (short)0);

            data.Write(11, GetHash());

            var offset = GetAttributesSizeList().Aggregate(0, (o, e) =>
            {
                var (attribute, size) = e;

                data.Write(15 + o, attribute.Number);

                if (attribute.Arguments == null)
                {
                    data.Write(15 + o + 4, (short)0);
                }
                else
                {
                    data.Write(15 + o + 4, (short)data.WriteUnicode(15 + o + 4 + 2, attribute.Arguments));
                }

                return o + size;
            });

            data.Write(15 + offset, 0);
        }

        internal List<(TAttribute attribute, int size)> GetAttributesSizeList() => Attributes.Select(p => (p, 4 + 2 + (p.Arguments == null ? 0 : Encoding.Unicode.GetByteCount(p.Arguments)))).ToList();
    }
}
