using Shard.Message.Domain.Shared;

namespace Shard.Message.Domain.Outgoing
{
    public interface IMobileAttributes :
        ISerial,
        IAttributes
    {
        internal void OnWriteMobileAttributes(IData data)
        {
            data.OnWrite(1, Serial);

            data.OnWrite(5, MaximumHitPoints);

            data.OnWrite(7, CurrentHitPoints);

            data.OnWrite(9, MaximumMana);

            data.OnWrite(11, CurrentMana);

            data.OnWrite(13, MaximumStamina);

            data.OnWrite(15, CurrentStamina);
        }
    }
}
