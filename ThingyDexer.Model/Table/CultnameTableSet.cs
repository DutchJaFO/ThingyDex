using System.Xml.Linq;

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

        public (TableRowBase<string>? PrefixName, TableRowBase<string>? Name, TableRowBase<string>? PrefixSomething, TableRowBase<string>? Something) GenerateName(bool spiffy)
        {
            return (
                    (spiffy ? PrefixTable.GetRandomItem() : null),
                    NameTable.GetRandomItem(),
                    PrefixNameTable.GetRandomItem(),
                    SomethingTable.GetRandomItem()
                   );
        }
    }
}
