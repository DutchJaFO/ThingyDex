using Microsoft.Extensions.DependencyInjection;
using ThingyDexer.Model.Table;

namespace ThingyDexer.Model
{
    public static class Register
    {
        public static IServiceCollection AddThingyDexerModels(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<Random>((s) => new Random());
            serviceCollection.AddScoped<CultnameTableSet>((s) => CultnameTableFactory.Create());
            return serviceCollection;
        }
    }
}