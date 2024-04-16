using Grove.Infrastructure.Abstraction;
using Microsoft.Extensions.DependencyInjection;

namespace Grove.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IReadOnlyStorage, ReadOnlyStorage>();

            services.AddScoped<IStorage, Storage>();

            return services;
        }
    }
}
