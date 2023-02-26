using Microsoft.AspNetCore.Components;
using ThingyDexer.Model.Table;
using ThingyDexer.ViewModel.Table;

namespace ThingyDexer.WASM.Pages
{
    public partial class CreateCult
    {
        public CreateCult()
        {
        }

        public void ClearCultname()
        {
            SelectedRegel = null;
            Prefix1 = null;
            Prefix2 = null;
            Item1 = null;
            Item2 = null;
        }
        private void GenerateCultName(bool spiffy)
        {
            if (CultnameTableSet is null)
            {
                return;
            }

            bool prefix1Selected = Prefix1Selected;
            bool prefix2Selected = Prefix2Selected;
            bool item1Selected = Item1Selected;
            bool item2Selected = Item2Selected;

            try
            {
                IgnoreSelection = true;
                if ((Prefix1 is null) && (Prefix2 is null) && (Item1 is null) && (Item2 is null))
                {
                    if (spiffy)
                    {
                        Prefix1 = CultnameTableSet.PrefixTable.GetRandomItem();
                    }
                    Item1 = CultnameTableSet.SomethingTable.GetRandomItem();

                    Prefix2 = CultnameTableSet.PrefixNameTable.GetRandomItem();
                    Item2 = CultnameTableSet.NameTable.GetRandomItem();
                }
                else
                {
                    if (Prefix1 is not null)
                    {
                        Prefix1 = CultnameTableSet.PrefixTable.GetRandomItem();
                    }

                    if (Item1 is not null)
                    {
                        Item1 = CultnameTableSet.SomethingTable.GetRandomItem();
                    }

                    if (Prefix2 is not null)
                    {
                        Prefix2 = CultnameTableSet.PrefixNameTable.GetRandomItem();
                    }

                    if (Item2 is not null)
                    {
                        Item2 = CultnameTableSet.NameTable.GetRandomItem();
                    }
                }

                if (prefix1Selected || prefix2Selected || item1Selected || item2Selected)
                {
                    if (prefix1Selected)
                    {
                        SelectedRegel = Prefix1;
                    }
                    if (item1Selected)
                    {
                        SelectedRegel = Item1;
                    }

                    if (prefix2Selected)
                    {
                        SelectedRegel = Prefix2;
                    }
                    if (item2Selected)
                    {
                        SelectedRegel = Item2;
                    }
                }
                else
                {
                    SelectedRegel = null;
                }
                TimeStamp = DateTime.Now.ToLocalTime();
                // StateHasChanged();
            }
            finally
            {
                IgnoreSelection = false;
            }
        }

        public bool IgnoreSelection { get; set; }

        public bool Prefix1Selected
        {
            get
            {
                return (Prefix1 != null) && (Prefix1?.Equals(SelectedRegel) == true);
            }
        }

        public bool Prefix2Selected
        {
            get
            {
                return (Prefix2 != null) && (Prefix2?.Equals(SelectedRegel) == true);
            }
        }

        public bool Item1Selected
        {
            get
            {
                return (Item1 != null) && (Item1?.Equals(SelectedRegel) == true);
            }
        }

        public bool Item2Selected
        {
            get
            {
                return (Item2 != null) && (Item2?.Equals(SelectedRegel) == true);
            }
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

        public TableRowBase<string>? Prefix1 { get; set; }
        public TableRowBase<string>? Item1 { get; set; }

        public TableRowBase<string>? Prefix2 { get; set; }
        public TableRowBase<string>? Item2 { get; set; }


        private bool _ShowDetails;
        public bool ShowDetails
        {
            get => _ShowDetails;
            set { _ShowDetails = value; StateHasChanged(); }
        }


        public TableRowBase<string>? SelectedRegel { get; set; }

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