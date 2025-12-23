namespace ThingyDexer.Model.Cult
{
    public class Cultist : IXpUpdate
    {
        #region Constructor

        public Cultist(Cult cult, string name, string description, int strength, int dexterity, int intelligence, int defense, int wounds)
        {
            Cult = cult;
            Name = name;
            Description = description;

            StatBlocks.Add(new CultistStatBlockEntry(StatBlockType.Strength, strength));
            StatBlocks.Add(new CultistStatBlockEntry(StatBlockType.Dexterity, dexterity));
            StatBlocks.Add(new CultistStatBlockEntry(StatBlockType.Intelligence, intelligence));
            StatBlocks.Add(new CultistStatBlockEntry(StatBlockType.Defense, defense));

            Wounds = new CultistWoundStatBlock(wounds);
        }

        #endregion Constructor

        #region Public
        public Cult Cult { get; private set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public CultistWoundStatBlock Wounds { get; set; }
        public HashSet<CultistStatBlockEntry> StatBlocks { get; private set; } = [];

        public int XpEarnt { get; private set; }
        public int XpSpent { get; private set; }

        public void EarnXp(int xp)
        {
            ((IXpUpdate)Cult).EarnXp(xp);
        }

        public bool SpendXp(int xp)
        {
            return ((IXpUpdate)Cult).SpendXp(xp);
        }

        #endregion Public
    }
}
