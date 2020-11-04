using System;
using Shard.Save;

namespace Launcher.Domain
{
    using SaveHandlers = Handlers<ShardServer, ShardSave, Property>;

    public class ShardSave : 
        Shard.Save.Domain.Save<ShardSave, ShardServer, Property>,
        Shard.Server.Domain.ISave<ShardSave, Mobile, Item>
    {
        public override string Path { get; set; } = "Save.db";

        public ShardServer Load() => SaveHandlers.Load(this);

        public Action Process => () => SaveHandlers.Process(this);

        public Access<TEntity> BaseEntity<TEntity>(TEntity entity) => SaveHandlers.BaseEntity<Access<TEntity>, TEntity>(this, entity);

        public Access<TEntity> DerivedEntity<TEntity>(TEntity entity) => SaveHandlers.DerivedEntity<Access<TEntity>, TEntity>(this, entity);

        public ShardSave()
        {
            AddType<Entity>();

            AddType<Item>();

            AddType<Map>();

            AddType<Mobile>();

            AddType<ShardServer>()
                .AddCustom(s => s.MobileSerialPool)
                .AddCustom(s => s.ItemSerialPool);

            AddType<ShardState>();

            AddType<Skill>();
        }

        public override ShardServer InitializeServer() => new ShardServer(this);

        public Mobile InitializeMobile() => new Mobile(this);

        public Item InitializeItem() => new Item(this);
    }
}
