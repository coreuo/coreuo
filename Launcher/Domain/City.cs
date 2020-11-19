using System.ComponentModel.DataAnnotations.Schema;

namespace Launcher.Domain
{
    [NotMapped]
    public class City : Shard.Message.Domain.Outgoing.ICityInfo
    {
        public string Name { get; init; }

        public string Town { get; init; }
    }
}