using ThingyDexer.Model.Table;
using ThingyDexer.ViewModel.Cult;
using ThingyDexer.ViewModel.Table;

namespace ThingyDexer.WASM.Pages
{
    public partial class CultNameGenerator
    {
        #region Constructors
        public CultNameGenerator()
        {
            CultnameTableSet = CultnameTableFactory.Create(new());
            CultNameSettingsEditModel = new();
            CultNameSettingsViewModel = new CultNameSettingsViewModel(CultnameTableSet);
        }
        #endregion

        #region Private
        private static string? MakePossessive(string? value)
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

        private void DoChangeSelectedRow(SelectableRegelString context, bool allowDelete)
        {
            if (context.Selected && allowDelete)
                CultNameSettingsViewModel.ClearSelectedItem();
            else
                CultNameSettingsViewModel.DoSelectItem(context);
        }

        private void HandleValidSubmit()
        {
            CultNameSettingsEditModel.IsValid = true;
            CultNameSettingsViewModel = new(CultnameTableSet);
            CultNameSettingsViewModel.UpdateFromEditModel(CultNameSettingsEditModel);
            StateHasChanged();
        }
        private void HandleInvalidSubmit()
        {
            ResetCultnameSettings();
            StateHasChanged();
        }

        private void ResetCultnameSettings()
        {
            CultNameSettingsEditModel.CultnameInputType = null;
            CultNameSettingsEditModel.IsValid = false;
            CultNameSettingsViewModel = new(CultnameTableSet);
            StateHasChanged();
        }
        #endregion Private

        #region Protected
        #endregion Protected

        #region Public
        public CultnameTableSet CultnameTableSet { get; }
        #endregion
        public CultNameSettingsEditModel CultNameSettingsEditModel { get; set; }
        public CultNameSettingsViewModel CultNameSettingsViewModel { get; set; }



    }
}