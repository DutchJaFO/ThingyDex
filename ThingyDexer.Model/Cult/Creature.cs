namespace ThingyDexer.Model.Cult
{
    public class Creature
    {
        #region Constructor

        public Creature(string name, int strength, int dexterity, int intelligence, int defense, int wounds)
        {
            Name = name;

            StatBlocks.Add(new StatBlockEntry(StatBlockType.Strength, strength));
            StatBlocks.Add(new StatBlockEntry(StatBlockType.Dexterity, dexterity));
            StatBlocks.Add(new StatBlockEntry(StatBlockType.Intelligence, intelligence));
            StatBlocks.Add(new StatBlockEntry(StatBlockType.Defense, defense));

            Wounds = new WoundStatBlock(wounds);
        }

        #endregion Constructor

        #region Public

        public string Name { get; set; }
        public HashSet<StatBlockEntry> StatBlocks { get; private set; } = new HashSet<StatBlockEntry>();
        public WoundStatBlock Wounds { get; private set; } = new WoundStatBlock();

        #endregion Public
    }
}
