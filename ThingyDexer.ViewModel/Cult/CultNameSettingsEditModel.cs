using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ThingyDexer.Model.General;
using System.Collections.Generic;
using System.Reflection;
using CommunityToolkit.Mvvm.ComponentModel;

namespace ThingyDexer.ViewModel.Cult
{
    public class ViewModelBase
    {
    }

    [INotifyPropertyChanged]
    public partial class CultNameSettingsEditModel : ViewModelBase
    {

        private CultnameInputType? _CultnameInputType;

        [Required]
        public CultnameInputType? CultnameInputType
        {
            get => _CultnameInputType;
            set
            {
                if (_CultnameInputType != value)
                {
                    _CultnameInputType = value;
                    OnPropertyChanged(nameof(CultnameInputType));
                }
            }
        }

        private bool _IsValid;
        public bool IsValid
        {
            get => _IsValid;
            set
            {
                if (_IsValid != value)
                {
                    _IsValid = value;
                    OnPropertyChanged(nameof(IsValid));
                }
            }
        }

    }
}
