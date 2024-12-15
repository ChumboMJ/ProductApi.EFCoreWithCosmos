using GraphQL.Types;
using ProductApi.EFCoreWithCosmos.Database;
using ProductApi.EFCoreWithCosmos.GraphQL;
using ProductApi.EFCoreWithCosmos.Interfaces;
using ProductApi.EFCoreWithCosmos.Models;
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

            //Totorial: https://www.apollographql.com/tutorials/intro-hotchocolate/05-apollo-explorer
            //Allow apollo to be used
            services.AddCors(options =>
                {
                    options.AddDefaultPolicy(builder =>
                    {
                        builder
                            .WithOrigins("https://studio.apollographql.com")
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
                });

            return services;
        }
    }
}