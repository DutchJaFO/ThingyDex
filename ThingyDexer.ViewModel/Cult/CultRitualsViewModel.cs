using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
namespace ThingyDexer.ViewModel.Cult
{
    public class CultRitualsViewModel : ViewModelBase, IDisposable
    {
        public CultRitualsViewModel()
        {
            AvailabelCultRituals = new ObservableCollection<CultRitualViewModel>(GetAvaliableCultRituals());

            Rituals.CollectionChanged += Rituals_CollectionChanged;
        }

        private void Rituals_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                CultRitualViewModel[] newItems = (e.NewItems?.Cast<CultRitualViewModel>() ?? new List<CultRitualViewModel>()).ToArray();
                RitualsCount += newItems.Length;
            }
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {
                CultRitualViewModel[] removedItems = (e.OldItems?.Cast<CultRitualViewModel>() ?? new List<CultRitualViewModel>()).ToArray();
                RitualsCount -= removedItems.Length;
            }
        }

        private static IEnumerable<CultRitualViewModel> GetAvaliableCultRituals()
        {
            List<CultRitualViewModel> rituals = new();

            for (int i = 1; i <= 40; i++)
            {
                var item = CultRitualViewModel.Create();
                {
                    item.Name = $"Ritual {i:d2}";
                    item.Description = $"Test ritual {i}"; item.Passive = false; item.RitualPoints = i * 10;
                    rituals.Add(item);
                }
            }
            return rituals;
        }

        public ObservableCollection<CultRitualViewModel> AvailabelCultRituals { get; }
        public IEnumerable<CultRitualViewModel> SelectedSource => AvailabelCultRituals.Where(o => o.Checked).ToList();

        public int? SelectedSourceCost => (SelectedSource?.Sum(o => o.RitualPoints) ?? 0);

        public bool CanAddSelection
        {
            get
            {
                return
                   (SelectedSource?.Any() == true)
                   && ((Rituals.Count + (SelectedSource?.Count() ?? 0)) <= 4)
                   && (SelectedSource?.Sum(o => o.RitualPoints) ?? 0) <= (GetStartingFavourCost is null ? 300 : GetStartingFavourCost.Invoke());
            }
        }

        public ObservableCollection<CultRitualViewModel> Rituals { get; } = new();
        public IEnumerable<CultRitualViewModel> SelectedTarget => Rituals.Where(o => o.Checked).ToList();

        public int? SelectedTargetCost => SelectedTarget?.Sum(o => o.RitualPoints) ?? 0;

        public bool CanAddTarget => SelectedTarget?.Any() == true;

        private int _RitualsCount;
        [Range(1, 4, ErrorMessage = "{1} - {2} ritual(s) required in a new cult")]
        public int RitualsCount
        {
            get => _RitualsCount;
            private set => SetField(ref _RitualsCount, value);
        }

        private int _RitualsCost;
        private bool disposedValue;

        public int RitualsCost
        {
            get => _RitualsCost;
            private set => SetField(ref _RitualsCost, value);
        }

        public Func<int?> GetStartingFavourCost { get; internal set; }
        public Action<int?> SetStartingFavourCost { get; internal set; }

        public void AddSelection()
        {
            var set = SelectedSource.ToArray();
            var cost = set.Where(o => o.IsEmpty == false).Sum(p => p.RitualPoints);
            foreach (var item in set) item.Checked = false;

            Rituals.AddRange(set);
            Rituals.Sort((a, b) => (a?.Name ?? "").CompareTo((b.Name ?? "")));
            AvailabelCultRituals.RemoveRange(set);

            RitualsCost += cost;

            var currentFavour = GetStartingFavourCost.Invoke();
            if (SetStartingFavourCost is not null)
            {
                SetStartingFavourCost(currentFavour - cost);
            }
        }

        public void RemoveSelection()
        {
            var set = SelectedTarget.ToArray();
            var cost = set.Where(o => o.IsEmpty == false).Sum(p => p.RitualPoints);

            foreach (var item in set) item.Checked = false;

            AvailabelCultRituals.AddRange(set);
            AvailabelCultRituals.Sort((a, b) => (a?.Name ?? "").CompareTo((b.Name ?? "")));
            Rituals.RemoveRange(set);

            RitualsCost -= cost;

            var currentFavour = GetStartingFavourCost.Invoke();
            if (SetStartingFavourCost is not null)
            {
                SetStartingFavourCost(currentFavour + cost);
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                    if (Rituals is not null)
                    {
                        Rituals.CollectionChanged -= Rituals_CollectionChanged;
                    }
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~CultRitualsViewModel()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
