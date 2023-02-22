using Microsoft.AspNetCore.Components;
using ThingyDexer.Model.Tabel;

namespace ThingyDexer.WASM.Pages
{
    public partial class CreateCult
    {
        public CreateCult()
        {
            Cultname = string.Empty;
        }

        private void GenerateCultName()
        {
            Cultname = this.CultnameTableSet?.GetValue(Spiffy) ?? "";
            TimeStamp = DateTime.Now.ToLocalTime();
            StateHasChanged();
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            /*
            if (string.IsNullOrEmpty(Cultname))
            {
                GenerateCultName();
            }
            */
        }

        [Inject]
        public CultnameTableSet? CultnameTableSet { get; set; }

        public DateTime? TimeStamp { get; private set; }

        public bool Spiffy { get; set; }
        public string Cultname { get; set; }
    }
}