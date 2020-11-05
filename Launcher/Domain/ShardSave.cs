using System;
using Shard.Save;

namespace Launcher.Domain
{
    using SaveHandlers = Handlers<ShardServer, ShardSave>;

    public class ShardSave : 
        Shard.Save.Domain.Save<ShardSave>
    {
        public override string Path { get; set; } = "Save.db";

        public ShardServer Load() => SaveHandlers.Load(this);

        public Action Process => () => SaveHandlers.Process(this);

        public ShardSave()
        {
            AddType<Target>();

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
    }
}
