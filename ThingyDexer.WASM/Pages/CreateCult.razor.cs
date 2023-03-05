using BlazorBootstrap;
using Microsoft.AspNetCore.Components;
using System.Reflection.Metadata;
using ThingyDexer.Model.Table;
using ThingyDexer.ViewModel.Cult;
using ThingyDexer.ViewModel.Table;

namespace ThingyDexer.WASM.Pages
{
    public partial class CreateCult
    {
        public CreateCult()
        {
            CultnameTableSet = CultnameTableFactory.Create();
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
            CultNameSettingsEditModel.CultnameInputType = null;
            CultNameSettingsEditModel.IsValid = false;
            CultNameSettingsViewModel = new(CultnameTableSet);
            StateHasChanged();
        }

        public void HandleReset()
        {
            CultNameSettingsEditModel.CultnameInputType = null;
            CultNameSettingsEditModel.IsValid = false;
            CultNameSettingsViewModel = new(CultnameTableSet);
            StateHasChanged();
        }

        public void DoChangeSelectedRow(SelectableRegelString context, bool allowDelete)
        {
            if (context.Selected && allowDelete)
                CultNameSettingsViewModel.ClearPrefix();
            else
                CultNameSettingsViewModel.DoSelectItem(context);
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
        }



    }
}