using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.ComponentModel;
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
        public IEnumerable<DisplayError> Errors
        {
            get => _Errors;
            private set => _Errors = value;
        }


        [Inject] public IServiceProvider ServiceProvider { get; set; }


        private ViewModelBase _ViewModel;
        [Parameter]
        public ViewModelBase ViewModel
        {
            get => _ViewModel;
            set {
                if (value != _ViewModel)
                {
                    if (_ViewModel is not null)
                    {
                        _ViewModel.PropertyChanged -= ViewModel_PropertyChanged;
                    }

                    _ViewModel = value;

                    if (_ViewModel is not null)
                    {
                        _ViewModel.PropertyChanged += ViewModel_PropertyChanged;
                        DoValidateModel();
                    }
                }
            }
        }

        [Parameter] public Action? BeforeNextStepAction { get; set; }

        [Parameter] public Action? AfterNextStepAction { get; set; }


        /// <summary>
        /// The Child Content of the current <see cref="WizardStep"/>
        /// </summary>
        [Parameter] public RenderFragment ChildContent { get; set; }

        /// <summary>
        /// unique Id to be used when navigating between steps
        /// </summary>
        [Parameter] public string Id { get; set; }

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
                bool? isValid = MyContext?.Validate();
                int oldErrorCount = Errors?.Count() ?? 0;

                Errors = MyContext?.GetValidationMessages().Select(o => new DisplayError(o)).ToList() ?? new List<DisplayError>();

                int newErrorCount = Errors?.Count() ?? 0;

                if ((IsStepValid != isValid) || (oldErrorCount != newErrorCount))
                {
                    IsStepValid = isValid;
                    StateHasChanged();
                }
            }
        }

        protected override void OnInitialized()
        {
            Parent.AddStep(this);

            MyContext = new EditContext(ViewModel);
            MyContext.EnableDataAnnotationsValidation(ServiceProvider);
            MyContext.MarkAsUnmodified();
            DoValidateModel();
        }

        protected async override Task OnParametersSetAsync()
        {
            await base.OnParametersSetAsync();

        }

        private void ViewModel_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            DoValidateModel();
        }
    }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
}