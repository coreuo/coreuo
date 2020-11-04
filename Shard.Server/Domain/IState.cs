using System.Collections.Generic;

namespace Shard.Server.Domain
{
    public interface IState<TMobile, TItem>
        where TMobile : IMobile<TItem>
        where TItem : IItem<TItem>
    {
        List<TMobile> Characters { get; set; }

        TMobile Mobile { get; set; }

        public byte MobileQueryType { get; set; }

        public int MobileQuerySerial { get; set; }

        List<int> AttributesQuerySerialList { get; set; }

        int DoubleClickSerial { get; set; }

        byte RequestProfileMode { get; set; }

        int RequestProfileSerial { get; set; }
    }
}
