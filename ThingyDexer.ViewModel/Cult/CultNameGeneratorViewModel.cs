using System.ComponentModel.DataAnnotations;
using ThingyDexer.Model.General;
using ThingyDexer.Model.Table;
using ThingyDexer.ViewModel.Table;

namespace ThingyDexer.ViewModel.Cult
{
    public class CultNameGeneratorViewModel : ViewModelBase
    {
        private static string? MakePossessive(string? value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                return value.EndsWith('s')
                            ? $"{value}'"
                            : $"{value}'s";
            }
            else
            {
                return value;
            }
        }

        private bool _SkipUpdates = false;
        public void UpdateCultname()
        {
            if (_SkipUpdates) return;
            ValidCultname = ((CultnameResult.Noun1 != null) || (CultnameResult.Noun2 != null)) ? true : null;

            Cultname = CultnameResult.FullName;
        }

        private bool? _ValidCultname;
        [Required(ErrorMessage = "Cult name is invalid")]
        public bool? ValidCultname
        {
            get => _ValidCultname;
            private set => SetField(ref _ValidCultname, value);
        }

        public CultNameGeneratorViewModel(CultnameTableSet cultnameTableSet, CultNameSettingsViewModel settings)
        {
            CultnameTableSet = cultnameTableSet;
            Settings = settings;
        }

        [Required]
        public CultNameSettingsViewModel Settings
        {
            get;
            private set;
        }

        public bool UseGenerator => (Settings.CultnameInputType != Model.General.CultnameInputType.Manual);

        public CultnameTableSet CultnameTableSet { get; private set; }

        private DateTime? _TimeStamp;
        public DateTime? TimeStamp
        {
            get => _TimeStamp;
            private set => SetField(ref _TimeStamp, value);
        }

        [Required]
        public bool HasCultname
        {
            get
            {
                return (CultnameResult.Adjective1 != null) || (CultnameResult.Noun1 != null) || (CultnameResult.Adjective2 != null) || (CultnameResult.Noun2 != null);
            }
        }

        private string? _Cultname;

        [Required(ErrorMessage = "Roll your cult name")]
        public string? Cultname
        {
            get => _Cultname;
            set
            {
                string? oldValue = _Cultname;
                SetField(ref _Cultname, value);

                OnUpdateCultname?.Invoke(value);
            }
        }

        public Action<string?>? OnUpdateCultname { get; set; }
        public Action<TableRowBase<string>?>? OnUpdateSelection { get; set; }


        private ThingyDexer.Model.Table.CultnameResult _CultnameResult = new();
        public ThingyDexer.Model.Table.CultnameResult CultnameResult
        {
            get => _CultnameResult;
            set => SetField(ref _CultnameResult, value);
        }

        private TableRowBase<string>? _SelectedRegel;
        public TableRowBase<string>? SelectedRegel
        {
            get => _SelectedRegel;
            set
            {
                TableRowBase<string>? oldValue = _SelectedRegel;
                SetField(ref _SelectedRegel, value);
                HeeftSelectedRegel = _SelectedRegel is not null;

                OnUpdateSelection?.Invoke(_SelectedRegel);
            }
        }

        private bool _HeeftSelectedRegel = false;
        public bool HeeftSelectedRegel
        {
            get => _HeeftSelectedRegel;
            private set => SetField(ref _HeeftSelectedRegel, value);
        }

        private bool _ShowDetails;
        public bool ShowDetails
        {
            get => _ShowDetails;
            set
            {
                SetField(ref _ShowDetails, value);
            }
        }

        public void ClearSelectedItem()
        {
            try
            {
                _SkipUpdates = true;
                bool isDefiniteArticleSelected = CultnameResult.DefiniteArticle?.Equals(SelectedRegel) == true;
                bool isAdjective1Selected = CultnameResult.Adjective1?.Equals(SelectedRegel) == true;
                bool isAdjective2Selected = CultnameResult.Adjective2?.Equals(SelectedRegel) == true;
                bool isNoun1Selected = CultnameResult.Noun1?.Equals(SelectedRegel) == true;
                bool isNoun2Selected = CultnameResult.Noun2?.Equals(SelectedRegel) == true;

                if ((CultnameResult.DefiniteArticle != null) && isDefiniteArticleSelected)
                {
                    CultnameResult.DefiniteArticle = null;
                }

                if ((CultnameResult.Adjective1 != null) && isAdjective1Selected)
                {
                    CultnameResult.Adjective1 = null;
                }

                if ((CultnameResult.Noun1 != null) && isNoun1Selected)
                {
                    CultnameResult.Noun1 = null;
                }

                if ((CultnameResult.Adjective2 != null) && isAdjective2Selected)
                {
                    CultnameResult.Adjective2 = null;
                }

                if ((CultnameResult.Noun2 != null) && isNoun2Selected)
                {
                    CultnameResult.Noun2 = null;
                }
            }
            finally
            {
                TimeStamp = DateTime.Now.ToLocalTime();
                _SkipUpdates = false;
                UpdateCultname();
                SelectedRegel = null;
                ShowDetails = false;
            }
        }

