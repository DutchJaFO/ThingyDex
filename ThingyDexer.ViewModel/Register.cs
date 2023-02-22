using Microsoft.Extensions.DependencyInjection;

namespace ThingyDexer.ViewModel
{
    public static class Register
    {
        public static IServiceCollection AddThingyDexerViewModels(this IServiceCollection serviceCollection)
        {
            return serviceCollection;
        }
    }
}