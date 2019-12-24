namespace Shard.Message.Domain.Outgoing
{
    public interface ISeasonChange
    {
        byte Season { get; set; }

        byte Sound { get; set; }

        internal void WriteSeasonChange(IData data)
        {
            data.Write(1, Season);

            data.Write(2, Sound);
        }
    }
}