using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
namespace ThingyDexer.ViewModel.Cult
{
    public class CultRitualsViewModel : ViewModelBase
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
                RitualsCount += e.NewItems?.Count ?? 0;
            }
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {
                RitualsCount -= e.OldItems?.Count ?? 0;
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
        public IEnumerable<CultRitualViewModel> SelectedSource => AvailabelCultRituals.Where(o => o.Checked);

        public int? SelectedSourceCost => SelectedSource.Sum(o => o.RitualPoints);

        public ObservableCollection<CultRitualViewModel> Rituals { get; } = new();
        public IEnumerable<CultRitualViewModel> SelectedTarget => Rituals.Where(o => o.Checked);

        public int? SelectedTargetCost => SelectedTarget.Sum(o => o.RitualPoints);

        private int _RitualsCount;
        [Range(1, 4, ErrorMessage = "{1} - {2} ritual(s) required in a new cult")]
        public int RitualsCount
        {
            get => _RitualsCount;
            set => SetField(ref _RitualsCount, value);
        }


        public void AddSelection()
        {
            var set = SelectedSource.ToArray();
            foreach (var item in set) item.Checked = false;

            Rituals.AddRange(set);
            Rituals.Sort((a, b) => (a?.Name ?? "").CompareTo((b.Name ?? "")));
            AvailabelCultRituals.RemoveRange(set);
        }

        public void RemoveSelection()
        {
            var set = SelectedTarget.ToArray();
            foreach (var item in set) item.Checked = false;

            AvailabelCultRituals.AddRange(set);
            AvailabelCultRituals.Sort((a, b) => (a?.Name ?? "").CompareTo((b.Name ?? "")));
            Rituals.RemoveRange(set);
        }

    }
}
