using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Shard.Save
{
    public static class Extensions
    {
        public static (Domain.Save<TSave>, TType) AddCustom<TSave, TType, TValue>(this (Domain.Save<TSave> save, TType type) context, Expression<Func<TType, TValue>> property)
            where TSave : Domain.Save<TSave>, new()
        {
            return AddCustom(context, property, v => JsonSerializer.Serialize(v, default), v => JsonSerializer.Deserialize<TValue>(v, default));
        }

        private static (Domain.Save<TSave>, TType) AddCustom<TSave, TType, TSource, TTarget>(this (Domain.Save<TSave> save, TType type) context, Expression<Func<TType, TSource>> property, Expression<Func<TSource, TTarget>> source, Expression<Func<TTarget, TSource>> target)
            where TSave : Domain.Save<TSave>, new()
        {
            var expression = (MemberExpression)property.Body;

            var converter = new ValueConverter<TSource, TTarget>(source, target);

            context.save.CustomMapping.Add((typeof(TType), expression.Member.Name, converter));

            return context;
        }

        /// <summary>
        /// Ensures that all navigation properties (up to a certain depth) are eagerly loaded when entities are resolved from this
        /// DbSet.
        /// </summary>
        /// <returns>The queryable representation of this DbSet</returns>
        public static IQueryable<TEntity> IncludeAll<TEntity>(
            this DbSet<TEntity> dbSet,
            int maxDepth = int.MaxValue) where TEntity : class
        {
            IQueryable<TEntity> result = dbSet;
            var context = dbSet.GetService<ICurrentDbContext>().Context;
            var includePaths = GetIncludePaths<TEntity>(context, maxDepth);

            return includePaths.Aggregate(result, (current, includePath) => current.Include(includePath));
        }

        /// <remarks>
        /// Adapted from https://stackoverflow.com/a/49597502/1636276
        /// </remarks>
        // ReSharper disable once SuggestBaseTypeForParameter
        private static IEnumerable<string> GetIncludePaths<T>(DbContext context, int maxDepth = int.MaxValue)
        {
            if (maxDepth < 0)
                throw new ArgumentOutOfRangeException(nameof(maxDepth));

            var entityType = context.Model.FindEntityType(typeof(T));
            var includedNavigation = new HashSet<INavigation>();
            var stack = new Stack<IEnumerator<INavigation>>();

            while (true)
            {
                var entityNavigation = new List<INavigation>();

                if (stack.Count <= maxDepth)
                {
                    entityNavigation.AddRange(entityType.GetNavigations().Where(navigation => includedNavigation.Add(navigation)));
                }

                if (entityNavigation.Count == 0)
                {
                    if (stack.Count > 0)
                        yield return string.Join(".", stack.Reverse().Select(e => e.Current!.Name));
                }
                else
                {
                    foreach (var inverseNavigation in entityNavigation.Select(navigation => navigation.Inverse).Where(inverseNavigation => inverseNavigation != null))
                    {
                        includedNavigation.Add(inverseNavigation);
                    }

                    stack.Push(entityNavigation.GetEnumerator());
                }

                while (stack.Count > 0 && !stack.Peek().MoveNext())
                    stack.Pop();

                if (stack.Count == 0)
                    break;

                entityType = stack.Peek().Current!.TargetEntityType;
            }
        }
    }
}
