namespace Launcher.Domain
{
    public class Skill : Shard.Message.Domain.ISkill
    {
        public int Id { get; set; }

        public ushort SkillId { get; set; }

        public ushort Value { get; set; }

        public ushort Base { get; set; }

        public byte Lock { get; set; }

        public ushort Cap { get; set; }
    }
}
