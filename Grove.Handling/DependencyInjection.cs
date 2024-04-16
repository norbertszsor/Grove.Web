using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Grove.Handling
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddHandling(this IServiceCollection services)
        {
            services.AddMediatR(options =>
            {
                options.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                options.Lifetime = ServiceLifetime.Scoped;
            });

            return services;
        }   
    }
}
