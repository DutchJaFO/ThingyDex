﻿namespace ThingyDexer.Model.Cult
{
    public class StatBlockEntry
    {
        #region Constructor

        public StatBlockEntry(StatBlockType type, int value = CultistStatistics.Minimum)
        {
            Type = type;
            Value = value;
        }

        #endregion Constructor

        #region Public

        public StatBlockType Type { get; init; }
        public int Value { get; protected set; }

        #endregion Public
    }
}
