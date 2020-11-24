using Shard.Save;

namespace Launcher.Domain
{
    using SaveHandlers = Handlers<ShardServer, ShardSave>;

    public class ShardSave : 
        Shard.Save.Domain.Save<ShardSave>
    {
        protected override string Path { get; } = "Save.db";

        public ShardServer Load() => SaveHandlers.Load(this);

        public void Process() => SaveHandlers.Process(this);

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
