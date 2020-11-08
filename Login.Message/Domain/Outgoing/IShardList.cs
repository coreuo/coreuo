using System.Collections.Generic;
using System.Net;

namespace Login.Message.Domain.Outgoing
{
    public interface IShardList<TShard>
        where TShard : IShard
    {
        public List<TShard> Shards { get; set; }

        internal void WriteShardList(IData data)
        {
            data.Write(3, 0xFF);

            data.Write(4, (short)Shards.Count);

            for (var i = 0; i < Shards.Count; i++)
            {
                var shard = Shards[i];

                data.Write(6 + 40 * i, (short)i);

                data.WriteAscii(6 + 40 * i + 2, shard.Identity);

                data.Write(6 + 40 * i + 34, (byte)shard.Percentage);

                data.Write(6 + 40 * i + 35, (byte)shard.TimeZone);

                IPAddress.Parse(shard.IpAddress).GetAddressBytes().CopyTo(data.Value, 6 + 40 * i + 36);
            }
        }
    }
}
