using System.ComponentModel.DataAnnotations;
using ThingyDexer.Model.Cult;

namespace ThingyDexer.ViewModel.Cult
{
    public class CultDefinitionViewModel : ViewModelBase
    {
        private string _CultName = string.Empty;
        [Required]
        public string CultName
        {
            get => _CultName;
            set => SetField(ref _CultName, value);
        }

        private string _Deity = string.Empty;
        [Required]
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
        [Required]
        public StatBlockType? PrimaryFocus
        {
            get => _PrimaryFocus;
            set => SetField(ref _PrimaryFocus, value);
        }

        private int? _StartingFavour;
        [Required]
        public int? StartingFavour
        {
            get => _StartingFavour;
            set => SetField(ref _StartingFavour, value);
        }

        private int _InitialPower;
        [Required]
        public int InitialPower
        {
            get => _InitialPower;
            set => SetField(ref _InitialPower, value);
        }
    }
}
