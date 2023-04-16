using Microsoft.Extensions.DependencyInjection;
using ThingyDexer.ViewModel.Cult;

namespace ThingyDexer.ViewModel
{
    public static class Register
    {
        public static IServiceCollection AddThingyDexerViewModels(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<CultNameGeneratorViewModel>();
            serviceCollection.AddTransient<CultNameSettingsEditModel>();
            return serviceCollection;
        }
    }
}