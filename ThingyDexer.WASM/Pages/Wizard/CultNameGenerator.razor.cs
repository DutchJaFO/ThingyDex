using BlazorBootstrap;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using ThingyDexer.Model.Table;
using ThingyDexer.ViewModel.Cult;
using ThingyDexer.ViewModel.Table;

namespace ThingyDexer.WASM.Pages.Wizard
{
    public partial class CultNameGenerator
    {
        #region Constructors
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public CultNameGenerator()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            // CultnameTableSet = CultnameTableFactory.Create(new());
            // CultNameSettingsEditModel = new();
            // CultNameSettingsViewModel = new CultNameSettingsViewModel(CultnameTableSet);
        }
        #endregion

        #region Private
        private async Task<GridDataProviderResult<SelectableRegelString>> SelectedRegelTableDataProvider(GridDataProviderRequest<SelectableRegelString> request)
        {
            if (CultNameGeneratorViewModel?.SelectedRegel != null)
            {
                TableRowBase<string> regel = CultNameGeneratorViewModel.SelectedRegel;
                IEnumerable<SelectableRegelString> data = regel.Owner.Rows(o =>
                                        new SelectableRegelString()
                                        {
                                            Selected = o.Index == regel.Index,
                                            Id = o.Index,
                                            Name = o.Value,
                                            Source = regel.Owner
                                        });

                return await Task.FromResult(request.ApplyTo(data));
            }
            else
            {
                List<SelectableRegelString> set = new ();
                return await Task.FromResult(request.ApplyTo(set));
            }
        }
        private static string? MakePossessive(string? value) => 
            string.IsNullOrEmpty(value)
                ? value
                : value.EndsWith('s')
                            ? $"{value}'"
                            : $"{value}'s";

        private void DoChangeSelectedRow(SelectableRegelString context, bool allowDelete)
        {
            if (CultNameGeneratorViewModel != null)
            {
                if (context.Selected && allowDelete)
                {
                    CultNameGeneratorViewModel.ClearSelectedItem();
                }
                else
                {
                    CultNameGeneratorViewModel.DoSelectItem(context);
                }
            }
        }

        private void HandleValidSubmit()
        {
            CultNameGeneratorViewModel = new(CultnameTableSet, CultNameSettingsViewModel);
            // CultNameGeneratorViewModel.UpdateFromEditModel(CultNameSettingsViewModel);
            StateHasChanged();
        }
        private void HandleInvalidSubmit()
        {
            ResetCultnameSettings();
            StateHasChanged();
        }

        private void ResetCultnameSettings()
        {
            CultNameGeneratorViewModel = new(CultnameTableSet, CultNameSettingsViewModel);
            StateHasChanged();
        }
        #endregion Private

        #region Protected

        protected override void OnParametersSet()
        {
            base.OnParametersSet();

            CultnameTableSet ??= CultnameTableFactory.Create(new());

            CultNameSettingsViewModel ??= new();

            CultNameGeneratorViewModel ??= new CultNameGeneratorViewModel(CultnameTableSet, CultNameSettingsViewModel);

            MyContext = new EditContext(CultNameGeneratorViewModel);
            MyContext.EnableDataAnnotationsValidation(ServiceProvider);

            CultNameGeneratorViewModel.OnUpdateSelection = DoOnUpdateSelection;
            CultNameGeneratorViewModel.OnUpdateCultname = DoOnUpdateCultname;

            initControls = true;
        }

        private bool initControls = false;
        protected override void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);
            if (initControls)
            {
                DoUpdateControls();
                initControls = false;
            }
        }
        #endregion Protected

        #region Public

        public void DoUpdateControls()
        {
            DoOnUpdateSelection(CultNameGeneratorViewModel.SelectedRegel);
            DoOnUpdateCultname(CultNameGeneratorViewModel.Cultname);
        }

        public EditContext MyContext
        {
            get;
            private set;
        }

        [Inject] IServiceProvider ServiceProvider { get; set; }

        [Inject]
        public CultnameTableSet CultnameTableSet
        {
            get;
            set;
        }
        #endregion

        [Parameter]
        public CultNameSettingsViewModel CultNameSettingsViewModel
        {
            get;
            set;
        }

        [Parameter, EditorRequired]
        public CultNameGeneratorViewModel CultNameGeneratorViewModel
        {
            get;
            set;
        } 



    }
}