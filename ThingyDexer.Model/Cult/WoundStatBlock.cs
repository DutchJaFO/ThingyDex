namespace ThingyDexer.Model.Cult
{
    public class WoundStatBlock
    {
        #region Constructor

        public WoundStatBlock(int value = 10)
        {
            Value = value;
        }

        #endregion Constructor

        #region Public
        public int Value { get; protected set; }
        #endregion Public
    }
}
