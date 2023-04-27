using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using ThingyDexer.ViewModel.Cult;

namespace ThingyDexer.WASM.Pages.Wizard
{
    public partial class CultnameTypeSelector
    {
        #region Protected

        protected EditContext? MyContext
        {
            get;
            private set;
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            MyContext = new EditContext(CultNameSettingsViewModel);
            MyContext.EnableDataAnnotationsValidation(ServiceProvider);
            MyContext.MarkAsUnmodified();
        }
        protected override void OnParametersSet()
        {
            base.OnParametersSet();

//            CultNameSettingsViewModel ??= new();
//
//            MyContext = new EditContext(CultNameSettingsViewModel);
//            MyContext.EnableDataAnnotationsValidation(ServiceProvider);
        }
        #endregion Protected

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        [Inject] public IServiceProvider ServiceProvider { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        [Parameter, EditorRequired]
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public CultNameSettingsViewModel CultNameSettingsViewModel
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            get;
            set;
        } = new();

    }
}