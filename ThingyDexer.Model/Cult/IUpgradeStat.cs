namespace ThingyDexer.Model.Cult
{
    public interface IUpgradeStat
    {
        void UpgradeStat(int increase);
    }

    public interface IXpUpdate
    {
        bool SpendXp(int xp);
        void EarnXp(int xp);
    }
}
