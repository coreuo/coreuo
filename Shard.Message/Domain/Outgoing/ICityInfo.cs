namespace Shard.Message.Domain.Outgoing
{
    public interface ICityInfo
    {
        string Name { get; set; }

        string Town { get; set; }

        internal void OnWriteCity(int characterListSize, int index, IData data)
        {
            data.OnWrite(4 + characterListSize + 1 + index * 63, index);

            data.OnWrite(4 + characterListSize + 1 + index * 63 + 1, Name);

            data.OnWrite(4 + characterListSize + 1 + index * 63 + 1 + 31, Town);
        }
    }
}
