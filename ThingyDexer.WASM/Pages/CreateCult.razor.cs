using BlazorBootstrap;
using Microsoft.AspNetCore.Components;
using System.Reflection.Metadata;
using ThingyDexer.Model.Table;
using ThingyDexer.ViewModel.Table;

namespace ThingyDexer.WASM.Pages
{
    public partial class CreateCult
    {
        public CreateCult()
        {
        }

        public void ClearPrefix()
        {
            try
            {
                var isPrefix1Selected = Prefix1?.Equals(SelectedRegel) == true;
                var isPrefix2Selected = Prefix2?.Equals(SelectedRegel) == true;
                var isNoun1Selected = Noun1?.Equals(SelectedRegel) == true;
                var isNoun2Selected = Noun2?.Equals(SelectedRegel) == true;

                if ((Prefix1 != null) && isPrefix1Selected)
                {
                    Prefix1 = null;
                }

                if ((Noun1 != null) && isNoun1Selected)
                {
                    Noun1 = null;
                }

                if ((Prefix2 != null) && isPrefix2Selected)
                {
                    Prefix2 = null;
                }

                if ((Noun2 != null) && isNoun2Selected)
                {
                    Noun2 = null;
                }
            }
            finally
            {
                TimeStamp = DateTime.Now.ToLocalTime();

                SelectedRegel = null;

                ShowDetails = true;
                StateHasChanged();
            }
        }

        public void ClearCultname()
        {
            SelectedRegel = null;
            Prefix1 = null;
            Prefix2 = null;
            Noun1 = null;
            Noun2 = null;

            TimeStamp = DateTime.Now.ToLocalTime();

            ShowDetails = true;
            StateHasChanged();
        }

        private void DoSelectItem(SelectableRegelString newItem)
        {
            if (newItem != null)
            {
                TableRowBase<string>? item = newItem?.Source?.GetRow(newItem.Id);
                try
                {
                    var isPrefix1Selected = (item?.Owner != null) && (Prefix1?.Owner.Equals(item.Owner) == true);
                    var isPrefix2Selected = (item?.Owner != null) && (Prefix2?.Owner.Equals(item.Owner) == true);
                    var isNoun1Selected = (item?.Owner != null) && (Noun1?.Owner.Equals(item.Owner) == true);
                    var isNoun2Selected = (item?.Owner != null) && (Noun2?.Owner.Equals(item.Owner) == true);

                    if ((Prefix1 != null) && isPrefix1Selected)
                    {
                        Prefix1 = item;
                    }

                    if ((Noun1 != null) && isNoun1Selected)
                    {
                        Noun1 = item;
                    }

                    if ((Prefix2 != null) && isPrefix2Selected)
                    {
                        Prefix2 = item;
                    }

                    if ((Noun2 != null) && isNoun2Selected)
                    {
                        Noun2 = item;
                    }
                }
                finally
                {
                    TimeStamp = DateTime.Now.ToLocalTime();

                    SelectedRegel = item;

                    ShowDetails = true;
                    StateHasChanged();
                }
            }
        }

        private void RerollSelectedRegel()
        {
            bool isPrefix1Selected = false;
            bool isPrefix2Selected = false;
            bool isNoun1Selected = false;
            bool isNoun2Selected = false;
            try
            {
                isPrefix1Selected = Prefix1?.Equals(SelectedRegel) == true;
                isPrefix2Selected = Prefix2?.Equals(SelectedRegel) == true;
                isNoun1Selected = Noun1?.Equals(SelectedRegel) == true;
                isNoun2Selected = Noun2?.Equals(SelectedRegel) == true;

                if ((Prefix1 != null) && isPrefix1Selected)
                {
                    Prefix1 = Prefix1.Owner.GetRandomItem();
                }

                if ((Noun1 != null) && isNoun1Selected)
                {
                    Noun1 = Noun1.Owner.GetRandomItem();
                }

                if ((Prefix2 != null) && isPrefix2Selected)
                {
                    Prefix2 = Prefix2.Owner.GetRandomItem();
                }

                if ((Noun2 != null) && isNoun2Selected)
                {
                    Noun2 = Noun2.Owner.GetRandomItem();
                }
            }
            finally
            {
                TimeStamp = DateTime.Now.ToLocalTime();

                if (isPrefix1Selected) SelectedRegel = Prefix1;
                if (isPrefix2Selected) SelectedRegel = Prefix2;
                if (isNoun1Selected) SelectedRegel = Noun1;
                if (isNoun2Selected) SelectedRegel = Noun2;

                ShowDetails = true;
                StateHasChanged();
            }
        }

