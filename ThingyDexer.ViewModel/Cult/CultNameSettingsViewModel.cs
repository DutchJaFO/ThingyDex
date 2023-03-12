using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel;
using ThingyDexer.Model.General;
using ThingyDexer.Model.Table;
using ThingyDexer.ViewModel.Table;

namespace ThingyDexer.ViewModel.Cult
{

    [INotifyPropertyChanged]
    public partial class CultNameSettingsViewModel : ViewModelBase
    {
        private void AutoGenerateName()
        {
            switch (CultnameInputType)
            {
                case Model.General.CultnameInputType.Manual:
                    Prefix1 = null;
                    Noun1 = null;
                    Prefix2 = null;
                    Noun2 = null;
                    break;
                default:
                    this.GenerateCultName();
                    break;
            }
        }
        public void UpdateFromEditModel(CultNameSettingsEditModel editModel)
        {
            CultnameInputType = editModel.CultnameInputType;

            AutoGenerateName();
        }

        private CultnameInputType? _CultnameInputType;
        public CultnameInputType? CultnameInputType
        {
            get => _CultnameInputType;
            set
            {
                if (_CultnameInputType != value)
                {
                    _CultnameInputType = value;
                    OnPropertyChanged(nameof(CultnameInputType));
                    OnPropertyChanged(nameof(UseGenerator));

                    if (true)
                    {
                        AutoGenerateName();
                    }
                }
            }
        }

        public CultNameSettingsViewModel(CultnameTableSet cultnameTableSet)
        {
            CultnameTableSet = cultnameTableSet;
        }

        public bool UseGenerator => (CultnameInputType != Model.General.CultnameInputType.Manual);
        //
        public CultnameTableSet CultnameTableSet { get; private set; }

        public DateTime? TimeStamp { get; private set; } = DateTime.Now.ToLocalTime();

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

        //
        public TableRowBase<string>? SelectedRegel
        {
            get;
            set;
        }

        private bool _ShowDetails;
        public bool ShowDetails
        {
            get => _ShowDetails;
            set
            {
                if (_ShowDetails != value)
                {
                    _ShowDetails = value;
                    // OnPropertyChanged(nameof(ShowDetails));
                    SetProperty(ref this._ShowDetails, value);
                }
            }
        }

        //
        public void ClearPrefix()
        {
            try
            {
                bool isPrefix1Selected = Prefix1?.Equals(SelectedRegel) == true;
                bool isPrefix2Selected = Prefix2?.Equals(SelectedRegel) == true;
                bool isNoun1Selected = Noun1?.Equals(SelectedRegel) == true;
                bool isNoun2Selected = Noun2?.Equals(SelectedRegel) == true;

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
                // StateHasChanged();
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
            // StateHasChanged();
        }

        public void RerollSelectedRegel()
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
                //  StateHasChanged();
            }
        }

        public void RerollCultName()
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
                // StateHasChanged();
            }
        }

        public void GenerateCultName()
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

                    (TableRowBase<string>? prefixName, TableRowBase<string>? name, TableRowBase<string>? prefixSomething, TableRowBase<string>? something) = 
                            CultnameTableSet.GenerateName(
                                        Prefix1, 
                                        Noun1, 
                                        Prefix2, 
                                        Noun2, 
                                        CultnameInputType ?? Model.General.CultnameInputType.TemplatePrefixNounOfTheAdjectiveNoun);
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
                    // StateHasChanged();
                }
            }
        }

        public void DoSelectItem(SelectableRegelString newItem)
        {
            if (newItem != null)
            {
                TableRowBase<string>? item = newItem?.Source?.GetRow(newItem.Id);
                try
                {
                    bool isPrefix1Selected = (item?.Owner != null) && (Prefix1?.Owner.Equals(item.Owner) == true);
                    bool isPrefix2Selected = (item?.Owner != null) && (Prefix2?.Owner.Equals(item.Owner) == true);
                    bool isNoun1Selected = (item?.Owner != null) && (Noun1?.Owner.Equals(item.Owner) == true);
                    bool isNoun2Selected = (item?.Owner != null) && (Noun2?.Owner.Equals(item.Owner) == true);

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
                    //StateHasChanged();
                }
            }
        }

    }
}
