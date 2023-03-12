using Microsoft.Extensions.DependencyInjection;
using ThingyDexer.Model.Table;

namespace ThingyDexer.Model
{
    public static class Register
    {
        public static IServiceCollection AddThingyDexerModels(this IServiceCollection serviceCollection)
        {
            return serviceCollection.AddSingleton<Random>((s) => new Random())
                                    .AddScoped(implementationFactory: (s) => CultnameTableFactory.Create(new Random()));
        }
    }
}