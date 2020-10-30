namespace Shard.Message.Domain.Shared
{
    public interface IMobileAttributes
    {
        public short CurrentHitPoints { get; set; }

        public short MaximumHitPoints { get; set; }

        public short CurrentStamina { get; set; }

        public short MaximumStamina { get; set; }

        public short CurrentMana { get; set; }

        public short MaximumMana { get; set; }
    }
}