        private void RerollCultName()
        {
            bool isPrefix1Selected = false;
            bool isPrefix2Selected = false;
            bool isNoun1Selected = false;
            bool isNoun2Selected = false;
            try
            {
                isPrefix1Selected = Prefix1?.Equals(SelectedRegel) == true;
                isPrefix2Selected = Prefix2?.Equals(SelectedRegel) == true;
                isNoun1Selected = Noun1?.Equals(SelectedRegel) == true;
                isNoun2Selected = Noun2?.Equals(SelectedRegel) == true;

                if (Prefix1 is not null)
                {
                    Prefix1 = Prefix1.Owner.GetRandomItem();
                }

                if (Noun1 is not null)
                {
                    Noun1 = Noun1.Owner.GetRandomItem();
                }

                if (Prefix2 is not null)
                {
                    Prefix2 = Prefix2.Owner.GetRandomItem();
                }

                if (Noun2 is not null)
                {
                    Noun2 = Noun2.Owner.GetRandomItem();
                }
            }
            finally
            {
                TimeStamp = DateTime.Now.ToLocalTime();

                if (isPrefix1Selected) SelectedRegel = Prefix1;
                if (isPrefix2Selected) SelectedRegel = Prefix2;
                if (isNoun1Selected) SelectedRegel = Noun1;
                if (isNoun2Selected) SelectedRegel = Noun2;

                ShowDetails = true;
                StateHasChanged();
            }
        }

        private void GenerateCultName(bool spiffy)
        {
            if (CultnameTableSet is not null)
            {
                bool isPrefix1Selected = false;
                bool isPrefix2Selected = false;
                bool isNoun1Selected = false;
                bool isNoun2Selected = false;
                try
                {
                    isPrefix1Selected = Prefix1?.Equals(SelectedRegel) == true;
                    isPrefix2Selected = Prefix2?.Equals(SelectedRegel) == true;
                    isNoun1Selected = Noun1?.Equals(SelectedRegel) == true;
                    isNoun2Selected = Noun2?.Equals(SelectedRegel) == true;

                    (TableRowBase<string>? prefixName, TableRowBase<string>? name, TableRowBase<string>? prefixSomething, TableRowBase<string>? something) = CultnameTableSet.GenerateName(spiffy);
                    Prefix1 = prefixName;
                    Noun1 = name;
                    Prefix2 = prefixSomething;
                    Noun2 = something;
                }
                finally
                {
                    TimeStamp = DateTime.Now.ToLocalTime();

                    if (isPrefix1Selected) SelectedRegel = Prefix1;
                    if (isPrefix2Selected) SelectedRegel = Prefix2;
                    if (isNoun1Selected) SelectedRegel = Noun1;
                    if (isNoun2Selected) SelectedRegel = Noun2;

                    ShowDetails = true;
                    StateHasChanged();
                }
            }
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
        }

        [Inject]
        public CultnameTableSet? CultnameTableSet { get; set; }

        public DateTime? TimeStamp { get; private set; }= DateTime.Now.ToLocalTime();

        public bool HasCultname
        {
            get
            {
                return (Prefix1 != null) || (Noun1 != null) || (Prefix2 != null) || (Noun2 != null);
            }
        }

        public TableRowBase<string>? Prefix1
        {
            get;
            set;
        }
        public TableRowBase<string>? Noun1
        {
            get;
            set;
        }

        public TableRowBase<string>? Prefix2
        {
            get;
            set;
        }
        public TableRowBase<string>? Noun2
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


        public TableRowBase<string>? SelectedRegel
        {
            get;
            set;
        }
    }
}