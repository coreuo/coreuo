using System;
using System.Collections.Generic;

namespace Game.Data.Domain
{
    public interface ISettings<TTileArt, TCsvDocument>
        where TTileArt : ITileArt
        where TCsvDocument : ICsvDocument
    {
        string GamePath { get; }

        List<string> StringData { get; }

        Dictionary<ushort, TTileArt> TileArts { get; }

        Dictionary<ulong, TCsvDocument> CsvDocuments { get; }

        void AddHumanHues(Range range);

        void AddElfHues(ushort[] values);

        void AddHumanoidFaceGraphics(IEnumerable<ushort> values);

        void AddHumanMaleHairGraphics(IEnumerable<ushort> values);

        void AddElfMaleHairGraphics(IEnumerable<ushort> values);

        void AddHumanFemaleHairGraphics(IEnumerable<ushort> values);

        void AddElfFemaleHairGraphics(IEnumerable<ushort> values);

        void AddHumanHairHues(Range range);

        void AddElfHairHues(IEnumerable<ushort> values);

        void AddHumanMaleBeardGraphics(IEnumerable<ushort> values);

        void AddHumanBeardHues(Range range);

        void AddDyeHues(Range range);

        void AddHumanMalePantsGraphics(IEnumerable<ushort> values);

        void AddElfMalePantsGraphics(IEnumerable<ushort> values);

        void AddHumanFemalePantsGraphics(IEnumerable<ushort> values);

        void AddElfFemalePantsGraphics(IEnumerable<ushort> values);

        void AddPantsHues(Range range);

        void AddHumanMaleShirtGraphics(IEnumerable<ushort> values);

        void AddElfMaleShirtGraphics(IEnumerable<ushort> values);

        void AddHumanFemaleShirtGraphics(IEnumerable<ushort> values);

        void AddElfFemaleShirtGraphics(IEnumerable<ushort> values);

        void AddShirtHues(Range range);

        void AddHumanMaleShoesGraphics(IEnumerable<ushort> values);

        void AddElfMaleShoesGraphics(IEnumerable<ushort> values);

        void AddHumanFemaleShoesGraphics(IEnumerable<ushort> values);

        void AddElfFemaleShoesGraphics(IEnumerable<ushort> values);

        void AddHumanMaleProfessionItems(sbyte id, IReadOnlyList<ushort> values);

        void AddHumanFemaleProfessionItems(sbyte id, IReadOnlyList<ushort> values);

        void AddElfMaleProfessionItems(sbyte id, IReadOnlyList<ushort> values);

        void AddElfFemaleProfessionItems(sbyte id, IReadOnlyList<ushort> values);
    }
}
