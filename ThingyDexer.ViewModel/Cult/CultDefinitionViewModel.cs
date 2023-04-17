namespace ThingyDexer.ViewModel.Cult
{
    public class CultDefinitionViewModel : ViewModelBase
    {
        private string _CultName = string.Empty;
        public string CultName
        {
            get => _CultName;
            set => SetField(ref _CultName, value);
        }

        private string _Deity = string.Empty;
        public string Deity
        {
            get => _Deity;
            set => SetField(ref _Deity, value);
        }
    }
}
