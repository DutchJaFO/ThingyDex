using System.ComponentModel.DataAnnotations;

namespace ThingyDexer.ViewModel.Cult
{
    public class CultRitualViewModel : ViewModelBase
    {
        public CultRitualViewModel() { }

        public bool IsEmpty { get; private set; } = true;

        private string _Name = string.Empty;
        [Required]
        public string Name
        {
            get => _Name;
            set
            {
                if (SetField(ref _Name, value))
                {
                    IsEmpty = string.IsNullOrEmpty(_Name);
                }
            }
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
    }
}
