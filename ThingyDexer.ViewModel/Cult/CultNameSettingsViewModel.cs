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
        private void AutoGenerateName(CultnameInputType? newType, CultnameInputType? oldType)
        {
            switch (newType)
            {
                case Model.General.CultnameInputType.Manual:
                    DefiniteArticle = null;
                    Adjective1 = null;
                    Noun1 = null;
                    Adjective2 = null;
                    Noun2 = null;
                    break;
                default:
                    if ((newType != oldType)
                        && (newType != null)
                        && (oldType != null)
                        &&
                        (
                        (oldType == Model.General.CultnameInputType.TemplateAdjective2PossessiveNoun2Adjective1Noun1)
                            ||
                            (newType == Model.General.CultnameInputType.TemplateAdjective2PossessiveNoun2Adjective1Noun1)
                            ))
                    {
                        TableRowBase<string>? n1 = Noun1;
                        TableRowBase<string>? n2 = Noun2;
                        Noun1 = n2;
                        Noun2 = n1;

                        TableRowBase<string>? p1 = Adjective1;
                        TableRowBase<string>? p2 = Adjective2;
                        Adjective1 = p2;
                        Adjective2 = p1;
                    }
                    this.GenerateCultName();
                    break;
            }
        }
        public void UpdateFromEditModel(CultNameSettingsEditModel editModel)
        {
            CultnameInputType? oldType = CultnameInputType;
            CultnameInputType = editModel.CultnameInputType;

            AutoGenerateName(CultnameInputType, oldType);
        }

        private CultnameInputType? _CultnameInputType;
        public CultnameInputType? CultnameInputType
        {
            get => _CultnameInputType;
            set
            {
                if (_CultnameInputType != value)
                {
                    CultnameInputType? oldType = _CultnameInputType;
                    _CultnameInputType = value;
                    OnPropertyChanged(nameof(CultnameInputType));
                    OnPropertyChanged(nameof(UseGenerator));

                    if (true)
                    {
                        AutoGenerateName(CultnameInputType, oldType);
                    }
                }
            }
        }

        public CultNameSettingsViewModel(CultnameTableSet cultnameTableSet)
        {
            CultnameTableSet = cultnameTableSet;
        }

        public bool UseGenerator => (CultnameInputType != Model.General.CultnameInputType.Manual);

        public CultnameTableSet CultnameTableSet { get; private set; }

        public DateTime? TimeStamp { get; private set; } = DateTime.Now.ToLocalTime();

        public bool HasCultname
        {
            get
            {
                return (Adjective1 != null) || (Noun1 != null) || (Adjective2 != null) || (Noun2 != null);
            }
        }

        public bool IncludeRandomDefiniteArticle { get; set; } = true;

        public TableRowBase<string>? DefiniteArticle
        {
            get;
            set;
        }

        public TableRowBase<string>? Adjective1
        {
            get;
            set;
        }
        public TableRowBase<string>? Noun1
        {
            get;
            set;
        }

        public TableRowBase<string>? Adjective2
        {
            get;
            set;
        }
        public TableRowBase<string>? Noun2
        {
            get;
            set;
        }

        private TableRowBase<string>? _SelectedRegel;
        public TableRowBase<string>? SelectedRegel
        {
            get => _SelectedRegel;
            set
            {
                SetProperty(ref this._SelectedRegel, value);
                OnPropertyChanged(nameof(HeeftSelectedRegel));
            }
        }

        public bool HeeftSelectedRegel => (SelectedRegel != null);

        private bool _ShowDetails;
        public bool ShowDetails
        {
            get => _ShowDetails;
            set
            {
                SetProperty(ref this._ShowDetails, value);
            }
        }

        public void ClearSelectedItem()
        {
            try
            {
                bool isDefiniteArticleSelected = DefiniteArticle?.Equals(SelectedRegel) == true;
                bool isAdjective1Selected = Adjective1?.Equals(SelectedRegel) == true;
                bool isAdjective2Selected = Adjective2?.Equals(SelectedRegel) == true;
                bool isNoun1Selected = Noun1?.Equals(SelectedRegel) == true;
                bool isNoun2Selected = Noun2?.Equals(SelectedRegel) == true;

                if ((DefiniteArticle != null) && isDefiniteArticleSelected)
                {
                    DefiniteArticle = null;
                }

                if ((Adjective1 != null) && isAdjective1Selected)
                {
                    Adjective1 = null;
                }

                if ((Noun1 != null) && isNoun1Selected)
                {
                    Noun1 = null;
                }

                if ((Adjective2 != null) && isAdjective2Selected)
                {
                    Adjective2 = null;
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
                ShowDetails = false;
            }
        }

        public void ClearCultname()
        {
            SelectedRegel = null;
            DefiniteArticle = null;
            Adjective1 = null;
            Adjective2 = null;
            Noun1 = null;
            Noun2 = null;

            TimeStamp = DateTime.Now.ToLocalTime();

            ShowDetails = false;
        }

        public void RerollSelectedRegel()
        {
            try
            {
                bool isDefiniteArticleSelected = DefiniteArticle?.Equals(SelectedRegel) == true;
                bool isAdjective1Selected = Adjective1?.Equals(SelectedRegel) == true;
                bool isAdjective2Selected = Adjective2?.Equals(SelectedRegel) == true;
                bool isNoun1Selected = Noun1?.Equals(SelectedRegel) == true;
                bool isNoun2Selected = Noun2?.Equals(SelectedRegel) == true;

                if ((DefiniteArticle != null) && isDefiniteArticleSelected)
                {
                    DefiniteArticle = DefiniteArticle.Owner.GetRandomItem();
                    SelectedRegel = DefiniteArticle;
                }

                if ((Adjective1 != null) && isAdjective1Selected)
                {
                    Adjective1 = Adjective1.Owner.GetRandomItem();
                    SelectedRegel = Adjective1;
                }

                if ((Noun1 != null) && isNoun1Selected)
                {
                    Noun1 = Noun1.Owner.GetRandomItem();
                    SelectedRegel = Noun1;
                }

                if ((Adjective2 != null) && isAdjective2Selected)
                {
                    Adjective2 = Adjective2.Owner.GetRandomItem();
                    SelectedRegel = Adjective2;
                }

                if ((Noun2 != null) && isNoun2Selected)
                {
                    Noun2 = Noun2.Owner.GetRandomItem();
                    SelectedRegel = Noun2;
                }
            }
            finally
            {
                TimeStamp = DateTime.Now.ToLocalTime();
            }
        }

        public void RerollDefiniteArticle()
        {
            var isDefiniteArticleSelected = DefiniteArticle?.Equals(SelectedRegel) == true;

            DefiniteArticle = DefiniteArticle?.Owner.GetRandomItem();

            if (isDefiniteArticleSelected)
            {
                SelectedRegel = DefiniteArticle;
            }
        }
        public void RerollCultName()
        {
            try
            {
                bool isDefiniteArticleSelected = DefiniteArticle?.Equals(SelectedRegel) == true;
                bool isAdjective1Selected = Adjective1?.Equals(SelectedRegel) == true;
                bool isAdjective2Selected = Adjective2?.Equals(SelectedRegel) == true;
                bool isNoun1Selected = Noun1?.Equals(SelectedRegel) == true;
                bool isNoun2Selected = Noun2?.Equals(SelectedRegel) == true;

                if (DefiniteArticle is not null)
                {
                    DefiniteArticle = DefiniteArticle.Owner.GetRandomItem();
                    if (isDefiniteArticleSelected)
                    {
                        SelectedRegel = DefiniteArticle;
                    }
                }

                if (Adjective1 is not null)
                {
                    Adjective1 = Adjective1.Owner.GetRandomItem();
                    if (isAdjective1Selected)
                    {
                        SelectedRegel = Adjective1;
                    }
                }

                if (Noun1 is not null)
                {
                    Noun1 = Noun1.Owner.GetRandomItem();
                    if (isNoun1Selected)
                    {
                        SelectedRegel = Noun1;
                    }
                }

                if (Adjective2 is not null)
                {
                    Adjective2 = Adjective2.Owner.GetRandomItem();
                    if (isAdjective2Selected)
                    {
                        SelectedRegel = Adjective2;
                    }
                }

                if (Noun2 is not null)
                {
                    Noun2 = Noun2.Owner.GetRandomItem();
                    if (isNoun2Selected)
                    {
                        SelectedRegel = Noun2;
                    }
                }
            }
            finally
            {
                TimeStamp = DateTime.Now.ToLocalTime();
            }
        }

        public void GenerateCultName()
        {
            if (CultnameTableSet is not null)
            {
                bool isDefiniteArticleSelected = false;
                bool isAdjective1Selected = false;
                bool isAdjective2Selected = false;
                bool isNoun1Selected = false;
                bool isNoun2Selected = false;
                try
                {
                    isDefiniteArticleSelected = DefiniteArticle?.Equals(SelectedRegel) == true;
                    isAdjective1Selected = Adjective1?.Equals(SelectedRegel) == true;
                    isAdjective2Selected = Adjective2?.Equals(SelectedRegel) == true;
                    isNoun1Selected = Noun1?.Equals(SelectedRegel) == true;
                    isNoun2Selected = Noun2?.Equals(SelectedRegel) == true;

                    (TableRowBase<string>? definiteArticle, TableRowBase<string>? adjective1, TableRowBase<string>? name, TableRowBase<string>? adjective2, TableRowBase<string>? something) =
                            CultnameTableSet.GenerateName(
                                        DefiniteArticle,
                                        Adjective1,
                                        Noun1,
                                        Adjective2,
                                        Noun2,
                                        IncludeRandomDefiniteArticle,
                                        CultnameInputType ?? Model.General.CultnameInputType.TemplateAdjective1Noun1OfTheAdjective2Noun2);
                    DefiniteArticle = definiteArticle;
                    Adjective1 = adjective1;
                    Noun1 = name;
                    Adjective2 = adjective2;
                    Noun2 = something;
                }
                finally
                {
                    TimeStamp = DateTime.Now.ToLocalTime();

                    if (isDefiniteArticleSelected)
                    {
                        SelectedRegel = DefiniteArticle;
                    }

                    if (isAdjective1Selected)
                    {
                        SelectedRegel = Adjective1;
                    }

                    if (isAdjective2Selected)
                    {
                        SelectedRegel = Adjective2;
                    }

                    if (isNoun1Selected)
                    {
                        SelectedRegel = Noun1;
                    }

                    if (isNoun2Selected)
                    {
                        SelectedRegel = Noun2;
                    }
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
                    bool isDefiniteArticleSelected = (item?.Owner != null) && (DefiniteArticle?.Owner.Equals(item.Owner) == true);
                    bool isAdjective1Selected = (item?.Owner != null) && (Adjective1?.Owner.Equals(item.Owner) == true);
                    bool isAdjective2Selected = (item?.Owner != null) && (Adjective2?.Owner.Equals(item.Owner) == true);
                    bool isNoun1Selected = (item?.Owner != null) && (Noun1?.Owner.Equals(item.Owner) == true);
                    bool isNoun2Selected = (item?.Owner != null) && (Noun2?.Owner.Equals(item.Owner) == true);

                    if ((DefiniteArticle != null) && isDefiniteArticleSelected)
                    {
                        DefiniteArticle = item;
                    }

                    if ((Adjective1 != null) && isAdjective1Selected)
                    {
                        Adjective1 = item;
                    }

                    if ((Noun1 != null) && isNoun1Selected)
                    {
                        Noun1 = item;
                    }

                    if ((Adjective2 != null) && isAdjective2Selected)
                    {
                        Adjective2 = item;
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
                }
            }
        }

    }
}
