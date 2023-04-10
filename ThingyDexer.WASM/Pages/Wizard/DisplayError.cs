namespace ThingyDexer.WASM.Pages.Wizard
{
    public class DisplayError
    {
        public DisplayError(string text)
        {
            Text = text;
        }

        public string Text { get; init; }
    }
}