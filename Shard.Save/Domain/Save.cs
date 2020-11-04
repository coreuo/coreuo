using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Shard.Save.Domain
{
    public abstract class Save<TSave, TServer, TProperty> : DbContext
        where TSave : Save<TSave, TServer, TProperty>
        where TServer : IServer<TServer, TSave, TProperty>
        where TProperty : IProperty
    {
        public ConcurrentQueue<TProperty> Queue { get; set; } = new ConcurrentQueue<TProperty>();

        public Dictionary<object, Dictionary<string, TProperty>> Properties { get; } = new Dictionary<object, Dictionary<string, TProperty>>();

        private Dictionary<Type, string> Mapping { get; } = new Dictionary<Type, string>();

        public List<(Type, string type, ValueConverter converter)> CustomMapping { get; } = new List<(Type, string, ValueConverter)>();

        public virtual string Path { get; set; }

        protected (Save<TSave, TServer, TProperty>, TType) AddType<TType>()
        {
            Mapping.Add(typeof(TType), typeof(TType).Name);

            return (this, default);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={Path}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore(typeof(Action));

            foreach (var (key, value) in Mapping) modelBuilder.Entity(key).ToTable(value);

            foreach (var (key, type, converter) in CustomMapping) modelBuilder.Entity(key).Property(type).HasConversion(converter);
        }

        public abstract TServer InitializeServer();
    }
}
