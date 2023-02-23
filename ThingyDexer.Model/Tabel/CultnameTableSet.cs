namespace ThingyDexer.Model.Tabel
{
    public class CultnameTableSet
    {
        private static Random _Randomizer = new();
        public TextTable NameTable { get; }
        public TextTable PrefixTable { get; }
        public TextTable SomethingTable { get; }

        public CultnameTableSet(string[] nameTable, string[] prefixTable, string[] somethingTable)
        {
            NameTable = new TextTable(_Randomizer, "Name", nameTable);
            PrefixTable = new TextTable(_Randomizer, "Prefix", prefixTable);
            SomethingTable = new TextTable(_Randomizer, "Something", somethingTable);
        }

        public (bool Spiffy, TableRowBase<string>[] Data) GetValueSet(bool spiffy)
        {
            List<TableRowBase<string>> results = new();
            if (spiffy)
            {
                TableRowBase<string> v0 = PrefixTable.GetRandomItem();
                results.Add(v0);
            }

            TableRowBase<string> v1 = NameTable.GetRandomItem();
            results.Add(v1);

            TableRowBase<string> v2 = PrefixTable.GetRandomItem();
            results.Add(v2);

            TableRowBase<string> v3 = SomethingTable.GetRandomItem();
            results.Add(v3);

            return (spiffy, results.ToArray());
        }
    }
}