        public void ClearCultname()
        {
            try
            {
                _SkipUpdates = true;
                SelectedRegel = null;

                CultnameResult.DefiniteArticle = null;
                CultnameResult.Adjective1 = null;
                CultnameResult.Adjective2 = null;
                CultnameResult.Noun1 = null;
                CultnameResult.Noun2 = null;

                TimeStamp = DateTime.Now.ToLocalTime();

                ShowDetails = false;
            }
            finally
            {
                _SkipUpdates = false;
                UpdateCultname();
            }
        }

        public void RerollSelectedRegel()
        {
            try
            {
                bool isDefiniteArticleSelected = CultnameResult.DefiniteArticle?.Equals(SelectedRegel) == true;
                bool isAdjective1Selected = CultnameResult.Adjective1?.Equals(SelectedRegel) == true;
                bool isAdjective2Selected = CultnameResult.Adjective2?.Equals(SelectedRegel) == true;
                bool isNoun1Selected = CultnameResult.Noun1?.Equals(SelectedRegel) == true;
                bool isNoun2Selected = CultnameResult.Noun2?.Equals(SelectedRegel) == true;

                if ((CultnameResult.DefiniteArticle != null) && isDefiniteArticleSelected)
                {
                    CultnameResult.DefiniteArticle = CultnameResult.DefiniteArticle.Owner.GetRandomItem();
                    SelectedRegel = CultnameResult.DefiniteArticle;
                }

                if ((CultnameResult.Adjective1 != null) && isAdjective1Selected)
                {
                    CultnameResult.Adjective1 = CultnameResult.Adjective1.Owner.GetRandomItem();
                    SelectedRegel = CultnameResult.Adjective1;
                }

                if ((CultnameResult.Noun1 != null) && isNoun1Selected)
                {
                    CultnameResult.Noun1 = CultnameResult.Noun1.Owner.GetRandomItem();
                    SelectedRegel = CultnameResult.Noun1;
                }

                if ((CultnameResult.Adjective2 != null) && isAdjective2Selected)
                {
                    CultnameResult.Adjective2 = CultnameResult.Adjective2.Owner.GetRandomItem();
                    SelectedRegel = CultnameResult.Adjective2;
                }

                if ((CultnameResult.Noun2 != null) && isNoun2Selected)
                {
                    CultnameResult.Noun2 = CultnameResult.Noun2.Owner.GetRandomItem();
                    SelectedRegel = CultnameResult.Noun2;
                }
            }
            finally
            {
                TimeStamp = DateTime.Now.ToLocalTime();
                UpdateCultname();
            }
        }

