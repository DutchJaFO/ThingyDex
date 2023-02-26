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

        public override bool Equals(object? obj)
        {
            if (obj == null)
            {
                return false;
            }
            else
            {
                RegelString target = (RegelString)obj;
                return (target.Source?.Key == Source?.Key) && (target.Id == Id);

            }
        }

        public override int GetHashCode()
        {
            if (Source != null)
            {
                return Id.GetHashCode() ^ Source.Key.GetHashCode();
            }
            else
            {
                return Id.GetHashCode();
            }
        }
    }

    public class SelectableRegelString : RegelString
    {
        public bool Selected { get; set; }
    }
}
