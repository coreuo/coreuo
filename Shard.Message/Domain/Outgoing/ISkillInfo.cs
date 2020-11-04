namespace Shard.Message.Domain.Outgoing
{
    public interface ISkillInfo
    {
        ushort SkillId { get; set; }

        ushort Value { get; set; }

        ushort Base { get; set; }

        byte Lock { get; set; }

        ushort Cap { get; set; }

        internal void WriteSkillInfo(int index, IData data)
        {
            data.Write(6 + index * 9, SkillId);

            data.Write(6 + index * 9 + 2, Value);

            data.Write(6 + index * 9 + 2 + 2, Base);

            data.Write(6 + index * 9 + 2 + 2 + 2, Lock);

            data.Write(6 + index * 9 + 2 + 2 + 2 + 1, Cap);
        }
    }
}