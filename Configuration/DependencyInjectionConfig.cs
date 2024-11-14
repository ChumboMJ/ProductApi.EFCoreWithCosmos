using ProductApi.EFCoreWithCosmos.Database;
using ProductApi.EFCoreWithCosmos.Interfaces;
using ProductApi.EFCoreWithCosmos.Services;

namespace CosmosDbEfCoreDemo.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<CosmosDbContext>();

            services.AddScoped<IProductService, ProductService>();

            services.AddScoped<IProductRepository, ProductRepository>();

            return services;
        }
    }
}