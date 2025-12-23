using BlazorBootstrap;
using Microsoft.AspNetCore.Components;
using System.Collections.ObjectModel;
using ThingyDexer.ViewModel.Cult;

namespace ThingyDexer.WASM.Pages.Wizard.Steps
{
    public partial class CultRitualsStep
    {
        public int CurrentPageSize { get; } = 15;
        public CultRitualsStep()
        {
            _EmptyRows = [];
            for (int i = 1; i <= CurrentPageSize; i++)
            {
                _EmptyRows.Add(CultRitualViewModel.Empty());
            }
        }

        private readonly List<CultRitualViewModel> _EmptyRows;
        private async Task<GridDataProviderResult<CultRitualViewModel>> AvailableRitualsDataprovider(GridDataProviderRequest<CultRitualViewModel> request)
        {
            IEnumerable<CultRitualViewModel> ritualList = ViewModel?.AvailabelCultRituals ?? [];
            IEnumerable<CultRitualViewModel> data;
            //
            var total = ritualList.Count();
            var pageSize = CurrentPageSize;
            var extra = total % pageSize;

            if ((extra > 0) || (total == 0))
                data = ritualList.Union(_EmptyRows.Take((pageSize - extra)));
            else
                data = ritualList;
            return await Task.FromResult(request.ApplyTo(data));
        }
        private async Task<GridDataProviderResult<CultRitualViewModel>> SelectedRitualsDataprovider(GridDataProviderRequest<CultRitualViewModel> request)
        {
            ObservableCollection<CultRitualViewModel> ritualList = ViewModel?.Rituals ?? [];
            IEnumerable<CultRitualViewModel> data;
            //
            var total = ritualList.Count;
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

        public CultRitualsViewModel? ViewModel => Definition?.Rituals;

        [Parameter, EditorRequired]
        public CultDefinitionViewModel? Definition { get; set; }
    }
}