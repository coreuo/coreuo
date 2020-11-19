namespace Game.Data.Domain
{
    public interface ICsvDocument
    {
        string[] Header { init; }

        string[][] Data { get; init; }
    }
}
