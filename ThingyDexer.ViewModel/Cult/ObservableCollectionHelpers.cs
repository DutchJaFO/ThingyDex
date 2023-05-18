using System.Collections.ObjectModel;

namespace ThingyDexer.ViewModel.Cult
{
    public static class ObservableCollectionHelpers
    {
        public static void Sort<T>(this ObservableCollection<T> collection, Comparison<T> comparison)
        {
            var sortableList = new List<T>(collection);
            sortableList.Sort(comparison);

            for (int i = 0; i < sortableList.Count; i++)
            {
                collection.Move(collection.IndexOf(sortableList[i]), i);
            }
        }
        public static void AddRange<T>(this ObservableCollection<T> collection, IEnumerable<T> items)
        {
            items.ToList().ForEach(collection.Add);
        }

        public static void RemoveRange<T>(this ObservableCollection<T> collection, IEnumerable<T> items)
        {
            var set = items.ToArray();
            foreach (var item in set)
            {
                collection.Remove(item);
            }
        }
    }
}
