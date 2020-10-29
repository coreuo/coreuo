using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shard.Message.Domain.Outgoing
{
    public interface IAttributeList<TAttribute> : IAttributeInfo<TAttribute>
        where TAttribute : IAttribute
    {
        internal void OnWriteAttributeList(IData data)
        {
            data.OnWrite(3, (short)1);

            data.OnWrite(5, Serial);

            data.OnWrite(9, (short)0);

            data.OnWrite(11, OnGetHash());

            var offset = OnGetAttributesSizeList().Aggregate(0, (o, e) =>
            {
                var (attribute, size) = e;

                data.OnWrite(15 + o, attribute.Number);

                if (attribute.Arguments == null)
                {
                    data.OnWrite(15 + o + 4, (short)0);
                }
                else
                {
                    data.OnWrite(15 + o + 4, (short)data.OnWriteUnicode(15 + o + 4 + 2, attribute.Arguments));
                }

                return o + size;
            });

            data.OnWrite(15 + offset, 0);
        }

        internal List<(TAttribute attribute, int size)> OnGetAttributesSizeList() => Attributes.Select(p => (p, 4 + 2 + (p.Arguments == null ? 0 : Encoding.Unicode.GetByteCount(p.Arguments)))).ToList();
    }
}
