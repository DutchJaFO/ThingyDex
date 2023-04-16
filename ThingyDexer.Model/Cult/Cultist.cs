namespace ThingyDexer.Model.Cult
{
    public class Cultist
    {
        #region Constructor

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public Cultist() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public Cultist(string name, string description, int strength, int dexterity, int intelligence, int defense, int wounds)
        {
            Name = name;
            Description = description;

            StatBlocks.Add(new CultistStatBlockEntry(StatBlockType.Strength, strength, (strength * 50)));
            StatBlocks.Add(new CultistStatBlockEntry(StatBlockType.Dexterity, dexterity, (dexterity * 50)));
            StatBlocks.Add(new CultistStatBlockEntry(StatBlockType.Intelligence, intelligence, (intelligence * 50)));
            StatBlocks.Add(new CultistStatBlockEntry(StatBlockType.Defense, defense, (defense * 50)));

            Wounds = new CultistWoundStatBlock(wounds, (wounds * 75));
        }

        #endregion Constructor

        #region Public
        public string Name { get; set; }
        public string Description { get; set; }
        public CultistWoundStatBlock Wounds { get; set; }
        public HashSet<CultistStatBlockEntry> StatBlocks { get; private set; } = new HashSet<CultistStatBlockEntry>();
        #endregion Public
    }
}
