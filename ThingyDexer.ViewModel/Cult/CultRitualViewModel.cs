using System.ComponentModel.DataAnnotations;

namespace ThingyDexer.ViewModel.Cult
{
    public class CultRitualViewModel : ViewModelBase
    {
        private static CultRitualViewModel _Empty = new(true);

        protected CultRitualViewModel(bool empty = false) { IsEmpty = empty; }

        public static CultRitualViewModel Create() => new(false);
        public static CultRitualViewModel Empty() => new(true);

        private string _Name = string.Empty;
        [Required]
        public string Name
        {
            get => _Name;
            set => SetField(ref _Name, value);
        }

        private bool _Passive = false;
        public bool Passive
        {
            get => _Passive;
            set => SetField(ref _Passive, value);
        }

        private int _RitualPoints = 0;
        [Range(0, 1000)]
        public int RitualPoints
        {
            get => _RitualPoints;
            set => SetField(ref _RitualPoints, value);
        }

        private string _Description = string.Empty;
        public string Description
        {
            get => _Description;
            set => SetField(ref _Description, value);
        }

        private bool _Checked = false;
        public bool Checked
        {
            get => _Checked;
            set => SetField(ref _Checked, value);
        }
        public bool IsEmpty { get; init; }
    }
}
