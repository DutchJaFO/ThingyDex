using BlazorBootstrap;

namespace ThingyDexer.WASM.General
{
    public static class Randomizer
    {
        private static readonly Random random = new Random();

        private static IconName[] _Dice = new IconName[] {
            BlazorBootstrap.IconName.Dice1,
            BlazorBootstrap.IconName.Dice2,
            BlazorBootstrap.IconName.Dice3,
            BlazorBootstrap.IconName.Dice4,
            BlazorBootstrap.IconName.Dice5,
            BlazorBootstrap.IconName.Dice6,
            BlazorBootstrap.IconName.Dice1Fill,
            BlazorBootstrap.IconName.Dice2Fill,
            BlazorBootstrap.IconName.Dice3Fill,
            BlazorBootstrap.IconName.Dice4Fill,
            BlazorBootstrap.IconName.Dice5Fill,
            BlazorBootstrap.IconName.Dice6Fill,
        };

        public static IconName DiceIcon
        {
            get
            {
                int x = random.Next(0, _Dice.Length); 
                return _Dice[x];
            }
        }
    }
}
