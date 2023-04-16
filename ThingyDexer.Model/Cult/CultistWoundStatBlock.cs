namespace ThingyDexer.Model.Cult
{
    public class CultistWoundStatBlock : WoundStatBlock, IUpgradeStat
    {
        #region Constructor

        public CultistWoundStatBlock() : base() { }

        public CultistWoundStatBlock(int value = CultistStatistics.StartWounds) : base(value)
        {
        }

        #endregion Constructor

        #region Public


        public string StatName => "Wounds";

        void IUpgradeStat.UpgradeStat(int increase)
        {
            Value += increase;
        }

        #endregion Public
    }

    public static class CultistUpgradeHelpers
    {
        public static bool CanUpgradeStatCost(this Cultist cultist, StatBlockType type, int increment)
        {
            CultistStatBlockEntry? stat = cultist.StatBlocks.FirstOrDefault(o => o.Type == type);
            if (stat != null)
            {
                int newValue = stat.Value + increment;
                return (newValue >= CultistStatistics.Minimum) && (newValue <= CultistStatistics.Maximum);
            }
            else
            {
                return false;
            }
        }

        public static bool DoUpgradeStat(this Cultist cultist, StatBlockType type, int increment)
        {
            if (cultist.CanUpgradeStatCost(type, increment))
            {
                int? cost = cultist.UpgradeStatCost(type, increment);
                CultistStatBlockEntry? stat = cultist.StatBlocks.FirstOrDefault(o => o.Type == type);
                if (stat != null)
                {
                    if ((cost > 0) && ((cultist as IXpUpdate)?.SpendXp(cost.Value) == true))
                    {
                        (stat as IUpgradeStat).UpgradeStat(increment);
                        return true;
                    }
                }
            }
            return false;
        }

        public static int? UpgradeStatCost(this Cultist cultist, StatBlockType type, int increment)
        {
            if (CanUpgradeStatCost(cultist, type, increment))
                return increment * UpgradeCosts.StatisticUpgrade;
            else
                return null;
        }

        public static bool CanUpgradeWoundCost(this Cultist cultist, int increment)
        {
            CultistWoundStatBlock wounds = cultist.Wounds;
            if (wounds != null)
            {
                int newValue = wounds.Value + increment;
                return (newValue >= CultistStatistics.StartWounds) && (newValue <= CultistStatistics.MaxWounds);
            }
            else
            {
                return false;
            }
        }

        public static int? UpgradeWoundCost(this Cultist cultist, int increment)
        {
            if (CanUpgradeWoundCost(cultist, increment))
                return increment * UpgradeCosts.WoundUpgrade;
            else
                return null;
        }

        public static bool DoUpgradeWounds(this Cultist cultist, int increment)
        {
            if (cultist.CanUpgradeWoundCost(increment))
            {
                int? cost = cultist.UpgradeWoundCost(increment);
                CultistWoundStatBlock stat = cultist.Wounds;
                if (stat != null)
                {
                    if ((cost > 0) && ((cultist as IXpUpdate)?.SpendXp(cost.Value) == true))
                    {
                        (stat as IUpgradeStat).UpgradeStat(increment);
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
