namespace Launcher.Domain
{
    public class Skill : Shard.Message.Domain.ISkill
    {
        // ReSharper disable once UnusedMember.Global
        public int Id { get; set; }

        public ushort SkillId { get; init; }

        public ushort Value { get; init; }

        public ushort Base { get; init; }

        public byte Lock { get; init; }

        public ushort Cap { get; init; }
    }
}
