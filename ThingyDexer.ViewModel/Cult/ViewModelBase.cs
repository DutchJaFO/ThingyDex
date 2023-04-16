using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ThingyDexer.ViewModel.Cult
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }


        private bool _IsValid;
        public bool IsValid
        {
            get => _IsValid;
            set => SetField(ref _IsValid, value);
        }
    }
}
