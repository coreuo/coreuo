using System;
using System.Linq.Expressions;

namespace Shard.Save.Domain
{
    public interface IAccess<out TAccess, TSave, TServer, TEntity, TProperty>
        where TAccess : IAccess<TAccess, TSave, TServer, TEntity, TProperty>
        where TSave : Save<TSave, TServer, TProperty>
        where TServer : IServer<TServer, TSave, TProperty>
        where TProperty : IProperty
    {
        TSave Save { get; set; }

        TEntity Entity { get; set; }

        TAccess Property<TValue>(Expression<Func<TEntity, TValue>> setter, TValue @default = default, int permission = 0);

        public void Set<TValue>(Expression<Func<TEntity, TValue>> property, TValue value);

        public TValue Get<TValue>(Expression<Func<TEntity, TValue>> property);
    }
}
