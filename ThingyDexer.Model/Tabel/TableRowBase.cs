﻿namespace ThingyDexer.Model.Tabel
{
    public class TableRowBase<T>
    {
        public int Index { get; set; }
        public T? Value { get; set; }

        public static TableRowBase<T> Empty => new() { Index = -1 };

        public Table<T> Owner { get; internal set; }

        public override int GetHashCode()
        {
            return Index.GetHashCode();
        }

        public override bool Equals(object? obj)
        {
            if (obj is TableRowBase<T>)
            {
                return Index.Equals(((TableRowBase<T>)obj).Index);
            }
            else
            {
                return Index.Equals(-1);
            }
        }
    }
}
