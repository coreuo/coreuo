namespace Shard.Message.Domain.Shared
{
    public interface IAttributes
    {
        short CurrentHitPoints { get; set; }

        short MaximumHitPoints { get; set; }

        short CurrentStamina { get; set; }

        short MaximumStamina { get; set; }

        short CurrentMana { get; set; }

        short MaximumMana { get; set; }
    }
}
