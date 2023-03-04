using Microsoft.AspNetCore.Components;
using ThingyDexer.Model.Table;

namespace ThingyDexer.WASM.Shared.Components
{
    public partial class TableRowDisplayItem:ComponentBase
    {
        [Parameter, EditorRequired]
        public TextTable? Table { get; set; }

        private TableRowBase<string>? _Noun;
        [Parameter]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "BL0007:Component parameters should be auto properties", Justification = "<Pending>")]
        public TableRowBase<string>? Noun
        {
            get => _Noun;
            set
            {
                if (_Noun == value)
                    return;
                _Noun = value;
                NounChanged.InvokeAsync(value);
            }
        }

        [Parameter]
        public EventCallback<TableRowBase<string>?> NounChanged { get; set; }

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

        public void DoSelectNoun()
        {
            SelectedRegel = Noun;
        }

        public void DoRerollSelectedRegel()
        {
            var isNounSelected = Noun?.Equals(SelectedRegel) == true;
            if ((Noun != null) && isNounSelected)
            {
                Noun = Noun.Owner.GetRandomItem();
            }

            if (isNounSelected)
            {
                SelectedRegel = Noun;
            }

            StateHasChanged();
        }

        public void DoRollSelectedRegel()
        {
            Noun = Table?.GetRandomItem();
            SelectedRegel = Noun;
        }
    }
}