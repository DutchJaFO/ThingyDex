using System.ComponentModel.DataAnnotations;
using ThingyDexer.Model.Cult;

namespace ThingyDexer.ViewModel.Cult
{

    public class CultDefinitionViewModel : ViewModelBase
    {
        private string _CultName = string.Empty;
        [Required(ErrorMessage = "Cult name is required")]
        public string CultName
        {
            get => _CultName;
            set => SetField(ref _CultName, value);
        }

        private string _Deity = string.Empty;
        [Required(ErrorMessage = "Deity is required")]
        public string Deity
        {
            get => _Deity;
            set => SetField(ref _Deity, value);
        }

        private string _Description = string.Empty;
        public string Description
        {
            get => _Description;
            set => SetField(ref _Description, value);
        }

        private StatBlockType? _PrimaryFocus;
        [Required(ErrorMessage = "Primary focus is required")]
        public StatBlockType? PrimaryFocus
        {
            get => _PrimaryFocus;
            set => SetField(ref _PrimaryFocus, value);
        }

        private int? _StartingFavour;
        [Required(ErrorMessage = "Need starting favour (300 or 500 recommended)")]
        [Range(0, 1000, ErrorMessage = "Starting favour must be between 0 and 1000")]
        public int? StartingFavour
        {
            get => _StartingFavour;
            set => SetField(ref _StartingFavour, value);
        }

        private int _InitialPower;
        [Required(ErrorMessage = "Initial power is required")]
        [Range(0, 1000, ErrorMessage = "Initial power must be between 0 and 1000")]
        public int InitialPower
        {
            get => _InitialPower;
            set => SetField(ref _InitialPower, value);
        }
    }
}
