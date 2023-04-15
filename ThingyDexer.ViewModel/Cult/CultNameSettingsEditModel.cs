using System.ComponentModel.DataAnnotations;
using ThingyDexer.Model.General;

namespace ThingyDexer.ViewModel.Cult
{

    public class CultNameSettingsEditModel : ViewModelBase
    {

        private CultnameInputType? _CultnameInputType;

        [Required(ErrorMessage ="Choose a pattern")]
        public CultnameInputType? CultnameInputType
        {
            get => _CultnameInputType;
            set
            {
                SetField(ref _CultnameInputType, value);
            }
        }

        private bool _IncludeRandomDefiniteArticle = false;
        public bool IncludeRandomDefiniteArticle
        {
            get => _IncludeRandomDefiniteArticle;
            set => SetField(ref _IncludeRandomDefiniteArticle, value);
        }

    }
}
