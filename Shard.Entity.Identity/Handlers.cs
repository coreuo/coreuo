using System;
using System.Collections.Generic;
using System.Linq;
using Shard.Entity.Identity.Domain;

namespace Shard.Entity.Identity
{
    public static class Handlers<TServer, TEntity, TIdentity>
        where TServer : IServer<TEntity, TIdentity>
        where TEntity : IEntity<TIdentity>
        where TIdentity : class, IIdentity, new()
    {
        private static void LoadIdentities(TServer server, TEntity entity)
        {
            entity.GuidIdentities = new HashSet<Guid>();

            entity.Identities = entity.GuidIdentities.Select(g => server.IdentityGuids[g]).ToHashSet();
        }

        public static void LoadIdentities(TServer server)
        {
            server.Initialize();

            foreach (var entity in server.Entities) LoadIdentities(server, entity);
        }

        public static void AssignIdentities(TServer server, HashSet<TIdentity> identities)
        {
            var candidates = server.IdentityTree.Where(b => identities.All(b.Contains)).ToList();

            if (!candidates.Any()) 
                throw new InvalidOperationException($"Unable to find identities ({string.Join(", ", identities)}) in tree");

            identities.UnionWith(candidates[server.Random.Next(candidates.Count)]);
        }

        private static void AssignIdentity(TEntity entity, TIdentity identity)
        {
            if(identity == null) throw new InvalidOperationException("Unable to assign null identity.");

            entity.GuidIdentities.Add(identity.Guid);

            entity.Identities.Add(identity);
        }

        /*public static void UnsetIdentity(TEntity entity, TIdentity identity)
        {
            entity.GuidIdentities.Remove(identity.Guid);

            entity.Identities.Remove(identity);
        }*/

        public static bool Is(TEntity entity, params TIdentity[] identities) => identities.All(entity.Identities.Contains);

        public static bool Is(TEntity entity, IEnumerable<TIdentity> identities) => identities.All(entity.Identities.Contains);

        public static void Assign(TEntity entity, params TIdentity[] identities)
        {
            foreach (var identity in identities) AssignIdentity(entity, identity);
        }

        public static void Assign(TEntity entity, IEnumerable<TIdentity> identities)
        {
            foreach (var identity in identities) AssignIdentity(entity, identity);
        }
    }
}