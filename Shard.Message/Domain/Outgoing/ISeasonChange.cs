namespace Shard.Message.Domain.Outgoing
{
    public interface ISeasonChange
    {
        byte Season { get; }

        byte Sound { get; }

        internal void WriteSeasonChange(IData data)
        {
            data.Write(1, Season);

            data.Write(2, Sound);
        }
    }
}