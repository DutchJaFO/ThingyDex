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

namespace ThingyDexer.WASM.Pages.Wizard.Steps
{
    public partial class CultMembersStep
    {

        private async Task<GridDataProviderResult<CultMemberViewModel>> CultMembersDataprovider(GridDataProviderRequest<CultMemberViewModel> request)
        {
            IEnumerable<CultMemberViewModel> memberList = ViewModel.Members;
            return await Task.FromResult(request.ApplyTo(memberList));
        }


        public CultMembersViewModel? ViewModel => Definition?.Members;

        [Parameter, EditorRequired]
        public CultDefinitionViewModel? Definition { get; set; }

    }
}