namespace Shard.Message.Domain.Outgoing
{
    public interface ISkillInfo
    {
        ushort Id { get; set; }

        ushort Value { get; set; }

        ushort Base { get; set; }

        byte Lock { get; set; }

        ushort Cap { get; set; }

        internal void OnWriteSkillInfo(int index, IData data)
        {
            data.OnWrite(6 + index * 9, Id);

            data.OnWrite(6 + index * 9 + 2, Value);

            data.OnWrite(6 + index * 9 + 2 + 2, Base);

            data.OnWrite(6 + index * 9 + 2 + 2 + 2, Lock);

            data.OnWrite(6 + index * 9 + 2 + 2 + 2 + 1, Cap);
        }
    }
}