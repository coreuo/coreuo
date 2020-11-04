using System.ComponentModel.DataAnnotations.Schema;

namespace Launcher.Domain
{
    [NotMapped]
    public class Attribute : 
        Shard.Message.Domain.IAttribute
    {
        public int Number { get; set; }

        public string Arguments { get; set; }
    }
}
