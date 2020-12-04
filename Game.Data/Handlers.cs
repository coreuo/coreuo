using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Game.Data.Domain;
using Ultima.Package;

namespace Game.Data
{
    public static class Handlers<TSettings, TItem, TEntity, TTileArt, TCsvDocument>
        where TSettings : ISettings<TTileArt, TCsvDocument>
        where TItem : TEntity, IItem
        where TEntity : IEntity
        where TTileArt : ITileArt, new()
        where TCsvDocument : ICsvDocument, new()
    {
        private const string Dictionary = "string_dictionary.uop";

        //public const string Localization = "LocalizedStrings.uop";

        private const string TileArt = "tileart.uop";

        private const string GameData = "GameData.uop";

        public static void Load(TSettings settings)
        {
            if (!Directory.Exists(settings.GamePath))
            {
                Console.WriteLine("Please type Ultima Online Kingdom Reborn folder path:");

                settings.GamePath = Console.ReadLine();
            }

            LoadStringData(settings);

            LoadTileArts(settings);

            LoadCsvDocuments(settings);

            LoadHues(settings);

            LoadElfHues(settings);

            LoadFaces(settings);

            LoadHumanMaleHair(settings);

            LoadElfMaleHair(settings);

            LoadHumanFemaleHairGraphics(settings);

            LoadElfFemaleHairGraphics(settings);

            LoadElfHairHues(settings);

            LoadHumanMaleBeardGraphics(settings);

            LoadHumanMalePantsGraphics(settings);

            LoadElfMalePantsGraphics(settings);

            LoadHumanFemalePantsGraphics(settings);

            LoadElfFemalePantsGraphics(settings);

            LoadHumanMaleShirtGraphics(settings);

            LoadElfMaleShirtGraphics(settings);

            LoadHumanFemaleShirtGraphics(settings);

            LoadElfFemaleShirtGraphics(settings);

            LoadHumanMaleShoesGraphics(settings);

            LoadElfMaleShoesGraphics(settings);

            LoadHumanFemaleShoesGraphics(settings);

            LoadElfFemaleShoesGraphics(settings);

            LoadHumanMaleProfessionItems(settings);

            LoadHumanFemaleProfessionItems(settings);

            LoadElfMaleProfessionItems(settings);

            LoadElfFemaleProfessionItems(settings);
        }

        private static void LoadStringData(TSettings settings)
        {
            var path = Path.Combine(settings.GamePath, Dictionary);

            using var packageStream = File.OpenRead(path);

            using var packageReader = new BinaryReader(packageStream);

            var package = UltimaPackage.FromReader(packageReader);

            var file = package.GetBlocks(packageReader).Single().GetFiles(packageReader).Single();

            file.GetData(packageReader, (reader, total) =>
            {
                reader.ReadBytes(0x10);

                var current = 0x10;

                while (current < total)
                {
                    var length = reader.ReadInt16();

                    var bytes = reader.ReadBytes(length);

                    var name = System.Text.Encoding.ASCII.GetString(bytes).Split('%').First();

                    settings.StringData.Add(name);

                    current += 2 + length;
                }
            });
        }

        /*public static void LoadCliLoc(TSettings settings)
        {
            var localization = new Dictionary<uint, string>();

            var path = Path.Combine(settings.GamePath, Localization);

            var package = new MythicPackage(path);

            var file = package.Blocks.Single().Files.First();

            var bytes = file.Unpack(path);

            using var stream = new MemoryStream(bytes);

            using var reader = new BinaryReader(stream);

            stream.Seek(0x6, SeekOrigin.Begin);

            while (stream.Position < stream.Length)
            {
                var key = reader.ReadUInt32();

                stream.Seek(1, SeekOrigin.Current);

                var length = reader.ReadUInt16();

                bytes = reader.ReadBytes(length);

                var text = System.Text.Encoding.UTF8.GetString(bytes);

                localization.Add(key, text);
            }
        }*/

        private static void LoadTileArts(TSettings settings)
        {
            var path = Path.Combine(settings.GamePath, TileArt);

            using var packageStream = File.OpenRead(path);

            using var packageReader = new BinaryReader(packageStream);

            var package = UltimaPackage.FromReader(packageReader);

            var buffer = new byte[100];

            foreach (var file in package.GetBlocks(packageReader).SelectMany(b => b.GetFiles(packageReader)))
            {
                file.GetData(packageReader, (reader, total) =>
                {
                    reader.ReadInt16();

                    var index = reader.ReadInt32();

                    var name = settings.StringData[index > 0 ? index - 1 : 0];

                    var id = reader.ReadUInt16();

                    reader.BaseStream.Read(buffer, 0, 51);

                    var flags = reader.ReadUInt64();

                    reader.BaseStream.Read(buffer, 0, 48);

                    var count = reader.ReadByte();

                    var properties = new Dictionary<byte, int>();

                    for (var i = 0; i < count; i++) properties[reader.ReadByte()] = reader.ReadInt32();

                    if (!properties.TryGetValue(0, out var weight)) weight = 0;

                    if (!properties.TryGetValue(3, out var height)) height = 0;

                    if (!properties.TryGetValue(6, out var layer)) layer = 0;

                    settings.TileArts.Add(id, new TTileArt
                    {
                        Graphic = id,
                        Name = name,
                        Flags = flags,
                        Weight = (ushort)weight,
                        Height = height,
                        Layer = (byte)layer
                    });
                });
            }
        }

        private static void LoadCsvDocuments(TSettings settings)
        {
            settings.CsvDocuments.Clear();

            var path = Path.Combine(settings.GamePath, GameData);

            using var packageStream = File.OpenRead(path);

            using var packageReader = new BinaryReader(packageStream);

            var package = UltimaPackage.FromReader(packageReader);

            var buffer = new byte[100];

            foreach (var file in package.GetBlocks(packageReader).SelectMany(b => b.GetFiles(packageReader)))
            {
                file.GetData(packageReader, (reader, total) =>
                {
                    using var text = new StreamReader(reader.BaseStream, leaveOpen: true);

                    var lines = new List<string>();

                    string line;

                    while ((line = text.ReadLine()) != null)
                    {
                        if (line.StartsWith('#')) continue;

                        lines.Add(line);
                    }

                    settings.CsvDocuments.Add(file.FileNameHash, new TCsvDocument
                    {
                        Header = lines.First().Split(','),
                        Data = lines
                            .Skip(1)
                            .Select(l => l.Split(','))
                            .SelectMany(inner => inner.Select((item, index) => new {item, index}))
                            .GroupBy(i => i.index, i => i.item)
                            .Select(g => g.ToArray())
                            .ToArray()
                    });
                });
            }
        }

        private static void LoadHues(TSettings settings)
        {
            var document = settings.CsvDocuments[0xED655AFED0933BC4];

            settings.AddHumanHues((Convert.ToInt32(document.Data[3][0])+1)..(Convert.ToInt32(document.Data[4][0])+1));

            settings.AddHumanHairHues((Convert.ToInt32(document.Data[3][1])+1)..(Convert.ToInt32(document.Data[4][1])+1));

            settings.AddHumanBeardHues((Convert.ToInt32(document.Data[3][2])+1)..(Convert.ToInt32(document.Data[4][2])+1));

            settings.AddDyeHues((Convert.ToInt32(document.Data[3][3])+1)..(Convert.ToInt32(document.Data[4][3])+1));

            settings.AddShirtHues((Convert.ToInt32(document.Data[3][4])+1)..(Convert.ToInt32(document.Data[4][4])+1));

            settings.AddPantsHues((Convert.ToInt32(document.Data[3][5])+1)..(Convert.ToInt32(document.Data[4][5])+1));
        }

        private static void LoadElfHues(TSettings settings)
        {
            var document = settings.CsvDocuments[0xFA29615391D62F63];

            settings.AddElfHues(document.Data[1].Select(v => Convert.ToUInt16(v)).ToArray());
        }

        private static void LoadFaces(TSettings settings)
        {
            var document = settings.CsvDocuments[0xF36ECB903D5EC04E];

            settings.AddHumanoidFaceGraphics(document.Data[2][..9].Select(v => Convert.ToUInt16(v)));
        }

        private static void LoadHumanMaleHair(TSettings settings)
        {
            var document = settings.CsvDocuments[0x74B00C0C52382BB2];

            settings.AddHumanMaleHairGraphics(document.Data[2][1..].Select(v => Convert.ToUInt16(v)));
        }

        private static void LoadElfMaleHair(TSettings settings)
        {
            var document = settings.CsvDocuments[0xBEEED1C2CD0D6801];

            settings.AddElfMaleHairGraphics(document.Data[2][1..].Select(v => Convert.ToUInt16(v)));
        }

        private static void LoadHumanFemaleHairGraphics(TSettings settings)
        {
            var document = settings.CsvDocuments[0xDD2653293F0018BA];

            settings.AddHumanFemaleHairGraphics(document.Data[2][1..].Select(v => Convert.ToUInt16(v)));
        }

        private static void LoadElfFemaleHairGraphics(TSettings settings)
        {
            var document = settings.CsvDocuments[0x4C92BF1F4B6629E0];

            settings.AddElfFemaleHairGraphics(document.Data[2][1..].Select(v => Convert.ToUInt16(v)));
        }

        private static void LoadElfHairHues(TSettings settings)
        {
            var document = settings.CsvDocuments[0x0806C252C9898CDF];

            settings.AddElfHairHues(document.Data[1].Select(v => Convert.ToUInt16(v)));
        }

        private static void LoadHumanMaleBeardGraphics(TSettings settings)
        {
            var document = settings.CsvDocuments[0x0459535D0270E904];

            settings.AddHumanMaleBeardGraphics(document.Data[2][1..].Select(v => Convert.ToUInt16(v)));
        }

        private static void LoadHumanMalePantsGraphics(TSettings settings)
        {
            var document = settings.CsvDocuments[0x5A1D07F68E1CD067];

            settings.AddHumanMalePantsGraphics(document.Data[1].Select(v => Convert.ToUInt16(v)));
        }

        private static void LoadElfMalePantsGraphics(TSettings settings)
        {
            var document = settings.CsvDocuments[0xAE9EC6FA1F1AED55];

            settings.AddElfMalePantsGraphics(document.Data[1].Select(v => Convert.ToUInt16(v)));
        }

        private static void LoadHumanFemalePantsGraphics(TSettings settings)
        {
            var document = settings.CsvDocuments[0xE98FB5381AAED0FA];

            settings.AddHumanFemalePantsGraphics(document.Data[1].Select(v => Convert.ToUInt16(v)));
        }

        private static void LoadElfFemalePantsGraphics(TSettings settings)
        {
            var document = settings.CsvDocuments[0x988465C6F4AB8A49];

            settings.AddElfFemalePantsGraphics(document.Data[1].Select(v => Convert.ToUInt16(v)));
        }

        private static void LoadHumanMaleShirtGraphics(TSettings settings)
        {
            var document = settings.CsvDocuments[0x27EAE22471E57A6E];

            settings.AddHumanMaleShirtGraphics(document.Data[1].Select(v => Convert.ToUInt16(v)));
        }

        private static void LoadElfMaleShirtGraphics(TSettings settings)
        {
            var document = settings.CsvDocuments[0xE57BE805D285631A];

            settings.AddElfMaleShirtGraphics(document.Data[1].Select(v => Convert.ToUInt16(v)));
        }

        private static void LoadHumanFemaleShirtGraphics(TSettings settings)
        {
            var document = settings.CsvDocuments[0x03319EEA8FA3089B];

            settings.AddHumanFemaleShirtGraphics(document.Data[1].Select(v => Convert.ToUInt16(v)));
        }

        private static void LoadElfFemaleShirtGraphics(TSettings settings)
        {
            var document = settings.CsvDocuments[0x8A256741EC070BF9];

            settings.AddElfFemaleShirtGraphics(document.Data[1].Select(v => Convert.ToUInt16(v)));
        }

        private static void LoadHumanMaleShoesGraphics(TSettings settings)
        {
            var document = settings.CsvDocuments[0xD1CBE01C5B2C4AFA];

            settings.AddHumanMaleShoesGraphics(document.Data[1].Select(v => Convert.ToUInt16(v)));
        }

        private static void LoadElfMaleShoesGraphics(TSettings settings)
        {
            var document = settings.CsvDocuments[0x2ABAF70B2C4E4342];

            settings.AddElfMaleShoesGraphics(document.Data[1].Select(v => Convert.ToUInt16(v)));
        }

        private static void LoadHumanFemaleShoesGraphics(TSettings settings)
        {
            var document = settings.CsvDocuments[0xA3AD8DFD783D393A];

            settings.AddHumanFemaleShoesGraphics(document.Data[1].Select(v => Convert.ToUInt16(v)));
        }

        private static void LoadElfFemaleShoesGraphics(TSettings settings)
        {
            var document = settings.CsvDocuments[0x3C43AEE43E0626A8];

            settings.AddElfFemaleShoesGraphics(document.Data[1].Select(v => Convert.ToUInt16(v)));
        }

        private static void LoadHumanMaleProfessionItems(TSettings settings)
        {
            var document = settings.CsvDocuments[0x72587BA3107BA0B6];

            for (var i = 0; i < document.Data[0].Length; i++)
            {
                sbyte id = string.IsNullOrEmpty(document.Data[2][i]) ? 0 : Convert.ToSByte(document.Data[2][i]);

                if(id == 0) continue;

                settings.AddHumanMaleProfessionItems(id, document.Data.Skip(3).Select(d => string.IsNullOrEmpty(d[i]) ? (ushort)0 : Convert.ToUInt16(d[i])).ToList());
            }
        }

        private static void LoadHumanFemaleProfessionItems(TSettings settings)
        {
            var document = settings.CsvDocuments[0x947FEEDB39E641C3];

            for (var i = 0; i < document.Data[0].Length; i++)
            {
                sbyte id = string.IsNullOrEmpty(document.Data[2][i]) ? 0 : Convert.ToSByte(document.Data[2][i]);

                if (id == 0) continue;

                settings.AddHumanFemaleProfessionItems(id, document.Data.Skip(3).Select(d => string.IsNullOrEmpty(d[i]) ? (ushort)0 : Convert.ToUInt16(d[i])).ToList());
            }
        }

        private static void LoadElfMaleProfessionItems(TSettings settings)
        {
            var document = settings.CsvDocuments[0xA2E3E341D0829A73];

            for (var i = 0; i < document.Data[0].Length; i++)
            {
                sbyte id = string.IsNullOrEmpty(document.Data[2][i]) ? 0 : Convert.ToSByte(document.Data[2][i]);

                if (id == 0) continue;

                settings.AddElfMaleProfessionItems(id, document.Data.Skip(3).Select(d => string.IsNullOrEmpty(d[i]) ? (ushort)0 : Convert.ToUInt16(d[i])).ToList());
            }
        }

        private static void LoadElfFemaleProfessionItems(TSettings settings)
        {
            var document = settings.CsvDocuments[0x241C57F10355D74D];

            for (var i = 0; i < document.Data[0].Length; i++)
            {
                sbyte id = string.IsNullOrEmpty(document.Data[2][i]) ? 0 : Convert.ToSByte(document.Data[2][i]);

                if (id == 0) continue;

                settings.AddElfFemaleProfessionItems(id, document.Data.Skip(3).Select(d => string.IsNullOrEmpty(d[i]) ? (ushort)0 : Convert.ToUInt16(d[i])).ToList());
            }
        }

        public static void AssignName(TSettings settings, TEntity entity, string name)
        {
            if (name != null) entity.Name = name;
            else if (entity is TItem) entity.Name = settings.TileArts[entity.Graphic].Name;
            else entity.Name = "Unknown";
        }

        public static void AssignLayer(TSettings settings, TItem item)
        {
            item.Layer = settings.TileArts[item.Graphic].Layer;
        }

        public static void AssignDisplay(TSettings settings, TItem item)
        {
            item.Display = Convert.ToUInt16(settings.CsvDocuments[0x774C195310B57E54].Data[1][item.DisplayIndex]);
        }
    }
}
