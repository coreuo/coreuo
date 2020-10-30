using Shard.Message.Domain.Shared;

namespace Shard.Message.Domain.Outgoing
{
    public interface IEntityDisplay :
        ISerial
    {
        public short EntityDisplayId { get; }

        internal void WriteEntityDisplay(IData data)
        {
            data.Write(1, Serial);

            data.Write(5, EntityDisplayId);
        }
    }
}
