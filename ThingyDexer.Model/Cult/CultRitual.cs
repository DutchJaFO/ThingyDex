namespace ThingyDexer.Model.Cult
{
    public class CultRitual
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool Passive { get; set; } = false;
        public int RitualPoints { get; set; } = 0;
    }
}
