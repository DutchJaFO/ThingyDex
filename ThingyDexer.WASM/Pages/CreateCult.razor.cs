using Microsoft.AspNetCore.Components;
using ThingyDexer.Model.Table;

namespace ThingyDexer.WASM.Pages
{
    public partial class CreateCult
    {
        public CreateCult()
        {
        }

        public void ClearPrefix()
        {
            SelectedRegel = null;
            Prefix1 = null;
        }

        public void ClearCultname()
        {
            SelectedRegel = null;
            Prefix1 = null;
            Prefix2 = null;
            Item1 = null;
            Item2 = null;
        }
        private void RerollCultName()
        {
            try
            {
                SkipUpdate = true;
                if (Prefix1 is not null)
                {
                    Prefix1 = Prefix1.Owner.GetRandomItem();
                }

                if (Item1 is not null)
                {
                    Item1 = Item1.Owner.GetRandomItem();
                }

                if (Prefix2 is not null)
                {
                    Prefix2 = Prefix2.Owner.GetRandomItem();
                }

                if (Item2 is not null)
                {
                    Item2 = Item2.Owner.GetRandomItem();
                }
            }
            finally
            {
                TimeStamp = DateTime.Now.ToLocalTime();
                SkipUpdate = false;
                SelectedRegel = Prefix1 ?? Item1;
            }
        }

        private void GenerateCultName(bool spiffy)
        {
            if (CultnameTableSet is not null)
            {
                try
                {
                    SkipUpdate = true;
                    (TableRowBase<string>? prefixName, TableRowBase<string>? name, TableRowBase<string>? prefixSomething, TableRowBase<string>? something) = CultnameTableSet.GenerateName(spiffy);
                    Prefix1 = prefixName;
                    Item1 = name;
                    Prefix2 = prefixSomething;
                    Item2 = something;
                }
                finally
                {
                    TimeStamp = DateTime.Now.ToLocalTime();
                    SkipUpdate = false;
                    SelectedRegel = Prefix1 ?? Item1;
                }
            }
        }

        public bool SkipUpdate { get; set; }

        public bool Prefix1Selected
        {
            get;
            set;
        }

        public bool Prefix2Selected
        {
            get;
            set;
        }

        public bool Item1Selected
        {
            get;
            set;
        }

        public bool Item2Selected
        {
            get;
            set;
        }

        protected void DoOnRowSelect(TableRowBase<string>? row, bool selected)
        {
            if (row != null)
            {
                TableRowBase<string> nieuweSelectie = row;
                if ((SelectedRegel != null) && SelectedRegel.Equals(nieuweSelectie))
                {
                    SelectedRegel = null;
                }
                else
                {
                    SelectedRegel = nieuweSelectie;
                }
            }
            else
            {
                SelectedRegel = null;
            }
            ShowDetails = (SelectedRegel != null);
            StateHasChanged();
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
        }

        [Inject]
        public CultnameTableSet? CultnameTableSet { get; set; }

        public DateTime? TimeStamp { get; private set; }

        public bool Spiffy { get; set; }
        public void SpiffyValueChanged(bool newValue)
        {
            bool oldSpiffy = Spiffy;
            Spiffy = newValue;
            if (HasCultname)
            {
                GenerateCultName(oldSpiffy);
            }
        }

        public bool HasCultname
        {
            get
            {
                return (Prefix1 != null) || (Item1 != null) || (Prefix2 != null) || (Item2 != null);
            }
        }

        public TableRowBase<string>? Prefix1
        {
            get;
            set;
        }
        public TableRowBase<string>? Item1
        {
            get;
            set;
        }

        public TableRowBase<string>? Prefix2
        {
            get;
            set;
        }
        public TableRowBase<string>? Item2
        {
            get;
            set;
        }


        private bool _ShowDetails;
        public bool ShowDetails
        {
            get => _ShowDetails;
            set { _ShowDetails = value; StateHasChanged(); }
        }


        private TableRowBase<string>? _SelectedRegel;
        public TableRowBase<string>? SelectedRegel
        {
            get => _SelectedRegel;
            set
            {
                _SelectedRegel = value;

                if (SelectedRegel is not null)
                {
                    Prefix1Selected = (SelectedRegel.Equals(Prefix1));
                    Prefix2Selected = (SelectedRegel.Equals(Prefix2));
                    Item1Selected = (SelectedRegel.Equals(Item1));
                    Item2Selected = (SelectedRegel.Equals(Item2));
                }
                else
                {
                    Prefix1Selected = false;
                    Prefix2Selected = false;
                    Item1Selected = false;
                    Item2Selected = false;
                }
                StateHasChanged();
            }
        }

        protected void OnClickWithArgs(EventArgs args, TableRowBase<string> data)
        {
            if ((SelectedRegel != null) && SelectedRegel.Equals(data))
            {
                SelectedRegel = null;
            }
            else
            {
                SelectedRegel = data;
            }
            StateHasChanged();
        }
    }
}