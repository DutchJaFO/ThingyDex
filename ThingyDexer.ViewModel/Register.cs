using Microsoft.Extensions.DependencyInjection;
using ThingyDexer.ViewModel.Cult;

namespace ThingyDexer.ViewModel
{
    public static class Register
    {
        public static IServiceCollection AddThingyDexerViewModels(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<CultNameGeneratorViewModel>();
            serviceCollection.AddTransient<CultNameSettingsViewModel>();
            serviceCollection.AddTransient<CultDefinitionViewModel>((s) => 
                        {
                            CultRitualsViewModel rituals = new();
                            CultDefinitionViewModel data = new CultDefinitionViewModel(rituals);
                            return data;
                        });
            serviceCollection.AddTransient<CultRitualsViewModel>((s) =>
                        {
                            CultRitualsViewModel data = new();
                            /*
                            CultRitualViewModel ritual = CultRitualViewModel.Create();
                            ritual.Name = "TEST";
                            data.Rituals.Add(ritual);
                            */
                            return data;
                        });

            return serviceCollection;
        }
    }
}