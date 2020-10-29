using System.Collections.Generic;

namespace Launcher.Domain
{
    using Property = Shard.Server.Validation.Handlers<Validation>;

    public class Entity :
        Shard.Server.Domain.IEntity,
        Shard.Message.Domain.IEntity<Attribute>
    {
        public int Serial
        {
            get => Property.OnGet<int>(this, nameof(Serial));
            set => Property.OnSet(this, nameof(Serial), value);
        }

        public List<Attribute> Attributes { get; set; } = new List<Attribute>
        {
            new Attribute {Number = 1050045, Arguments = $"{string.Empty} \tGeneric Player\t {string.Empty}"},
            new Attribute {Number = 1060658, Arguments = "Staff\t<BASEFONT COLOR=#FFD700>Owner"}
        };

        public Entity()
        {
            Serial = default;
        }
    }
}
