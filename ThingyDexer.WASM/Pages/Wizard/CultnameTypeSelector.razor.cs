using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using Microsoft.JSInterop;
using ThingyDexer.WASM;
using ThingyDexer.WASM.Shared;
using BlazorBootstrap;
using ThingyDexer.ViewModel.Cult;
using ThingyDexer.Model.Table;

namespace ThingyDexer.WASM.Pages.Wizard
{
    public partial class CultnameTypeSelector
    {
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
                CultNameSettingsViewModel = new CultNameSettingsViewModel(CultnameTableSet);
            }
        }
        #endregion Protected


        [Inject]
        public CultnameTableSet CultnameTableSet
        {
            get;
            set;
        }

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