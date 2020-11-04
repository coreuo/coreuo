using System.ComponentModel.DataAnnotations.Schema;

namespace Launcher.Domain
{
    [NotMapped]
    public class City : Shard.Message.Domain.Outgoing.ICityInfo
    {
        public string Name { get; set; }

        public string Town { get; set; }
    }
}