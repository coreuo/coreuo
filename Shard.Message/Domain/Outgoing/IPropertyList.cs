using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shard.Message.Domain.Outgoing
{
    public interface IPropertyList<TProperty> : IPropertyInfo<TProperty>
        where TProperty : IProperty
    {
        internal void OnWritePropertyList(IData data)
        {
            data.OnWrite(3, (short)1);

            data.OnWrite(5, Serial);

            data.OnWrite(9, (short)0);

            data.OnWrite(11, OnGetHash());

            var offset = OnGetPropertiesSizeList().Aggregate(0, (o, e) =>
            {
                var (property, size) = e;

                data.OnWrite(15 + o, property.Number);

                if (property.Arguments == null)
                {
                    data.OnWrite(15 + o + 4, (short)0);
                }
                else
                {
                    data.OnWrite(15 + o + 4, (short)data.OnWriteUnicode(15 + o + 4 + 2, property.Arguments));
                }

                return o + size;
            });

            data.OnWrite(15 + offset, 0);
        }

        internal List<(TProperty property, int size)> OnGetPropertiesSizeList() => Properties.Select(p => (p, 4 + 2 + (p.Arguments == null ? 0 : Encoding.Unicode.GetByteCount(p.Arguments)))).ToList();
    }
}
