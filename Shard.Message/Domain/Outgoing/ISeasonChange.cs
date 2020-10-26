namespace Shard.Message.Domain.Outgoing
{
    public interface ISeasonChange
    {
        byte Season { get; set; }

        byte Sound { get; set; }

        internal void OnWriteSeasonChange(IData data)
        {
            data.OnWrite(1, Season);

            data.OnWrite(2, Sound);
        }
    }
}