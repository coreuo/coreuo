namespace Launcher.Domain
{
    public sealed record CsvDocument :
        Game.Data.Domain.ICsvDocument
    {
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public string[] Header { get; init; }

        public string[][] Data { get; init; }
    }
}