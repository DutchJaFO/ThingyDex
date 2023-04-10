using BlazorBootstrap;
using Microsoft.AspNetCore.Components;
using ThingyDexer.Model.Table;
using ThingyDexer.ViewModel.Cult;
using ThingyDexer.ViewModel.Table;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ThingyDexer.WASM.Pages
{
    public partial class CultNameGenerator
    {
        #region Constructors
        public CultNameGenerator()
        {
            // CultnameTableSet = CultnameTableFactory.Create(new());
            // CultNameSettingsEditModel = new();
            // CultNameSettingsViewModel = new CultNameSettingsViewModel(CultnameTableSet);
        }
        #endregion

        #region Private

        private Grid<SelectableRegelString> grid;

        private async Task RefreshGridAsync()
        {
            await grid.RefreshDataAsync();
        }

        private async Task<GridDataProviderResult<SelectableRegelString>> EmployeesDataProvider(GridDataProviderRequest<SelectableRegelString> request)
        {
            if (CultNameSettingsViewModel?.SelectedRegel != null)
            {
                var regel = CultNameSettingsViewModel.SelectedRegel;
                var data = regel.Owner.Rows(o =>
                                        new SelectableRegelString()
                                        {
                                            Selected = (o.Index == regel.Index),
                                            Id = o.Index,
                                            Name = o.Value,
                                            Source = regel.Owner
                                        });

                return await Task.FromResult(request.ApplyTo(data));
            }
            else
            {
                var set = new List<SelectableRegelString>();
                return await Task.FromResult(request.ApplyTo(set));
            }
        }
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
            {
                CultNameSettingsViewModel.ClearSelectedItem();
            }
            else
            {
                CultNameSettingsViewModel.DoSelectItem(context);
            }
        }

        private void HandleValidSubmit()
        {
            CultNameSettingsEditModel.IsValid = true;
            CultNameSettingsViewModel = new(CultnameTableSet, CultNameSettingsEditModel);
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
            CultNameSettingsViewModel = new(CultnameTableSet, CultNameSettingsEditModel);
            StateHasChanged();
        }
        #endregion Private

        #region Protected
        protected override void OnParametersSet()
        {
            base.OnParametersSet();

            if (CultnameTableSet is null)
            {
                CultnameTableSet = CultnameTableFactory.Create(new());
            }

            if (CultNameSettingsEditModel is null)
            {
                CultNameSettingsEditModel = new();
            }

            if (CultNameSettingsViewModel is null)
            {
                CultNameSettingsViewModel = new CultNameSettingsViewModel(CultnameTableSet, CultNameSettingsEditModel);
            }
        }
        #endregion Protected

        #region Public

        [Inject]
        public CultnameTableSet CultnameTableSet
        {
            get;
            set;
        }
        #endregion

        [Parameter]
        public CultNameSettingsEditModel CultNameSettingsEditModel
        {
            get;
            set;
        }

        [Parameter]
        public CultNameSettingsViewModel CultNameSettingsViewModel
        {
            get;
            set;
        }



    }
}