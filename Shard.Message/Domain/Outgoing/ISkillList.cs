using System.Collections.Generic;
using System.Linq;

namespace Shard.Message.Domain.Outgoing
{
    public interface ISkillList<TSkillInfo>
        where TSkillInfo : ISkillInfo
    {
        public List<TSkillInfo> Skills { get; }

        internal void WriteSkillList(IData data)
        {
            data.Write(3, (byte)0x02);

            Enumerable.Range(0, Skills.Count).ToList().ForEach(i => Skills[i].WriteSkillInfo(i, data));
        }
    }
}
