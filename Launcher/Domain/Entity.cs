using System.Collections.Generic;

namespace Launcher.Domain
{
    public class Entity :
        Shard.Server.Domain.IEntity,
        Shard.Message.Domain.IEntity<Property>
    {
        public int Serial { get; set; }

        public List<Property> Properties { get; set; } = new List<Property>
        {
            new Property {Number = 1050045, Arguments = $"{string.Empty} \tGeneric Player\t {string.Empty}"},
            new Property {Number = 1060658, Arguments = "Staff\t<BASEFONT COLOR=#FFD700>Owner"}
        };
    }
}
