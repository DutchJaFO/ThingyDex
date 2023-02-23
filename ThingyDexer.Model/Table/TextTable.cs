namespace ThingyDexer.Model.Table
{
    public class TextTable : Table<string>
    {
        public TextTable(Random random, string? name = null, IEnumerable<string>? data = null) : base(random, name, data)
        {
        }
    }
}
