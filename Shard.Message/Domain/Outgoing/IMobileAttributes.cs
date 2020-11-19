using Shard.Message.Domain.Shared;

namespace Shard.Message.Domain.Outgoing
{
    public interface IMobileAttributes :
        ISerialGet,
        Shared.IMobileAttributes
    {
        /*internal void WriteMobileAttributes(IData data)
        {
            data.Write(1, Serial);

            data.Write(5, MaximumHitPoints);

            data.Write(7, CurrentHitPoints);

            data.Write(9, MaximumMana);

            data.Write(11, CurrentMana);

            data.Write(13, MaximumStamina);

            data.Write(15, CurrentStamina);
        }*/
    }
}
