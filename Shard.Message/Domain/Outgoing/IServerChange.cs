using Shard.Message.Domain.Shared;

namespace Shard.Message.Domain.Outgoing
{
    public interface IServerChange<TMap> :
        ILocation,
        IMap<TMap>
        where TMap : IMap
    {
        byte FirstUnknownServerChange { get; set; }

        internal void OnWriteServerChange(IData data)
        {
            data.OnWrite(1, LocationX);

            data.OnWrite(3, LocationY);

            data.OnWrite(5, (short)LocationZ);

            data.OnWrite(7, FirstUnknownServerChange);

            data.OnWrite(8, Map.MinimumX);

            data.OnWrite(10, Map.MinimumY);

            data.OnWrite(12, Map.MaximumX);

            data.OnWrite(14, Map.MaximumY);
        }
    }
}
