namespace ThingyDexer.Model.Cult
{
    public class Cult : IXpUpdate
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

        public int Power { get; set; }
        public int Favour { get; set; }
        public int FavourSpent { get; private set; }
        public StatBlockType? FavouredStat { get; set; }

        private readonly List<Cultist> _ActiveCultists = [];
        public IEnumerable<Cultist> ActiveCultists => _ActiveCultists;

        private readonly List<Cultist> _DeadCultists = [];
        public IEnumerable<Cultist> DeadCultists => _DeadCultists;

        void IXpUpdate.EarnXp(int xp)
        {
            Favour += xp;
        }

        bool IXpUpdate.SpendXp(int xp)
        {
            if (Favour >= xp)
            {
                Favour -= xp;
                FavourSpent += xp;
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
