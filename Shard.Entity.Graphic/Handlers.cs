using System;
using System.Collections.Generic;
using System.Linq;
using Shard.Entity.Graphic.Domain;

namespace Shard.Entity.Graphic
{
    public static class Handlers<TServer, TEntity, TIdentity>
    where TServer : IServer<TIdentity>
    where TEntity : IEntity<TIdentity>
    {
        public static void LoadGraphicRanges(TServer server)
        {
            server.LoadGraphicRanges();
        }

        public static void LoadHueRanges(TServer server)
        {
            server.LoadHueRanges();
        }

        public static void LoadContainers(TServer server)
        {
            server.LoadContainers();
        }

        public static void AddHumanHues(TServer server, Range range)
        {
            server.AddHueRange(range, server.Alive, server.Human);

            server.AddHueRange(range, server.Face, server.Human);
        }

        public static void AddElfHues(TServer server, ushort[] values)
        {
            server.AddHueRange(values, server.Alive, server.Elf);

            server.AddHueRange(values, server.Face, server.Elf);
        }

        public static void AddHumanoidFaceGraphics(TServer server, IEnumerable<ushort> values)
        {
            server.AddGraphicRange(values, server.Face, server.Humanoid);
        }

        public static void AddHumanMaleHairGraphics(TServer server, IEnumerable<ushort> values)
        {
            server.AddGraphicRange(values, server.Hair, server.Human, server.Male);
        }

        public static void AddElfMaleHairGraphics(TServer server, IEnumerable<ushort> values)
        {
            server.AddGraphicRange(values, server.Hair, server.Elf, server.Male);
        }

        public static void AddHumanFemaleHairGraphics(TServer server, IEnumerable<ushort> values)
        {
            server.AddGraphicRange(values, server.Hair, server.Human, server.Female);
        }

        public static void AddElfFemaleHairGraphics(TServer server, IEnumerable<ushort> values)
        {
            server.AddGraphicRange(values, server.Hair, server.Elf, server.Female);
        }

        public static void AddHumanHairHues(TServer server, Range range)
        {
            server.AddHueRange(range, server.Hair, server.Human);
        }

        public static void AddElfHairHues(TServer server, IEnumerable<ushort> values)
        {
            server.AddHueRange(values, server.Hair, server.Elf);
        }

        public static void AddHumanMaleBeardGraphics(TServer server, IEnumerable<ushort> values)
        {
            server.AddGraphicRange(values, server.Beard, server.Human, server.Male);
        }

        public static void AddHumanBeardHues(TServer server, Range range)
        {
            server.AddHueRange(range, server.Beard, server.Human);
        }

        public static void AddDyeHues(TServer server, Range range)
        {
            server.AddHueRange(range, server.Dye);
        }

        public static void AddHumanMalePantsGraphics(TServer server, IEnumerable<ushort> values)
        {
            server.AddGraphicRange(values, server.Pants, server.Human, server.Male);
        }

        public static void AddElfMalePantsGraphics(TServer server, IEnumerable<ushort> values)
        {
            server.AddGraphicRange(values, server.Pants, server.Elf, server.Male);
        }

        public static void AddHumanFemalePantsGraphics(TServer server, IEnumerable<ushort> values)
        {
            server.AddGraphicRange(values, server.Pants, server.Human, server.Female);
        }

        public static void AddElfFemalePantsGraphics(TServer server, IEnumerable<ushort> values)
        {
            server.AddGraphicRange(values, server.Pants, server.Elf, server.Female);
        }

        public static void AddPantsHues(TServer server, Range range)
        {
            server.AddHueRange(range, server.Pants);
        }

        public static void AddHumanMaleShirtGraphics(TServer server, IEnumerable<ushort> values)
        {
            server.AddGraphicRange(values, server.Shirt, server.Human, server.Male);
        }

        public static void AddElfMaleShirtGraphics(TServer server, IEnumerable<ushort> values)
        {
            server.AddGraphicRange(values, server.Shirt, server.Elf, server.Male);
        }

        public static void AddHumanFemaleShirtGraphics(TServer server, IEnumerable<ushort> values)
        {
            server.AddGraphicRange(values, server.Shirt, server.Human, server.Female);
        }

        public static void AddElfFemaleShirtGraphics(TServer server, IEnumerable<ushort> values)
        {
            server.AddGraphicRange(values, server.Shirt, server.Elf, server.Female);
        }

        public static void AddShirtHues(TServer server, Range range)
        {
            server.AddHueRange(range, server.Shirt);
        }

        public static void AddHumanMaleShoesGraphics(TServer server, IEnumerable<ushort> values)
        {
            server.AddGraphicRange(values, server.Shoes, server.Elf, server.Male);
        }

        public static void AddElfMaleShoesGraphics(TServer server, IEnumerable<ushort> values)
        {
            server.AddGraphicRange(values, server.Shoes, server.Elf, server.Male);
        }

        public static void AddHumanFemaleShoesGraphics(TServer server, IEnumerable<ushort> values)
        {
            server.AddGraphicRange(values, server.Shoes, server.Elf, server.Female);
        }

        public static void AddElfFemaleShoesGraphics(TServer server, IEnumerable<ushort> values)
        {
            server.AddGraphicRange(values, server.Shoes, server.Elf, server.Female);
        }

        private static void UpdateValue(IEnumerable<Range> ranges, int index, Action<ushort> assigner)
        {
            assigner(ranges.ElementAt<ushort>(index));
        }

        /*public static void UpdateGraphic(TServer server, TEntity entity)
        {
            if (!server.GraphicRanges.TryGetValue(entity.Identities, out var ranges))
                throw new InvalidOperationException($"Unknown graphic ranges for entity ({entity})");

            UpdateValue(ranges, entity.GraphicIndex, v => entity.Graphic = v);
        }*/

        /*public static void UpdateHue(TServer server, TEntity entity)
        {
            if (!server.HueRanges.TryGetValue(entity.Identities, out var ranges))
                throw new InvalidOperationException($"Unknown hue ranges for entity ({entity})");

            UpdateValue(ranges, entity.HueIndex, v => entity.Hue = v);
        }*/

        private static void AssignValue(TServer server, TEntity entity, string name, IReadOnlyCollection<Range> ranges, ushort? value, Action<ushort> valueAssigner, Action<int> indexAssigner, bool random)
        {
            if (value == null)
            {
                var index = random ? server.Random.Next(ranges.Size()) : 0;

                indexAssigner(index);

                UpdateValue(ranges, index, valueAssigner);
            }
            else if (!ranges.Contains(value.Value))
                throw new InvalidOperationException($"Invalid {name} value ({value}) for entity ({entity}) valid are ({string.Join(" ", ranges)})");
            else
            {
                indexAssigner(ranges.IndexOf(value.Value));

                valueAssigner(value.Value);
            }
        }

        public static void AssignGraphic(TServer server, TEntity entity, ushort? value)
        {
            var ranges = server.GraphicRanges.Where(p => p.Key.All(i => entity.Is(i))).SelectMany(p => p.Value).ToList();

            if(!ranges.Any()) throw new InvalidOperationException($"Unknown graphic ranges for entity ({entity})");

            AssignValue(server, entity, nameof(entity.Graphic), ranges, value, v => entity.Graphic = v, i => entity.GraphicIndex = i, false);
        }

        public static void AssignHue(TServer server, TEntity entity, ushort? value)
        {
            var ranges = server.HueRanges.Where(p => p.Key.All(i => entity.Is(i))).SelectMany(p => p.Value).ToList();

            if (!ranges.Any()) throw new InvalidOperationException($"Unknown hue ranges for entity ({entity})");

            AssignValue(server, entity, nameof(entity.Hue), ranges, value, v => entity.Hue = v, i => entity.HueIndex = i, true);
        }

        public static void AssignDisplayIndex(TServer server, TEntity entity)
        {
            entity.DisplayIndex = server.Containers.Select((t, i) => new {Type = t, Index = i}).Single(g => entity.Is(g.Type)).Index;
        }

        public static HashSet<TIdentity> GetIdentitiesByGraphic(TServer server, ushort graphic)
        {
            try
            {
                return server.GraphicRanges.Where(p => p.Value.Contains(graphic)).OrderBy(p => p.Value.Size()).First().Key;
            }
            catch (Exception e)
            {
                throw new InvalidOperationException($"Unknown identities for graphic ({graphic}) {e}");
            }
        }
    }
}
