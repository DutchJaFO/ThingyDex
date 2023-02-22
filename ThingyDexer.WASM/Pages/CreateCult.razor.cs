using Microsoft.AspNetCore.Components;
using System.Runtime.CompilerServices;
using System.Text;
using ThingyDexer.Model.Tabel;

namespace ThingyDexer.WASM.Pages
{
    public struct Regel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public partial class CreateCult
    {
        public CreateCult()
        {
            Cultname = null;
        }

        private void GenerateCultName()
        {
            Cultname = this.CultnameTableSet?.GetValueSet(Spiffy);
            TimeStamp = DateTime.Now.ToLocalTime();
            StateHasChanged();
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
        }

        [Inject]
        public CultnameTableSet? CultnameTableSet { get; set; }

        public DateTime? TimeStamp { get; private set; }

        public bool Spiffy { get; set; }
        public (bool Spiffy, TableRowBase<string>[] Data)? Cultname { get; set; }

        public string Displayname
        {
            get
            {
                (bool Spiffy, TableRowBase<string>[] Data)? d = Cultname;
                return
                    ((d?.Spiffy) == true)
                        ? $"{d?.Data[0].Value} {d?.Data[1].Value} of the {d?.Data[2].Value} {d?.Data[3].Value}"
                        : $"{d?.Data[0].Value} of the {d?.Data[1].Value} {d?.Data[2].Value}";
            }
        }
        public Regel[] DisplayDetails
        {
            get
            {
                (bool Spiffy, TableRowBase<string>[] Data)? d = Cultname;
                List<string> result = new();
                if (d.HasValue)
                {
                    return (d.Value.Data.Select(o => new Regel() { Id = o.Index, Name = o.Value ?? "" })).ToArray();
                }
                else
                {
                    return Array.Empty<Regel>();
                }
            }
        }

        private bool _ShowDetails;
        public bool ShowDetails
        {
            get => _ShowDetails;
            set { _ShowDetails = value; StateHasChanged(); }
        }
    }
}