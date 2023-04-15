using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using ThingyDexer.Model.Table;
using ThingyDexer.ViewModel.Cult;

namespace ThingyDexer.WASM.Pages.Wizard
{
    public partial class CultnameTypeSelector
    {
        #region Protected

        public EditContext? MyContext
        {
            get;
            private set;
        }
        protected override void OnParametersSet()
        {
            base.OnParametersSet();

            CultNameSettingsEditModel ??= new();

            MyContext = new EditContext(CultNameSettingsEditModel);
#pragma warning disable CS8604 // Possible null reference argument.
            MyContext.EnableDataAnnotationsValidation(ServiceProvider);
#pragma warning restore CS8604 // Possible null reference argument.
        }
        #endregion Protected

        [Inject] IServiceProvider? ServiceProvider { get; set; }

        [Parameter]
        public CultNameSettingsEditModel? CultNameSettingsEditModel
        {
            get;
            set;
        }

    }
}