namespace ThingyDexer.Model.Cult
{
    public class CultistStatBlockEntry : StatBlockEntry, IUpgradeStat
    {
        #region Constructor

        public CultistStatBlockEntry(StatBlockType statBlockType, int value, int xp) : base(statBlockType, value)
        {
            XpSpent = xp;
        }

        #endregion Constructor

        #region Public

        public int XpSpent { get; private set; }
        public int MinValue { get; init; } = 1;
        public int MaxValue { get; init; } = 5;

        public static int UpgradeCost = 50;

        public string StatName => $"{Type}";

        public bool UpgradeStat(int increase, int xp)
        {
            if (increase < 0) return false;
            if (xp < 0) return false;

            if ((Value + increase) > MaxValue) return false;

            if (xp != GetUpgradeCost(increase)) return false;

            Value += increase;
            XpSpent += xp;
            return true;
        }

        public int GetUpgradeCost(int increase) => increase * UpgradeCost;

        #endregion Public
    }
}
