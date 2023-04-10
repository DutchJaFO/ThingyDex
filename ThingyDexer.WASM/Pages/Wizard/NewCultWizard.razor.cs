using Microsoft.AspNetCore.Components;
using ThingyDexer.ViewModel.Cult;

namespace ThingyDexer.WASM.Pages.Wizard
{
    public partial class NewCultWizard
    {
        [Inject] public CultNameSettingsEditModel EditModel { get; set; }

        [Inject] public CultNameSettingsViewModel ViewModel { get; set; }
    }
}