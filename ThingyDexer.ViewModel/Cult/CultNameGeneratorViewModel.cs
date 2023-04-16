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
        private void UpdateCultname()
        {
            if (_SkipUpdates) return;
            ValidCultname = ((Noun1 != null) || (Noun2 != null)) ? true : null;

            string? noun1 =
                  (Settings.CultnameInputType == CultnameInputType.TemplateAdjective2PossessiveNoun2Adjective1Noun1)
                    ? MakePossessive(Noun1?.Value)
                    : Noun1?.Value;

            string nameStep1 = $"{DefiniteArticle?.Value} {Adjective1?.Value} {noun1}".Trim();
            string nameStep2 = $"{Adjective2?.Value} {Noun2?.Value}".Trim();
            if ((Noun1 is not null) && (Noun2 is not null) && (Settings.CultnameInputType != CultnameInputType.TemplateAdjective2PossessiveNoun2Adjective1Noun1))
                Cultname = $"{nameStep1} of the {nameStep2}".Trim();
            else
                Cultname = $"{nameStep1} {nameStep2}".Trim();
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
                return (Adjective1 != null) || (Noun1 != null) || (Adjective2 != null) || (Noun2 != null);
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

        private TableRowBase<string>? _DefiniteArticle;
        public TableRowBase<string>? DefiniteArticle
        {
            get => _DefiniteArticle;
            set
            {
                SetField(ref _DefiniteArticle, value);
                UpdateCultname();
            }

        }

        private TableRowBase<string>? _Adjective1;
        public TableRowBase<string>? Adjective1
        {
            get => _Adjective1;
            set
            {
                SetField(ref _Adjective1, value);
                UpdateCultname();
            }
        }

        private TableRowBase<string>? _Noun1;
        public TableRowBase<string>? Noun1
        {
            get => _Noun1;
            set
            {
                SetField(ref _Noun1, value);
                UpdateCultname();
            }
        }

        private TableRowBase<string>? _Adjective2;
        public TableRowBase<string>? Adjective2
        {
            get => _Adjective2;
            set
            {
                SetField(ref _Adjective2, value);
                UpdateCultname();
            }
        }

        private TableRowBase<string>? _Noun2;
        public TableRowBase<string>? Noun2
        {
            get => _Noun2;
            set
            {
                SetField(ref _Noun2, value);
                UpdateCultname();
            }
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
                DefiniteArticle = null;
                Adjective1 = null;
                Adjective2 = null;
                Noun1 = null;
                Noun2 = null;

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
            bool isDefiniteArticleSelected = DefiniteArticle?.Equals(SelectedRegel) == true;

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
                _SkipUpdates = true;
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
                                        Settings.IncludeRandomDefiniteArticle,
                                        Settings.CultnameInputType ?? Model.General.CultnameInputType.TemplateAdjective1Noun1OfTheAdjective2Noun2);
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
