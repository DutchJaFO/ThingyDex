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

        public string GetValue(bool spiffy)
        {
            if (spiffy)
            {
                string? v0 = _PrefixTabel.GetRandom();
                string? v1 = _Tabel1.GetRandom();
                string? v2 = _PrefixTabel.GetRandom();
                string? v3 = _Tabel3.GetRandom();

                return $"{v0} {v1} of the {v2} {v3}";
            }
            else
            {
                string? v1 = _Tabel1.GetRandom();
                string? v2 = _PrefixTabel.GetRandom();
                string? v3 = _Tabel3.GetRandom();
                return $"{v1} of the {v2} {v3}";
            }
        }
    }
}
