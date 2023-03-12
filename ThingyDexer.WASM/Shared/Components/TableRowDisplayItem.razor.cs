using Microsoft.AspNetCore.Components;
using System.Reflection.Metadata.Ecma335;
using ThingyDexer.Model.Table;

namespace ThingyDexer.WASM.Shared.Components
{
    public partial class TableRowDisplayItem : ComponentBase
    {
        [Parameter, EditorRequired]
        public TextTable? Table { get; set; }

        private TableRowBase<string>? _Noun;
        [Parameter]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "BL0007:Component parameters should be auto properties", Justification = "<Pending>")]
        public TableRowBase<string>? Value
        {
            get => _Noun;
            set
            {
                if (_Noun == value)
                    return;
                _Noun = value;
                ValueChanged.InvokeAsync(value);
            }
        }

        [Parameter]
        public EventCallback<TableRowBase<string>?> ValueChanged { get; set; }

        private TableRowBase<string>? _SelectedRegel;

        [Parameter]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "BL0007:Component parameters should be auto properties", Justification = "<Pending>")]
        public TableRowBase<string>? SelectedRegel
        {
            get => _SelectedRegel;
            set
            {
                if (_SelectedRegel == value)
                    return;
                _SelectedRegel = value;
                SelectedRegelChanged.InvokeAsync(value);
            }
        }

        [Parameter]
        public EventCallback<TableRowBase<string>?> SelectedRegelChanged { get; set; }

        [Parameter]
        public Func<string?, string?>? SuffixAction { get; set; }

        public void DoSelectNoun() => SelectedRegel = Value?.Equals(SelectedRegel) == true ? null : Value;

        public void DoRerollSelectedRegel()
        {
            bool isNounSelected = Value?.Equals(SelectedRegel) == true;
            if ((Value != null) && isNounSelected)
            {
                Value = Value.Owner.GetRandomItem();
            }

            if (isNounSelected)
            {
                SelectedRegel = Value;
            }

            StateHasChanged();
        }

        public void DoRollSelectedRegel()
        {
            Value = Table?.GetRandomItem();
            SelectedRegel = Value;
        }
    }
}