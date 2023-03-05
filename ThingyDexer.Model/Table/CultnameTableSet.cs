using System.Xml.Linq;
using ThingyDexer.Model.General;

namespace ThingyDexer.Model.Table
{
    public class CultnameTableSet
    {
        private static Random _Randomizer = new();
        public TextTable PrefixNameTable { get; }
        public TextTable NameTable { get; }
        public TextTable PrefixTable { get; }
        public TextTable SomethingTable { get; }

        public CultnameTableSet(string[] nameTable, string[] prefixTable, string[] somethingTable)
        {
            PrefixNameTable = new TextTable(_Randomizer, "Prefix", prefixTable);
            NameTable = new TextTable(_Randomizer, "Name", nameTable);
            PrefixTable = new TextTable(_Randomizer, "Prefix", prefixTable);
            SomethingTable = new TextTable(_Randomizer, "Something", somethingTable);
        }

        public (TableRowBase<string>? PrefixName, TableRowBase<string>? Name, TableRowBase<string>? PrefixSomething, TableRowBase<string>? Something) GenerateName(TableRowBase<string>? p1, TableRowBase<string>? n1, TableRowBase<string>? p2, TableRowBase<string>? n2, CultnameInputType cultnameInputType)
        {
            return (
                    (cultnameInputType switch
                    {
                        CultnameInputType.TemplatePrefixNounOfTheAdjectiveNoun => p1 ?? PrefixTable.GetRandomItem(),
                        CultnameInputType.TemplatePrefixNounOfTheNoun => p1 ?? PrefixTable.GetRandomItem(),
                        CultnameInputType.TemplatePrefixNoun => p1 ?? PrefixTable.GetRandomItem(),

                        CultnameInputType.TemplatePrefixAdjectiveNoun => p1 ?? PrefixTable.GetRandomItem(),
                        CultnameInputType.Custom => p1,
                        _ => null,
                    }),
                    (cultnameInputType switch
                    {
                        CultnameInputType.TemplateNounOfTheAdjectiveNoun => n1 ?? NameTable.GetRandomItem(),
                        CultnameInputType.TemplatePrefixNounOfTheAdjectiveNoun => n1 ?? NameTable.GetRandomItem(),
                        CultnameInputType.TemplateNounOfTheNoun => n1 ?? NameTable.GetRandomItem(),
                        CultnameInputType.TemplatePrefixNounOfTheNoun => n1 ?? NameTable.GetRandomItem(),
                        CultnameInputType.TemplatePrefixNoun => n1 ?? NameTable.GetRandomItem(),

                        CultnameInputType.Custom => n1,
                        _ => null,
                    }),
                    (cultnameInputType switch
                    {
                        CultnameInputType.TemplateAdjectiveNoun => p2 ?? PrefixNameTable.GetRandomItem(),
                        CultnameInputType.TemplateNounOfTheAdjectiveNoun => p2 ?? PrefixNameTable.GetRandomItem(),
                        CultnameInputType.TemplatePrefixNounOfTheAdjectiveNoun => p2 ?? PrefixNameTable.GetRandomItem(),

                        CultnameInputType.TemplatePrefixAdjectiveNoun => p2 ?? PrefixNameTable.GetRandomItem(),
                        CultnameInputType.Custom => p2,
                        _ => null,
                    }),
                    (cultnameInputType switch
                    {
                        CultnameInputType.TemplateAdjectiveNoun => n2 ?? SomethingTable.GetRandomItem(),
                        CultnameInputType.TemplateNounOfTheAdjectiveNoun => n2 ?? SomethingTable.GetRandomItem(),
                        CultnameInputType.TemplatePrefixNounOfTheAdjectiveNoun => n2 ?? SomethingTable.GetRandomItem(),
                        CultnameInputType.TemplateNounOfTheNoun => n2 ?? SomethingTable.GetRandomItem(),
                        CultnameInputType.TemplatePrefixNounOfTheNoun => n2 ?? SomethingTable.GetRandomItem(),

                        CultnameInputType.TemplatePrefixAdjectiveNoun => n2 ?? SomethingTable.GetRandomItem(),

                        CultnameInputType.Custom => n2,
                        _ => null,
                    })
                   );
        }
    }
}
