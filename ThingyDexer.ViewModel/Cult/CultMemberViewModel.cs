using System.ComponentModel.DataAnnotations;
using ThingyDexer.Model.Cult;

namespace ThingyDexer.ViewModel.Cult
{
    public class CultMemberViewModel : ViewModelBase
    {
        public bool IsEmpty { get; private set; }

        public CultMemberViewModel()
        {
            IsEmpty = true;
        }

        private string _Name = string.Empty;
        [Required]
        public string Name
        {
            get => _Name;
            set
            {
                if (SetField(ref _Name, value))
                {
                    IsEmpty = string.IsNullOrEmpty(_Name);
                }
            }
        }

        private CultistWoundStatBlock _Wounds = new();
        public CultistWoundStatBlock Wounds
        {
            get => _Wounds;
            set => SetField(ref _Wounds, value);
        }

        private CultistStatBlockEntry _Strength = new(StatBlockType.Strength, 0);
        public CultistStatBlockEntry Strength
        {
            get => _Strength;
            set => SetField(ref _Strength, value);
        }

        private CultistStatBlockEntry _Dexterity = new(StatBlockType.Dexterity, 0);
        public CultistStatBlockEntry Dexterity
        {
            get => _Dexterity;
            set => SetField(ref _Dexterity, value);
        }

        private CultistStatBlockEntry _Defense = new(StatBlockType.Defense, 0);
        public CultistStatBlockEntry Defense
        {
            get => _Defense;
            set => SetField(ref _Defense, value);
        }

        private int? _XpEarnt;
        public int? XpEarnt
        {
            get => _XpEarnt;
            set => SetField(ref _XpEarnt, value);
        }

        private int? _XpSpent;
        public int? XpSpent 
        {
            get => _XpSpent;
            set => SetField(ref _XpSpent, value);
    }

}
}
