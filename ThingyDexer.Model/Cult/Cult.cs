namespace ThingyDexer.Model.Cult
{
    public class Cult
    {
        #region Constructor

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public Cult() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public Cult(string name, string description, string worshippedEntity, StatBlockType? favouredStat)
        {
            Name = name;
            Description = description;
            WorshippedEntity = worshippedEntity;
            FavouredStat = favouredStat;
        }
        #endregion

        public string Name { get; set; }
        public string Description { get; set; }
        public string WorshippedEntity { get; set; }

        public StatBlockType? FavouredStat { get; set; }

        public List<Cultist> ActiveCultists { get; set; } = new();
        public List<Cultist> DeadCultists { get; set; } = new();
    }
}
