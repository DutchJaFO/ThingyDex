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

namespace ThingyDexer.WASM.Pages.Wizard
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public partial class WizardStep
    {
        /// <summary>
        /// The <see cref="Wizard"/> container
        /// </summary>
        [CascadingParameter] protected internal Wizard Parent { get; set; }

        /// <summary>
        /// The Child Content of the current <see cref="WizardStep"/>
        /// </summary>
        [Parameter] public RenderFragment ChildContent { get; set; }

        [Parameter] public RenderFragment Footer { get; set; }

        /// <summary>
        /// The Name of the step
        /// </summary>
        [Parameter] public string Name { get; set; }

        [Parameter] public string Title { get; set; }

        protected override void OnInitialized()
        {
            Parent.AddStep(this);
        }
    }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
}