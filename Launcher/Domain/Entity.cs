using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Launcher.Domain
{
    public class Entity :
        Shard.Server.Domain.IEntity,
        Shard.Message.Domain.IEntity<Attribute, Item>
    {
        public Entity(ShardSave save)
        {
            Access = save.BaseEntity(this)
                .Property(e => e.Serial)
                .Property(e => e.EntityDisplayId)
                .Property(e => e.Items, new List<Item>())
                .Property(e => e.Map, new Map());
        }

        [NotMapped] public Access<Entity> Access { get; set; }

        public int Id { get; set; }

        public int Serial
        {
            get => Access.Get(e => e.Serial);
            set => Access.Set(e => e.Serial, value);
        }

        [NotMapped]
        public List<Attribute> Attributes { get; set; } = new List<Attribute>
        {
            new Attribute {Number = 1050045, Arguments = $"{string.Empty} \tGeneric Player\t {string.Empty}"},
            new Attribute {Number = 1060658, Arguments = "Staff\t<BASEFONT COLOR=#FFD700>Owner"}
        };

        public short EntityDisplayId
        {
            get => Access.Get(e => e.EntityDisplayId);
            set => Access.Set(e => e.EntityDisplayId, value);
        }

        public List<Item> Items
        {
            get => Access.Get(e => e.Items);
            set => Access.Set(e => e.Items, value);
        }

        public Map Map
        {
            get => Access.Get(e => e.Map);
            set => Access.Set(e => e.Map, value);
        }
    }
}
