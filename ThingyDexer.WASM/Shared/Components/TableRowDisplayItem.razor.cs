using BlazorBootstrap;
using Microsoft.AspNetCore.Components;
using ThingyDexer.Model.Table;

namespace ThingyDexer.WASM.Shared.Components
{
    public delegate void RowSelectDelegate(TableRowBase<string>? row, bool selected);

    public partial class TableRowDisplayItem : ComponentBase
    {
        protected Button? RefButton { get; set; }

        public TableRowDisplayItem() : base() { }

        public bool HasPrefix => string.IsNullOrWhiteSpace(Prefix) == false;

        [Parameter]
        public string? Prefix { get; set; } = null;

        [Parameter]
        public bool IgnoreSelection { get; set; }


        [Parameter, EditorRequired]
        public Table<string>? Table { get; set; }

        private TableRowBase<string>? _RowItem;
        [Parameter]
#pragma warning disable BL0007 // Component parameters should be auto properties
        public TableRowBase<string>? RowItem
#pragma warning restore BL0007 // Component parameters should be auto properties
        {
            get => _RowItem;
            set
            {
                if (_RowItem == value)
                {
                    return;
                }
                else
                {
                    _RowItem = value;
                    RowItemChanged?.Invoke(value);
                    StateHasChanged();
                }
            }
        }

        [Parameter]
        public Action<TableRowBase<string>?>? RowItemChanged { get; set; }

        [Parameter]
        public RowSelectDelegate? OnRowSelect { get; set; }
        public void DoOnRowSelect()
        {
            OnRowSelect?.Invoke(RowItem, Selected);
        }

        private bool _Selected;
        [Parameter]
#pragma warning disable BL0007 // Component parameters should be auto properties
        public bool Selected
#pragma warning restore BL0007 // Component parameters should be auto properties
        {
            get => _Selected;
            set
            {
                _Selected = value;
                StateHasChanged();
            }
        }

        public string? ToolTipText => $"[{RowItem?.Owner.Name}:{RowItem?.Index:D3}] - {RowItem?.Value}";

        public void DoOnClickRollItem()
        {
            RowItem = Table?.GetRandomItem();
            Selected = true;
        }
    }
}