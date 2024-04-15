using Grove.Infrastructure.Abstraction;
using Microsoft.Extensions.DependencyInjection;

namespace Grove.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<IReadOnlyStorage, ReadOnlyStorage>();

            services.AddSingleton<IStorage, Storage>();

            return services;
        }
    }
}
