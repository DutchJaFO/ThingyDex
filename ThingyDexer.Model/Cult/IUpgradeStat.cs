namespace ThingyDexer.Model.Cult
{
    public interface IUpgradeStat
    {
        string StatName { get; }
        int MinValue { get; }
        int MaxValue { get; }
        bool UpgradeStat(int increase, int xp);

        int GetUpgradeCost(int increase);
    }
}
