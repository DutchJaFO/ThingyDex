using Microsoft.AspNetCore.Components;
using ThingyDexer.Model.Table;
using ThingyDexer.ViewModel.Table;

namespace ThingyDexer.WASM.Pages
{
    public partial class CreateCult
    {
        public CreateCult()
        {
            Cultname = null;
        }

        private void GenerateCultName()
        {
            if (CultnameTableSet is null) return;

            (bool Spiffy, TableRowBase<string>[] Data)? oldName = Cultname;
            bool newName = (oldName is null);
            if (oldName != null)
            {
                if (oldName.Value.Spiffy != Spiffy)
                {
                    newName = false;
                    if (Spiffy)
                    {
                        // [x] of the [y] [z]
                        // add extra entry 
                        (bool Spiffy, TableRowBase<string>[] Data) x = oldName.Value;
                        List<TableRowBase<string>> set = new(x.Data);
                        TableRowBase<string> extra = this.CultnameTableSet.PrefixNameTable.GetRandomItem();
                        // [what happens if this is identical ?] extra = this.CultnameTableSet.PrefixNameTable.GetRow(x.Data[1].Index);
                        set.Insert(0, extra);
                        Cultname = new(Spiffy, set.ToArray());

                    }
                    else
                    {
                        // [a] [x] of the [y] [z]
                        // remove extra entry
                        (bool Spiffy, TableRowBase<string>[] Data) x = oldName.Value;
                        Cultname = new(Spiffy, x.Data.Skip(1).ToArray());

                        if ((SelectedRegel?.Id == x.Data[0].Index) && (SelectedRegel.Source == x.Data[0].Owner))
                        {
                            SelectedRegel = null;
                        }

                    }
                }
                else
                {
                    newName = true;
                }
            }
            if (newName)
            {
                Cultname = this.CultnameTableSet?.GetValueSet(Spiffy);
            }
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
        public RegelString[] DisplayDetails
        {
            get
            {
                (bool Spiffy, TableRowBase<string>[] Data)? d = Cultname;
                List<string> result = new();
                if (d.HasValue)
                {
                    return (d.Value.Data.Select(o => new RegelString() { Source = o.Owner, Id = o.Index, Name = o.Value ?? "" })).ToArray();
                }
                else
                {
                    return Array.Empty<RegelString>();
                }
            }
        }

        private bool _ShowDetails;
        public bool ShowDetails
        {
            get => _ShowDetails;
            set { _ShowDetails = value; StateHasChanged(); }
        }


        public RegelString? SelectedRegel { get; set; }

        protected void OnClickWithArgs(EventArgs args, RegelString data)
        {
            if ((SelectedRegel != null) && SelectedRegel.Equals(data))
            {
                SelectedRegel = null;
            }
            else
            {
                SelectedRegel = data;
            }
            StateHasChanged();
        }
    }
}