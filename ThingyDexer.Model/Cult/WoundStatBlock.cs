namespace ThingyDexer.Model.Cult
{
    public class WoundStatBlock
    {
        #region Constructor

        public WoundStatBlock(int value = CultistStatistics.StartWounds)
        {
            Value = value;
        }

        #endregion Constructor

        #region Public
        public int Value { get; protected set; }

        #endregion Public
    }
}