        public void RerollDefiniteArticle()
        {
            bool isDefiniteArticleSelected = CultnameResult.DefiniteArticle?.Equals(SelectedRegel) == true;

            CultnameResult.DefiniteArticle = CultnameResult.DefiniteArticle?.Owner.GetRandomItem();

            if (isDefiniteArticleSelected)
            {
                SelectedRegel = CultnameResult.DefiniteArticle;
            }
        }
        public void RerollCultName()
        {
            try
            {
                _SkipUpdates = true;
                bool isDefiniteArticleSelected = CultnameResult.DefiniteArticle?.Equals(SelectedRegel) == true;
                bool isAdjective1Selected = CultnameResult.Adjective1?.Equals(SelectedRegel) == true;
                bool isAdjective2Selected = CultnameResult.Adjective2?.Equals(SelectedRegel) == true;
                bool isNoun1Selected = CultnameResult.Noun1?.Equals(SelectedRegel) == true;
                bool isNoun2Selected = CultnameResult.Noun2?.Equals(SelectedRegel) == true;

                if (CultnameResult.DefiniteArticle is not null)
                {
                    CultnameResult.DefiniteArticle = CultnameResult.DefiniteArticle.Owner.GetRandomItem();
                    if (isDefiniteArticleSelected)
                    {
                        SelectedRegel = CultnameResult.DefiniteArticle;
                    }
                }

                if (CultnameResult.Adjective1 is not null)
                {
                    CultnameResult.Adjective1 = CultnameResult.Adjective1.Owner.GetRandomItem();
                    if (isAdjective1Selected)
                    {
                        SelectedRegel = CultnameResult.Adjective1;
                    }
                }

                if (CultnameResult.Noun1 is not null)
                {
                    CultnameResult.Noun1 = CultnameResult.Noun1.Owner.GetRandomItem();
                    if (isNoun1Selected)
                    {
                        SelectedRegel = CultnameResult.Noun1;
                    }
                }

                if (CultnameResult.Adjective2 is not null)
                {
                    CultnameResult.Adjective2 = CultnameResult.Adjective2.Owner.GetRandomItem();
                    if (isAdjective2Selected)
                    {
                        SelectedRegel = CultnameResult.Adjective2;
                    }
                }

                if (CultnameResult.Noun2 is not null)
                {
                    CultnameResult.Noun2 = CultnameResult.Noun2.Owner.GetRandomItem();
                    if (isNoun2Selected)
                    {
                        SelectedRegel = CultnameResult.Noun2;
                    }
                }
            }
            finally
            {
                TimeStamp = DateTime.Now.ToLocalTime();
                _SkipUpdates = false;
                UpdateCultname();
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
                    _SkipUpdates = true;

                    isDefiniteArticleSelected = CultnameResult.DefiniteArticle?.Equals(SelectedRegel) == true;
                    isAdjective1Selected = CultnameResult.Adjective1?.Equals(SelectedRegel) == true;
                    isAdjective2Selected = CultnameResult.Adjective2?.Equals(SelectedRegel) == true;
                    isNoun1Selected = CultnameResult.Noun1?.Equals(SelectedRegel) == true;
                    isNoun2Selected = CultnameResult.Noun2?.Equals(SelectedRegel) == true;

                    ThingyDexer.Model.Table.CultnameResult cultnameResult =
                            CultnameTableSet.GenerateName(CultnameResult,
                                        Settings.IncludeRandomDefiniteArticle,
                                        Settings.CultnameInputType ?? Model.General.CultnameInputType.TemplateAdjective1Noun1OfTheAdjective2Noun2);
                    CultnameResult = cultnameResult;
                }
                finally
                {
                    TimeStamp = DateTime.Now.ToLocalTime();

                    if (isDefiniteArticleSelected)
                    {
                        SelectedRegel = CultnameResult.DefiniteArticle;
                    }

                    if (isAdjective1Selected)
                    {
                        SelectedRegel = CultnameResult.Adjective1;
                    }

                    if (isAdjective2Selected)
                    {
                        SelectedRegel = CultnameResult.Adjective2;
                    }

                    if (isNoun1Selected)
                    {
                        SelectedRegel = CultnameResult.Noun1;
                    }

                    if (isNoun2Selected)
                    {
                        SelectedRegel = CultnameResult.Noun2;
                    }

                    _SkipUpdates = false;
                    UpdateCultname();

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
                    bool isDefiniteArticleSelected = (item?.Owner != null) && (CultnameResult.DefiniteArticle?.Owner.Equals(item.Owner) == true);
                    bool isAdjective1Selected = (item?.Owner != null) && (CultnameResult.Adjective1?.Owner.Equals(item.Owner) == true);
                    bool isAdjective2Selected = (item?.Owner != null) && (CultnameResult.Adjective2?.Owner.Equals(item.Owner) == true);
                    bool isNoun1Selected = (item?.Owner != null) && (CultnameResult.Noun1?.Owner.Equals(item.Owner) == true);
                    bool isNoun2Selected = (item?.Owner != null) && (CultnameResult.Noun2?.Owner.Equals(item.Owner) == true);

                    if ((CultnameResult.DefiniteArticle != null) && isDefiniteArticleSelected)
                    {
                        CultnameResult.DefiniteArticle = item;
                    }

                    if ((CultnameResult.Adjective1 != null) && isAdjective1Selected)
                    {
                        CultnameResult.Adjective1 = item;
                    }

                    if ((CultnameResult.Noun1 != null) && isNoun1Selected)
                    {
                        CultnameResult.Noun1 = item;
                    }

                    if ((CultnameResult.Adjective2 != null) && isAdjective2Selected)
                    {
                        CultnameResult.Adjective2 = item;
                    }

                    if ((CultnameResult.Noun2 != null) && isNoun2Selected)
                    {
                        CultnameResult.Noun2 = item;
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
