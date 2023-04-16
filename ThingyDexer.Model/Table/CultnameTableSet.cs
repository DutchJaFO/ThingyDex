using ThingyDexer.Model.General;

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
            DefiniteArticleTable = new TextTable(randomizer, "Definite Article", definiteArticleTableTable);

            AdjectiveTable1 = new TextTable(randomizer, "Adjective", adjectiveTable);
            NameTable = new TextTable(randomizer, "Name", nameTable);
            AdjectiveTable2 = new TextTable(randomizer, "Adjective", adjectiveTable);
            SomethingTable = new TextTable(randomizer, "Something", somethingTable);
        }

        public (TableRowBase<string>? DefiniteArticle, TableRowBase<string>? Adjective1, TableRowBase<string>? Noun1, TableRowBase<string>? Adjective2, TableRowBase<string>? Noun2) GenerateName(TableRowBase<string>? da, TableRowBase<string>? p1, TableRowBase<string>? n1, TableRowBase<string>? p2, TableRowBase<string>? n2, bool includeDefiniteArticle, CultnameInputType cultnameInputType)
        {
            return (
                    (includeDefiniteArticle ? DefiniteArticleTable.GetRandomItem() : null),
                    (cultnameInputType switch
                    {
                        CultnameInputType.TemplateAdjective2PossessiveNoun2Adjective1Noun1 => p1 ?? AdjectiveTable1.GetRandomItem(),

                        CultnameInputType.TemplateAdjective1Noun1OfTheAdjective2Noun2 => p1 ?? AdjectiveTable2.GetRandomItem(),
                        CultnameInputType.TemplateAdjective1Noun1OfTheNoun2 => p1 ?? AdjectiveTable2.GetRandomItem(),
                        CultnameInputType.TemplateAdjective1Noun1 => p1 ?? AdjectiveTable2.GetRandomItem(),

                        CultnameInputType.TemplateAdjective1Adjective2Noun2 => p1 ?? AdjectiveTable2.GetRandomItem(),
                        CultnameInputType.Custom => p1,
                        _ => null,
                    }),

                    (cultnameInputType switch
                    {
                        CultnameInputType.TemplateAdjective2PossessiveNoun2Adjective1Noun1 => n1 ?? SomethingTable.GetRandomItem(),

                        CultnameInputType.TemplateNoun1OfTheAdjective2Noun2 => n1 ?? NameTable.GetRandomItem(),
                        CultnameInputType.TemplateAdjective1Noun1OfTheAdjective2Noun2 => n1 ?? NameTable.GetRandomItem(),
                        CultnameInputType.TemplateNoun1OfTheNoun2 => n1 ?? NameTable.GetRandomItem(),
                        CultnameInputType.TemplateAdjective1Noun1OfTheNoun2 => n1 ?? NameTable.GetRandomItem(),
                        CultnameInputType.TemplateAdjective1Noun1 => n1 ?? NameTable.GetRandomItem(),

                        CultnameInputType.Custom => n1,
                        _ => null,
                    }),
                    (cultnameInputType switch
                    {
                        CultnameInputType.TemplateAdjective2PossessiveNoun2Adjective1Noun1 => p2 ?? AdjectiveTable2.GetRandomItem(),

                        CultnameInputType.TemplateAdjective2Noun2 => p2 ?? AdjectiveTable1.GetRandomItem(),
                        CultnameInputType.TemplateNoun1OfTheAdjective2Noun2 => p2 ?? AdjectiveTable1.GetRandomItem(),
                        CultnameInputType.TemplateAdjective1Noun1OfTheAdjective2Noun2 => p2 ?? AdjectiveTable1.GetRandomItem(),

                        CultnameInputType.TemplateAdjective1Adjective2Noun2 => p2 ?? AdjectiveTable1.GetRandomItem(),
                        CultnameInputType.Custom => p2,
                        _ => null,
                    }),
                    (cultnameInputType switch
                    {
                        CultnameInputType.TemplateAdjective2PossessiveNoun2Adjective1Noun1 => n2 ?? NameTable.GetRandomItem(),

                        CultnameInputType.TemplateAdjective2Noun2 => n2 ?? SomethingTable.GetRandomItem(),
                        CultnameInputType.TemplateNoun1OfTheAdjective2Noun2 => n2 ?? SomethingTable.GetRandomItem(),
                        CultnameInputType.TemplateAdjective1Noun1OfTheAdjective2Noun2 => n2 ?? SomethingTable.GetRandomItem(),
                        CultnameInputType.TemplateNoun1OfTheNoun2 => n2 ?? SomethingTable.GetRandomItem(),
                        CultnameInputType.TemplateAdjective1Noun1OfTheNoun2 => n2 ?? SomethingTable.GetRandomItem(),

                        CultnameInputType.TemplateAdjective1Adjective2Noun2 => n2 ?? SomethingTable.GetRandomItem(),

                        CultnameInputType.Custom => n2,
                        _ => null,
                    })
                   );
        }
    }
}
