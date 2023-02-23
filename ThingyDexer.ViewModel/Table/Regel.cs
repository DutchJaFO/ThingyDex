using ThingyDexer.Model.Table;

namespace ThingyDexer.ViewModel.Table
{
    public class Regel<T>
    {
        public Table<T>? Source { get; set; }
        public string Table => Source?.Name ?? string.Empty;
        public int Id { get; set; }
        public T? Name { get; set; }
    }

    public class RegelString : Regel<string>
    {
    }

    public class SelectableRegelString : RegelString
    {
        public bool Selected { get; set; }
    }
}
