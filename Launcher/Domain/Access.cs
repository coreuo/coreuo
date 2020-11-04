using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq.Expressions;

namespace Launcher.Domain
{
    using ShardSaveHandlers = Shard.Save.Handlers<ShardServer, ShardSave, Property>;

    [NotMapped]
    public class Access<TEntity> :
        Shard.Save.Domain.IAccess<Access<TEntity>, ShardSave, ShardServer, TEntity, Property>
    {
        public ShardSave Save { get; set; }

        public TEntity Entity { get; set; }

        public Access<TEntity> Property<TValue>(Expression<Func<TEntity, TValue>> getter, TValue @default = default, int permission = 0) => ShardSaveHandlers.Property(this, getter, @default, permission);

        public Access<TEntity> Flush() => ShardSaveHandlers.Flush(this, Entity);

        public void Set<TValue>(Expression<Func<TEntity, TValue>> getter, TValue value) => ShardSaveHandlers.Set(this, getter, value);

        public TValue Get<TValue>(Expression<Func<TEntity, TValue>> getter) => ShardSaveHandlers.Get(this, getter);
    }
}
