using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.ComponentModel;
using System.Text;
using ThingyDexer.ViewModel.Cult;

namespace ThingyDexer.WASM.Pages.Wizard
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public partial class WizardStep
    {
        /// <summary>
        /// The <see cref="Wizard"/> container
        /// </summary>
        [CascadingParameter] protected internal Wizard Parent { get; set; }

        public EditContext MyContext
        {
            get;
            private set;
        }

        private IEnumerable<DisplayError> _Errors = new List<DisplayError>();
        public IEnumerable<DisplayError> Errors => _Errors;


        [Inject] public IServiceProvider ServiceProvider { get; set; }

        [Parameter]
        public ViewModelBase ViewModel { get; set; }

        [Parameter] public Action? BeforeNextStepAction { get; set; }

        [Parameter] public Action? AfterNextStepAction { get; set; }


        /// <summary>
        /// The Child Content of the current <see cref="WizardStep"/>
        /// </summary>
        [Parameter] public RenderFragment ChildContent { get; set; }

        [Parameter] public RenderFragment Footer { get; set; }

        /// <summary>
        /// The Name of the step
        /// </summary>
        [Parameter] public string Name { get; set; }

        [Parameter] public string Title { get; set; }

        public bool? IsStepValid { get; private set; }

        public void DoValidateModel()
        {
            // if ((IsStepValid == null) || (MyContext?.IsModified() == true))
            {
                var isValid = MyContext?.Validate();

                _Errors = MyContext?.GetValidationMessages().Select(o => new DisplayError(o)).ToList() ?? new List<DisplayError>();

                if (IsStepValid != isValid)
                {
                    IsStepValid = isValid;
                    StateHasChanged();
                }
            }
        }

        protected override void OnInitialized()
        {
            Parent.AddStep(this);
        }

        protected async override Task OnParametersSetAsync()
        {
            await base.OnParametersSetAsync();
            MyContext = new EditContext(ViewModel);
            MyContext.EnableDataAnnotationsValidation(ServiceProvider);
            MyContext.MarkAsUnmodified();
            ViewModel.PropertyChanged += ViewModel_PropertyChanged;
            DoValidateModel();
        }

        private void ViewModel_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            DoValidateModel();
        }
    }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
}