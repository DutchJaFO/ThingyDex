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
using ThingyDexer.Model.Cult;
using ThingyDexer.ViewModel.Cult;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ThingyDexer.WASM.Pages.Wizard.Steps
{
    public partial class CultRitualsStep
    {
        public int CurrentPageSize { get; } = 15;
        public CultRitualsStep()
        {
            _EmptyRows = new();
            for (int i = 1; i <= CurrentPageSize; i++)
            {
                _EmptyRows.Add(CultRitualViewModel.Empty());
            }
        }

        private List<CultRitualViewModel> _EmptyRows;
        private async Task<GridDataProviderResult<CultRitualViewModel>> AvailableRitualsDataprovider(GridDataProviderRequest<CultRitualViewModel> request)
        {
            IEnumerable<CultRitualViewModel> ritualList = ViewModel.AvailabelCultRituals;
            IEnumerable<CultRitualViewModel> data;
            //
            var total = ritualList.Count();
            var pageSize = CurrentPageSize;
            var extra = total % pageSize;

            if ((extra > 0) || (total == 0))            // if (extra > 0)
                data = ritualList.Union(_EmptyRows.Take((pageSize - extra)));
            else
                data = ritualList;
            return await Task.FromResult(request.ApplyTo(data));
        }
        private async Task<GridDataProviderResult<CultRitualViewModel>> SelectedRitualsDataprovider(GridDataProviderRequest<CultRitualViewModel> request)
        {
            var ritualList = ViewModel.Rituals;
            IEnumerable<CultRitualViewModel> data;
            //
            var total = ritualList.Count();
            var pageSize = CurrentPageSize;
            var extra = total % pageSize;

            if ((extra > 0) || (total == 0))            // if (extra > 0)
            {
                data = ritualList.Union(_EmptyRows.Take((pageSize - extra)));
            }
            else
            {
                data = ritualList;
            }

            return await Task.FromResult(request.ApplyTo(data));
        }

        private string GetRowClass(CultRitualViewModel emp)
        {
            if (emp.IsEmpty)
            {
                return "table-danger opacity-0";
            }
            else
            {
                if (emp.Checked)
                    return "table-primary";
                else
                    return string.Empty;
            }
        }

        private async Task UpdateGrids()
        {
            if (SourceGrid is not null)
            {
                await SourceGrid.RefreshDataAsync();
            }
            if (TargetGrid is not null)
            {
                await TargetGrid.RefreshDataAsync();
            }
            await Task.CompletedTask;
        }

        private Grid<CultRitualViewModel>? SourceGrid;
        private Grid<CultRitualViewModel>? TargetGrid;

        [Parameter, EditorRequired]
        public CultRitualsViewModel ViewModel { get; set; } = new CultRitualsViewModel();
    }
}