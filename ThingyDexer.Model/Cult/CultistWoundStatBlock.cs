namespace ThingyDexer.Model.Cult
{
    public class CultistWoundStatBlock : WoundStatBlock, IUpgradeStat
    {
        #region Constructor

        public CultistWoundStatBlock() : base() { }

        public CultistWoundStatBlock(int value = 10, int xp = 0) : base(value)
        {
            XpSpent = xp;
        }

        #endregion Constructor

        #region Public

        public int XpSpent { get; private set; }
        public int MinValue { get; init; } = 1;
        public int MaxValue { get; init; } = 5;

        public string StatName => "Wounds";

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
        public int GetUpgradeCost(int increase) => increase * UpgradeCosts.WoundUpgrade;

        #endregion Public
    }
}
