using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Shard.Save.Domain;

namespace Shard.Save
{
    public static class Handlers<TServer, TSave, TProperty>
        where TServer : class, IServer<TServer, TSave, TProperty>
        where TSave : Save<TSave, TServer, TProperty>, new()
        where TProperty : IProperty, new()
    {
        public static TAccess BaseEntity<TAccess, TEntity>(TSave save, TEntity entity)
            where TAccess : IAccess<TAccess, TSave, TServer, TEntity, TProperty>, new()
        {
            var access = new TAccess {Save = save, Entity = entity};

            access.Save.Properties[entity] = new Dictionary<string, TProperty>();

            return access;
        }

        public static TAccess DerivedEntity<TAccess, TEntity>(TSave save, TEntity entity)
            where TAccess : IAccess<TAccess, TSave, TServer, TEntity, TProperty>, new()
        {
            var access = new TAccess { Save = save, Entity = entity };

            return access;
        }

        public static TAccess Property<TAccess, TEntity, TValue>(TAccess access, Expression<Func<TEntity, TValue>> getter, TValue @default = default, int permission = 0)
            where TAccess : IAccess<TAccess, TSave, TServer, TEntity, TProperty>
        {
            var expression = (MemberExpression)getter.Body;

            var name = expression.Member.Name;

            var property = new TProperty{Instance = access.Entity, Name = name, Value = @default, Permission = 0};

            access.Save.Properties[access.Entity][name] = property;

            return access;
        }

        public static TAccess Flush<TAccess, TEntity>(TAccess access, TEntity entity)
            where TAccess : IAccess<TAccess, TSave, TServer, TEntity, TProperty>
        {
            var property = new TProperty {Instance = access.Entity, Name = string.Empty};

            access.Save.Properties[access.Entity][string.Empty] = property;

            //access.Save.Queue.Enqueue(property);

            return access;
        }

        /*public static void SetList<TAccess, TEntity, TValue>(TAccess access, ListChangedType type, TValue value, TProperty parent, object child)
            where TAccess : IAccess<TAccess, TSave, TEntity, TProperty>
        {
            if (!access.Save.Properties.TryGetValue(child, out var properties))
                properties = access.Save.Properties[child] = new Dictionary<string, TProperty>();

            if (!properties.TryGetValue(type.ToString(), out var property))
                property = access.Save.Properties[child][type.ToString()] = new TProperty{Instance = child, Name = type.ToString(), Permission = parent.Permission};

            property.Value = parent.Value;
        }*/

        public static void Set<TAccess, TEntity, TValue>(TAccess access, Expression<Func<TEntity, TValue>> getter, TValue value)
            where TAccess : IAccess<TAccess, TSave, TServer, TEntity, TProperty>
        {
            var expression = (MemberExpression)getter.Body;

            var name = expression.Member.Name;

            var property = access.Save.Properties[access.Entity][name];

            property.Value = value;

            //access.Save.Queue.Enqueue(property);
        }

        public static TValue Get<TAccess, TEntity, TValue>(TAccess access, Expression<Func<TEntity, TValue>> getter)
            where TAccess : IAccess<TAccess, TSave, TServer, TEntity, TProperty>
        {
            var expression = (MemberExpression)getter.Body;

            var name = expression.Member.Name;

            var property = access.Save.Properties[access.Entity][name];

            if (!(property.Value is TValue value) && !TryConvert(out value)) throw new InvalidOperationException($"Invalid property type {typeof(TValue)}, correct type is {property.Value.GetType()}.");

            return value;

            bool TryConvert(out TValue result)
            {
                try
                {
                    result = Convert.ChangeType(property.Value, typeof(TValue)) is TValue correct ? correct : default;

                    return true;
                }
                catch
                {
                    result = default;

                    return false;
                }
            }
        }

        public static TServer Load(TSave save)
        {
            save.Database.Migrate();

            return save.Set<TServer>().IncludeAll().SingleOrDefault() ?? save.Add(save.InitializeServer()).Entity;

            /*var server = save.Set<TServer>().IncludeAll().AsNoTracking().SingleOrDefault();

            save.Queue.Clear();

            if (server != null) return server;

            server = save.InitializeServer();

            save.Add(server);

            save.SaveChanges();

            save.Queue.Clear();

            return server;*/
        }

        public static void Process(TSave save)
        {
            /*var properties = new List<TProperty>();

            while(save.Queue.TryDequeue(out var property)) properties.Add(property);

            foreach (var group in properties.GroupBy(p => p.Instance))
            {
                if (group.Any(p => p.Name == string.Empty)) save.Add(group.Key);
                else save.Update(group.Key);

                save.SaveChanges();
            }*/

            save.SaveChanges();
        }
    }
}
