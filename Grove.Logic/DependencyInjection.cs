﻿using Grove.Logic.Abstraction;
using Grove.Logic.Services;
using Mapster;
using Microsoft.Extensions.DependencyInjection;

namespace Grove.Logic
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddLogic(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductCategoryService, ProductCategoryService>();
            services.AddScoped<IAuthService, AuthService>();

            services.AddMapster();

            return services;
        }
    }
}
