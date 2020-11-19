using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Launcher.Domain
{
    using EntityIdentityHandlers = Shard.Entity.Identity.Handlers<ShardServer,Entity, Identity>;

    public class Entity : Target,
        Shard.Server.Domain.IEntity<Item, Entity, Identity>,
        Shard.Message.Domain.IEntity<Attribute, Item, Entity>,
        Shard.Entity.Items.Domain.IEntity<Identity>,
        Shard.Mobile.Race.Domain.IEntity<Identity>,
        Game.Data.Domain.IEntity,
        Shard.Entity.Identity.Domain.IEntity<Identity>,
        Shard.Entity.Graphic.Domain.IEntity<Identity>
    {
        public int Serial { get; init; }

        public HashSet<Guid> GuidIdentities { get; set; } = new();

        public HashSet<Identity> Identities { get; set; } = new();

        public ushort Graphic { get; set; }

        public int GraphicIndex { get; set; }

        public ushort Hue { get; set; }

        public int HueIndex { get; set; }

        public string Name { get; set; }

        public int DisplayIndex { get; set; }

        [NotMapped]
        public List<Attribute> Attributes => new(){new Attribute {Number = 1050045, Arguments = $"{string.Empty} \t{Name}\t {string.Empty}"}};

        public ushort Display { get; set; }

        public List<Item> Items { get; } = new();

        public bool Is(params Identity[] identities) => EntityIdentityHandlers.Is(this, identities);

        public void Set(params Identity[] identities) => EntityIdentityHandlers.Set(this, identities);

        public void Set(IEnumerable<Identity> identities) => EntityIdentityHandlers.Set(this, identities);

        public byte Direction { get; set; }

        public override string ToString() => string.Join(' ', Identities);
    }
}
