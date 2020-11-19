namespace Shard.Message.Domain.Shared
{
    public interface IMobileAttributes
    {
        public short CurrentHitPoints { get; }

        public short MaximumHitPoints { get; }

        public short CurrentStamina { get; }

        public short MaximumStamina { get; }

        public short CurrentMana { get; }

        public short MaximumMana { get; }
    }
}
