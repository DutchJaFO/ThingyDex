using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using ThingyDexer.ViewModel.Cult;

namespace ThingyDexer.WASM.Pages.Wizard.Steps
{
    public partial class CultDefinition
    {
        #region Protected

        protected EditContext? MyContext
        {
            get;
            private set;
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();

            MyContext = new EditContext(ViewModel);
            MyContext.EnableDataAnnotationsValidation(ServiceProvider);
            MyContext.MarkAsUnmodified();
        }
        protected override void OnParametersSet()
        {
            base.OnParametersSet();

           //  ViewModel ??= new();
           // 
           //  MyContext = new EditContext(ViewModel);
           //   MyContext.EnableDataAnnotationsValidation(ServiceProvider);
        }

        protected void DoOnValidSubmit()
        {
            // Foutmelding = "Alles Ok";
            StateHasChanged();
        }

        protected void DoOnInvalidSubmit()
        {
            // Foutmelding = "Er ging iets mis";
            StateHasChanged();
        }

        protected void DoStuffChanged(int a)
        {
            ViewModel.StartingFavour = a;
            StateHasChanged();
            // if (MyContext is not null)
            // {
            //     var fieldIdentifier = new FieldIdentifier(MyContext.Model, nameof(ViewModel.StartingFavour));
            // 
            //     // Validate the field when notifying change
            //     MyContext.NotifyFieldChanged(fieldIdentifier);
            // 
            //     var d = MyContext.GetValidationMessages(fieldIdentifier).ToArray();
            // }
        }

        #endregion Protected


#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        [Inject] public IServiceProvider ServiceProvider { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        [Parameter, EditorRequired]
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public CultDefinitionViewModel ViewModel
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            get;
            set;
        } 

    }
}