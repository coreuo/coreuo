using Shard.Message.Domain.Shared;

namespace Shard.Message.Domain.Outgoing
{
    public interface IServerChange<TMap> :
        ILocation,
        IMap<TMap>
        where TMap : IMap
    {
        /*public byte FirstUnknownServerChange { get; set; }

        internal void WriteServerChange(IData data)
        {
            data.Write(1, LocationX);

            data.Write(3, LocationY);

            data.Write(5, (short)LocationZ);

            data.Write(7, FirstUnknownServerChange);

            data.Write(8, Map.MinimumX);

            data.Write(10, Map.MinimumY);

            data.Write(12, Map.MaximumX);

            data.Write(14, Map.MaximumY);
        }*/
    }
}
