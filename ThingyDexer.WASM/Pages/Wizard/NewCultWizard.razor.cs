using Microsoft.AspNetCore.Components;
using ThingyDexer.ViewModel.Cult;

namespace ThingyDexer.WASM.Pages.Wizard
{
    public partial class NewCultWizard
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        [Inject] public CultNameSettingsViewModel EditModel { get; set; }

        [Inject] public CultNameGeneratorViewModel ViewModel { get; set; }

        [Inject] public CultDefinitionViewModel CultDefinition { get; set; }


        [Inject] public CultRitualsViewModel CultRituals { get; set; }

#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    }
}