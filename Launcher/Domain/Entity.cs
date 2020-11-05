using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Launcher.Domain
{
    public class Entity : Target,
        Shard.Server.Domain.IEntity<Item, Entity>,
        Shard.Message.Domain.IEntity<Attribute, Item, Entity>,
        Shard.Mobiles.Domain.IEntity<Item>
    {
        public int Serial { get; set; }

        public string Name { get; set; }

        [NotMapped]
        public List<Attribute> Attributes { get; set; } = new List<Attribute>
        {
            new Attribute {Number = 1050045, Arguments = $"{string.Empty} \tGeneric Player\t {string.Empty}"},
            new Attribute {Number = 1060658, Arguments = "Staff\t<BASEFONT COLOR=#FFD700>Owner"}
        };

        public short EntityDisplayId { get; set; }

        public List<Item> Items { get; set; } = new List<Item>();

        public byte Direction { get; set; }
    }
}
