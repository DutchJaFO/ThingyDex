using ThingyDexer.Model.General;
using System.Linq;
namespace ThingyDexer.Model.Table
{
    public class CultnameTableSet
    {
        public TextTable DefiniteArticleTable { get; }
        public TextTable AdjectiveTable1 { get; }
        public TextTable NameTable { get; }
        public TextTable AdjectiveTable2 { get; }
        public TextTable SomethingTable { get; }

        public CultnameTableSet(Random randomizer, string[] definiteArticleTableTable, string[] nameTable, string[] adjectiveTable, string[] somethingTable)
        {
#if DEBUG
            var x1 = definiteArticleTableTable.Min(o => o.Length);
            var y1 = definiteArticleTableTable.Max(o => o.Length);

            var x2 = nameTable.Min(o => o.Length);
            var y2 = nameTable.Max(o => o.Length);

            var x3 = adjectiveTable.Min(o => o.Length);
            var y3 = adjectiveTable.Max(o => o.Length);

            var x4 = somethingTable.Min(o => o.Length);
            var y4 = somethingTable.Max(o => o.Length);
#endif
            DefiniteArticleTable = new TextTable(randomizer, "Definite Article", definiteArticleTableTable);

            AdjectiveTable1 = new TextTable(randomizer, "Adjective", adjectiveTable);
            NameTable = new TextTable(randomizer, "Name", nameTable);
            AdjectiveTable2 = new TextTable(randomizer, "Adjective", adjectiveTable);
            SomethingTable = new TextTable(randomizer, "Something", somethingTable);
        }

        public CultnameResult GenerateName(CultnameResult original, bool includeDefiniteArticle, CultnameInputType cultnameInputType)
        {
            return new CultnameResult(
                    (includeDefiniteArticle ? original.DefiniteArticle ?? DefiniteArticleTable.GetRandomItem() : null),
                    (cultnameInputType switch
                    {
                        CultnameInputType.TemplateAdjective2PossessiveNoun2Adjective1Noun1 => original.Adjective1 ?? AdjectiveTable1.GetRandomItem(),

                        CultnameInputType.TemplateAdjective1Noun1OfTheAdjective2Noun2 => original.Adjective1 ?? AdjectiveTable2.GetRandomItem(),
                        CultnameInputType.TemplateAdjective1Noun1OfTheNoun2 => original.Adjective1 ?? AdjectiveTable2.GetRandomItem(),
                        CultnameInputType.TemplateAdjective1Noun1 => original.Adjective1 ?? AdjectiveTable2.GetRandomItem(),

                        CultnameInputType.TemplateAdjective1Adjective2Noun2 => original.Adjective1 ?? AdjectiveTable2.GetRandomItem(),
                        CultnameInputType.Custom => original.Adjective1,
                        _ => null,
                    }),

                    (cultnameInputType switch
                    {
                        CultnameInputType.TemplateAdjective2PossessiveNoun2Adjective1Noun1 => original.Noun1 ?? SomethingTable.GetRandomItem(),

                        CultnameInputType.TemplateNoun1OfTheAdjective2Noun2 => original.Noun1 ?? NameTable.GetRandomItem(),
                        CultnameInputType.TemplateAdjective1Noun1OfTheAdjective2Noun2 => original.Noun1 ?? NameTable.GetRandomItem(),
                        CultnameInputType.TemplateNoun1OfTheNoun2 => original.Noun1 ?? NameTable.GetRandomItem(),
                        CultnameInputType.TemplateAdjective1Noun1OfTheNoun2 => original.Noun1 ?? NameTable.GetRandomItem(),
                        CultnameInputType.TemplateAdjective1Noun1 => original.Noun1 ?? NameTable.GetRandomItem(),

                        CultnameInputType.Custom => original.Noun1,
                        _ => null,
                    }),
                    (cultnameInputType switch
                    {
                        CultnameInputType.TemplateAdjective2PossessiveNoun2Adjective1Noun1 => original.Adjective2 ?? AdjectiveTable2.GetRandomItem(),

                        CultnameInputType.TemplateAdjective2Noun2 => original.Adjective2 ?? AdjectiveTable1.GetRandomItem(),
                        CultnameInputType.TemplateNoun1OfTheAdjective2Noun2 => original.Adjective2 ?? AdjectiveTable1.GetRandomItem(),
                        CultnameInputType.TemplateAdjective1Noun1OfTheAdjective2Noun2 => original.Adjective2 ?? AdjectiveTable1.GetRandomItem(),

                        CultnameInputType.TemplateAdjective1Adjective2Noun2 => original.Adjective2 ?? AdjectiveTable1.GetRandomItem(),
                        CultnameInputType.Custom => original.Adjective2,
                        _ => null,
                    }),
                    (cultnameInputType switch
                    {
                        CultnameInputType.TemplateAdjective2PossessiveNoun2Adjective1Noun1 => original.Noun2 ?? NameTable.GetRandomItem(),

                        CultnameInputType.TemplateAdjective2Noun2 => original.Noun2 ?? SomethingTable.GetRandomItem(),
                        CultnameInputType.TemplateNoun1OfTheAdjective2Noun2 => original.Noun2 ?? SomethingTable.GetRandomItem(),
                        CultnameInputType.TemplateAdjective1Noun1OfTheAdjective2Noun2 => original.Noun2 ?? SomethingTable.GetRandomItem(),
                        CultnameInputType.TemplateNoun1OfTheNoun2 => original.Noun2 ?? SomethingTable.GetRandomItem(),
                        CultnameInputType.TemplateAdjective1Noun1OfTheNoun2 => original.Noun2 ?? SomethingTable.GetRandomItem(),

                        CultnameInputType.TemplateAdjective1Adjective2Noun2 => original.Noun2 ?? SomethingTable.GetRandomItem(),

                        CultnameInputType.Custom => original.Noun2,
                        _ => null,
                    })
                    , cultnameInputType
                   );
        }
    }
}
