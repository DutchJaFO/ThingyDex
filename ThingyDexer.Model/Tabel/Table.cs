namespace ThingyDexer.Model.Tabel
{

    public class Table<T>
    {
        private readonly Random _Randomizer;
        private readonly List<TableRowBase<T>> _list = new();

        private int minValue = int.MinValue;
        private int maxValue = int.MaxValue;

        public int Count => _list.Count;

        public void Add(int index, T value)
        {
            _list.Add(new TableRowBase<T>() { Index = index, Value = value });
        }

        public void Add(IEnumerable<T> data)
        {
            int i = 0;
            foreach ((int index, T waarde) in data.Select(o => (index: ++i, waarde: o)))
            {
                Add(index, waarde);
            }
            minValue = _list.Select(o => o.Index).Min();
            maxValue = _list.Select(o => o.Index).Max();
        }

        public TableRowBase<T> GetRow(int index)
        {
            TableRowBase<T>? item = _list.FirstOrDefault(o => o.Index == index);
            if (item != null)
                return item;
            else
                throw new ArgumentOutOfRangeException(nameof(index));
        }

        public T? Get(int index)
        {
            TableRowBase<T> item = GetRow(index);
            return item.Value;
        }

        public TableRowBase<T> GetRandomItem()
        {
            int d = _Randomizer.Next(minValue, maxValue);
            return GetRow(d);
        }

        public T? GetRandom()
        {
            TableRowBase<T> item = GetRandomItem();
            return item.Value;
        }
        public Table(Random random)
        {
            _Randomizer = random;
        }
    }
}
