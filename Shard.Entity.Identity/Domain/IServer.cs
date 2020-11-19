using System;
using System.Collections.Generic;
using System.Linq;

namespace Shard.Entity.Identity.Domain
{
    public interface IServer<TEntity, TIdentity>
        where TIdentity : class, IIdentity, new()
    {
        HashSet<TEntity> Entities { get; }

        Random Random { get; }

        Dictionary<string, TIdentity> IdentityNames { get; }

        Dictionary<Guid, TIdentity> IdentityGuids { get; }

        private TIdentity Identity(string guid, string name)
        {
            var identity = new TIdentity { Guid = new Guid(guid), Name = name };

            IdentityNames.Add(identity.Name, identity);

            if(IdentityGuids.TryGetValue(identity.Guid, out var existing))
                throw new InvalidOperationException($"Cannot add identity ({identity}) with guid ({guid}), because identity ({existing}) already has this guid");

            IdentityGuids.Add(identity.Guid, identity);

            return identity;
        }

        TIdentity Male { get; set; }

        TIdentity Female { get; set; }

        TIdentity Human { get; set; }

        TIdentity Elf { get; set; }

        TIdentity Humanoid { get; set; }

        TIdentity Bandit { get; set; }

        TIdentity Ghost { get; set; }

        TIdentity Mobile { get; set; }

        TIdentity Alive { get; set; }

        TIdentity Dead { get; set; }

        TIdentity Character { get; set; }

        TIdentity Corpse { get; set; }

        TIdentity Pants { get; set; }

        TIdentity Dye { get; set; }

        TIdentity Shirt { get; set; }

        TIdentity Shoes { get; set; }

        TIdentity Backpack { get; set; }

        TIdentity Gold { get; set; }

        TIdentity RedBook { get; set; }

        TIdentity Candle { get; set; }

        TIdentity Dagger { get; set; }

        TIdentity Robe { get; set; }

        TIdentity Hair { get; set; }

        TIdentity Face { get; set; }

        TIdentity Beard { get; set; }

        TIdentity BodyPart { get; set; }

        TIdentity Container { get; set; }

        TIdentity Item { get; set; }

        internal void LoadIdentities()
        {
            IdentityNames.Clear();

            IdentityGuids.Clear();

            Male = Identity("4E9266ED-1F02-4CDC-B5A6-E5B0877C5177", nameof(Male));

            Female = Identity("61BC74BF-9B5C-46C4-B8D0-DD106FE2C513", nameof(Female));

            Human = Identity("A200AD91-34A2-4A98-9968-586E07176503", nameof(Human));

            Elf = Identity("A8E2D8A2-F1F2-47CB-9CDE-DFBE838929A8", nameof(Elf));

            Humanoid = Identity("D8D78474-AA82-4981-9A25-ED5AAAE67262", nameof(Humanoid));

            Bandit = Identity("F0F7C9F3-621B-4BCC-A83A-C0C8B55E5BAB", nameof(Bandit));

            Ghost = Identity("E80EB46C-2B8F-4F3E-B962-C8CE0713A9F9", nameof(Ghost));

            Mobile = Identity("46BCFF7D-9AEE-4ECC-A86C-D4A1B1AFA145", nameof(Mobile));

            Alive = Identity("DFEB14F7-F944-47DF-B270-B0F73158B91F", nameof(Alive));

            Dead = Identity("F1ECB67E-BF10-455B-8E04-D1D94F6846AF", nameof(Dead));

            Character = Identity("AAB48727-13F3-4688-B139-C3A8A7280EEB", nameof(Character));

            Corpse = Identity("F2667A5B-6730-42DD-ACDC-64E5244C6589", nameof(Corpse));

            Pants = Identity("92AC93E0-5F63-4F3E-A044-D65B0A768060", nameof(Pants));

            Dye = Identity("7B879005-6070-41C4-A55C-9297CA6BC5E5", nameof(Dye));

            Shirt = Identity("C6A2DCCE-28AC-4066-9EEB-5FAE4841798B", nameof(Shirt));

            Shoes = Identity("F5C0C963-FEDC-4539-ABF8-4E8D042055C1", nameof(Shoes));

            Backpack = Identity("32B02057-4FE8-4345-B92C-E2E5C44AD956", nameof(Backpack));

            Gold = Identity("E0E97E00-1266-4D1A-8F90-CBF40F26832B", nameof(Gold));

            RedBook = Identity("A0CB5022-A812-4B0C-B214-31A3B6B4C304", nameof(RedBook));

            Candle = Identity("33C897E6-D28A-4ABE-8BA2-63DBC39D10D0", nameof(Candle));

            Dagger = Identity("B463EEBD-7DE5-43ED-8F59-2789ADBAE6AA", nameof(Dagger));

            Robe = Identity("06C71EE4-B31A-4EDC-82C5-06926E8DDD44", nameof(Robe));

            Hair = Identity("FFAD623B-2E6E-4E79-B1BC-3233CBD0EAB0", nameof(Hair));

            Face = Identity("E106FDA8-87AD-449B-8A5B-48D39548EB3D", nameof(Face));

            Beard = Identity("35579838-B014-426B-BC41-47CF2F62726A", nameof(Beard));

            BodyPart = Identity("69577C62-9E52-48D3-9FD8-7BDBCE87FB4F", nameof(BodyPart));

            Container = Identity("B79E8E29-EEF0-42EC-A91F-0E6261B01171", nameof(Container));

            Item = Identity("64A01F46-4ED4-4CE2-BDD3-1D921715E931", nameof(Item));

            IdentityTree = BuildTree(new[]
            {
                (Human, Male),
                (Human, Female),
                (Elf, Male),
                (Elf, Female),

                (Humanoid, Human),
                (Humanoid, Elf),
                (Ghost, Human),
                (Ghost, Elf),

                (Character, Humanoid),

                (Mobile, Bandit),
                (Mobile, Ghost),
                (Mobile, Character),

                (Face, Humanoid),
                (Hair, Humanoid),
                (Beard, Human),

                (BodyPart, Hair),
                (BodyPart, Face),
                (BodyPart, Beard),
                (Container, Backpack),

                (Item, Gold),
                (Item, RedBook),
                (Item, Candle),
                (Item, Dagger),
                (Item, Dye),
                (Item, Robe),

                (Item, BodyPart),
                (Item, Container)
            });
        }

        List<HashSet<TIdentity>> IdentityTree { get; set; }

        private static List<HashSet<TIdentity>> BuildTree((TIdentity group, TIdentity member)[] hierarchy)
        {
            var tree = hierarchy.Where(p => hierarchy.All(g => g.group != p.member)).Select(p => new HashSet<TIdentity> { p.member }).ToList();

            while (true)
            {
                var loop = false;

                for (var i = tree.Count - 1; i >= 0; i--)
                {
                    var branch = tree[i];

                    var last = branch.Last();

                    var next = hierarchy.Where(g => g.member == last).Select(p => p.group).ToList();

                    var node = next.FirstOrDefault();

                    if (node == null) continue;

                    tree.AddRange(next.Skip(1).Select(a => branch.Concat(new[] { a }).ToHashSet()));

                    branch.Add(node);

                    loop = true;
                }

                if (loop) continue;

                break;
            }

            return tree;
        }
    }
}
