using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using ThingyDexer.Model.Table;
using ThingyDexer.ViewModel.Cult;

namespace ThingyDexer.WASM.Pages.Wizard
{
    public partial class CultnameTypeSelector
    {
        #region Protected

        public EditContext MyContext
        {
            get;
            private set;
        }
        protected override void OnParametersSet()
        {
            base.OnParametersSet();

            if (CultNameSettingsEditModel is null)
            {
                CultNameSettingsEditModel = new();
            }

            MyContext = new EditContext(CultNameSettingsEditModel);
            MyContext.EnableDataAnnotationsValidation();
        }
        #endregion Protected
        [Parameter]
        public CultNameSettingsEditModel CultNameSettingsEditModel
        {
            get;
            set;
        }

    }
}