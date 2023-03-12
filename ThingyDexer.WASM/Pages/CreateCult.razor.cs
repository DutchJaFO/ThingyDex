using ThingyDexer.Model.General;
using ThingyDexer.Model.Table;
using ThingyDexer.ViewModel.Cult;
using ThingyDexer.ViewModel.Table;

namespace ThingyDexer.WASM.Pages
{
    public partial class CreateCult
    {
        public string? MakePossessive(string? value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                return value.EndsWith('s')
                            ? $"{value}'"
                            : $"{value}'s";
            }
            else
            {
                return value;
            }
        }

        public CreateCult()
        {
            CultnameTableSet = CultnameTableFactory.Create(new());
            CultNameSettingsEditModel = new();
            CultNameSettingsViewModel = new CultNameSettingsViewModel(CultnameTableSet);
        }

        public CultnameTableSet CultnameTableSet { get; }
        public CultNameSettingsEditModel CultNameSettingsEditModel { get; set; }
        public CultNameSettingsViewModel CultNameSettingsViewModel { get; set; }

        public void HandleValidSubmit()
        {
            CultNameSettingsEditModel.IsValid = true;
            CultNameSettingsViewModel = new(CultnameTableSet);
            CultNameSettingsViewModel.UpdateFromEditModel(CultNameSettingsEditModel);
            StateHasChanged();
        }
        public void HandleInvalidSubmit()
        {
            ResetCultnameSettings();
            StateHasChanged();
        }

        public void ResetCultnameSettings()
        {
            CultNameSettingsEditModel.CultnameInputType = null;
            CultNameSettingsEditModel.IsValid = false;
            CultNameSettingsViewModel = new(CultnameTableSet);
            StateHasChanged();
        }

        public void DoChangeSelectedRow(SelectableRegelString context, bool allowDelete)
        {
            if (context.Selected && allowDelete)
                CultNameSettingsViewModel.ClearSelectedItem();
            else
                CultNameSettingsViewModel.DoSelectItem(context);
        }



    }
}