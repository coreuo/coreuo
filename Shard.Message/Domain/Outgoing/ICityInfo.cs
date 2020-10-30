namespace Shard.Message.Domain.Outgoing
{
    public interface ICityInfo
    {
        string Name { get; }

        string Town { get; set; }

        internal void WriteCity(int characterListSize, int index, IData data)
        {
            data.Write(4 + characterListSize + 1 + index * 63, index);

            data.WriteAscii(4 + characterListSize + 1 + index * 63 + 1, Name, 31);

            data.WriteAscii(4 + characterListSize + 1 + index * 63 + 1 + 31, Town, 31);
        }
    }
}
