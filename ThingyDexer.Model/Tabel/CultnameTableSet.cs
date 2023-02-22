namespace ThingyDexer.Model.Tabel
{
    public class CultnameTableSet
    {
        private static Random _Randomizer = new Random();
        private TextTable _Tabel1;
        private TextTable _PrefixTabel;
        private TextTable _Tabel3;

        public CultnameTableSet(string[] tabel1, string[] tabel2, string[] tabel3)
        {
            _Tabel1 = new TextTable(_Randomizer); _Tabel1.Add(tabel1);
            _PrefixTabel = new TextTable(_Randomizer); _PrefixTabel.Add(tabel2);
            _Tabel3 = new TextTable(_Randomizer); _Tabel3.Add(tabel3);
        }

        public (bool Spiffy, TableRowBase<string>[] Data) GetValueSet(bool spiffy)
        {
            List<TableRowBase<string>> results = new();
            if (spiffy)
            {
                TableRowBase<string> v0 = _PrefixTabel.GetRandomItem();
                results.Add(v0);
            }

            TableRowBase<string> v1 = _Tabel1.GetRandomItem();
            results.Add(v1);

            TableRowBase<string> v2 = _PrefixTabel.GetRandomItem();
            results.Add(v2);

            TableRowBase<string> v3 = _Tabel3.GetRandomItem();
            results.Add(v3);

            return (spiffy, results.ToArray());
        }
    }
}
