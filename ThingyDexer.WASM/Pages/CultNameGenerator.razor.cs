using BlazorBootstrap;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
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
            // CultnameTableSet = CultnameTableFactory.Create(new());
            // CultNameSettingsEditModel = new();
            // CultNameSettingsViewModel = new CultNameSettingsViewModel(CultnameTableSet);
        }
        #endregion

        #region Private
        private async Task<GridDataProviderResult<SelectableRegelString>> SelectedRegelTableDataProvider(GridDataProviderRequest<SelectableRegelString> request)
        {
            if (CultNameSettingsViewModel?.SelectedRegel != null)
            {
                TableRowBase<string> regel = CultNameSettingsViewModel.SelectedRegel;
                IEnumerable<SelectableRegelString> data = regel.Owner.Rows(o =>
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
                List<SelectableRegelString> set = new List<SelectableRegelString>();
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
            if (CultNameSettingsViewModel != null)
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
        }

        private void HandleValidSubmit()
        {
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

            MyContext = new EditContext(CultNameSettingsViewModel);
            MyContext.EnableDataAnnotationsValidation(ServiceProvider);

        }
        #endregion Protected

        #region Public

        public EditContext MyContext
        {
            get;
            private set;
        }

        [Inject] IServiceProvider ServiceProvider {get; set; }

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

        [Parameter, EditorRequired]
        public CultNameSettingsViewModel CultNameSettingsViewModel
        {
            get;
            set;
        }



    }
}