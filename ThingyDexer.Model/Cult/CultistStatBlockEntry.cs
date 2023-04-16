namespace ThingyDexer.Model.Cult
{
    public class CultistStatBlockEntry : StatBlockEntry, IUpgradeStat
    {
        #region Constructor

        public CultistStatBlockEntry(StatBlockType statBlockType, int value) : base(statBlockType, value)
        {
        }

        #endregion Constructor

        #region Public
        public string StatName => $"{Type}";

        void IUpgradeStat.UpgradeStat(int increase)
        {
            Value += increase;
        }


        #endregion Public
    }
}
