namespace ThingyDexer.Model.Table
{
    public class TableRowBase<T>
    {
        public int Index { get; set; }
        public T? Value { get; set; }

        public static TableRowBase<T> Empty => new() { Index = -1 };

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public Table<T> Owner { get; internal set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public override int GetHashCode()
        {
            return Index.GetHashCode();
        }

        public override bool Equals(object? obj)
        {
            return (obj is TableRowBase<T> target) 
                && Index.Equals(target.Index) 
                && (Owner.Key == target.Owner.Key)
;
        }
    }
}
