using System.Collections.Generic;
using System.Linq;

namespace Shard.Message.Domain.Outgoing
{
    public interface ISkillList<TSkillInfo>
        where TSkillInfo : ISkillInfo
    {
        List<TSkillInfo> Skills { get; }

        internal void OnWriteSkillList(IData data)
        {
            data.OnWrite(3, (byte)0x02);

            Enumerable.Range(0, Skills.Count).ToList().ForEach(i => Skills[i].OnWriteSkillInfo(i, data));
        }
    }
}
