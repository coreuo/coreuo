namespace Shard.Message.Domain.Outgoing
{
    public interface ICityInfo
    {
        string Name { get; }

        string Town { get; set; }

        internal void OnWriteCity(int characterListSize, int index, IData data)
        {
            data.OnWrite(4 + characterListSize + 1 + index * 63, index);

            data.OnWriteAscii(4 + characterListSize + 1 + index * 63 + 1, Name, 31);

            data.OnWriteAscii(4 + characterListSize + 1 + index * 63 + 1 + 31, Town, 31);
        }
    }
}
