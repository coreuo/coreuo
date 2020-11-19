using Shard.Message.Domain.Shared;

namespace Shard.Message.Domain.Outgoing
{
    public interface IEntityDisplay :
        ISerialGet
    {
        public ushort Display { get; }

        internal void WriteEntityDisplay(IData data)
        {
            data.Write(1, Serial);

            data.Write(5, Display);
        }
    }
}
