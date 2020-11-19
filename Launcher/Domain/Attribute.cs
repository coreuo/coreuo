using System.ComponentModel.DataAnnotations.Schema;

namespace Launcher.Domain
{
    [NotMapped]
    public class Attribute : 
        Shard.Message.Domain.IAttribute
    {
        public int Number { get; init; }

        public string Arguments { get; init; }
    }
}
