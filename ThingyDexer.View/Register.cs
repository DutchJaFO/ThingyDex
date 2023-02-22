using Microsoft.Extensions.DependencyInjection;

namespace ThingyDexer.View
{
    public static class Register
    {
        public static IServiceCollection AddThingyDexerViews(this IServiceCollection serviceCollection)
        {
            return serviceCollection;
        }

    }
}