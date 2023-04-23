namespace ThingyDexer.Model.Cult
{
    public enum StatBlockType
    {
        Strength,
        Dexterity,
        Intelligence,
        Defense
    }

    public static class EnumExtensions
    {
        public static List<T> GetEnumList<T>()
        {
            T[] array = (T[])Enum.GetValues(typeof(T));
            List<T> list = new(array);
            return list;
        }

    }
}
