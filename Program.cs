
using Azure.Identity;
using CosmosDbEfCoreDemo.API.Configuration;
using Microsoft.EntityFrameworkCore;
using ProductApi.EFCoreWithCosmos.Database;
using ProductApi.EFCoreWithCosmos.GraphQL;
using System.Security.Cryptography.X509Certificates;

var builder = WebApplication.CreateBuilder(args);

ConfigureKeyVault(builder);

// Add services to the container.
builder.Services.AddDbContextFactory<CosmosDbContext>(optionsBuilder =>
    optionsBuilder
        .UseCosmos(
            connectionString: builder.Configuration.GetConnectionString("DefaultConnection"),
            databaseName: "SampleInventory",
            cosmosOptionsAction: options =>
            {
                options.ConnectionMode(Microsoft.Azure.Cosmos.ConnectionMode.Direct);
                options.MaxRequestsPerTcpConnection(16);
                options.MaxTcpConnectionsPerEndpoint(32);
            }));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Configure GraphQL
builder.Services.AddGraphQLServer()
                .AddQueryType<ProductQuery>()
                .AddMutationType<ProductMutation>();

builder.Services.ResolveDependencies();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();
app.UseAuthorization();

app.MapGraphQL();
app.MapControllers();

app.Run();
        

/// <summary>
/// Set up Azure Key Vault if a KeyVault name is provided in the configuration
/// </summary>
/// <param name="builder">WebApplicationBuilder</param>
void ConfigureKeyVault(WebApplicationBuilder builder)
{
    if (!string.IsNullOrEmpty(builder.Configuration.GetSection("KeyVault")["Name"]))
    {
        using var x509Store = new X509Store(StoreLocation.LocalMachine);
        x509Store.Open(OpenFlags.ReadOnly);

        var x509Certificate = x509Store.Certificates
            .Find(
                X509FindType.FindByThumbprint,
                builder.Configuration.GetSection("KeyVault").GetSection("AzureAd")["CertificateThumbprint"],
                validOnly: false)
            .OfType<X509Certificate2>()
            .Single();

        builder.Configuration.AddAzureKeyVault(
            new Uri($"https://{builder.Configuration.GetSection("KeyVault")["Name"]}.vault.azure.net/"),
            new ClientCertificateCredential(
                    builder.Configuration.GetSection("KeyVault").GetSection("AzureAd")["DirectoryId"],
                    builder.Configuration.GetSection("KeyVault").GetSection("AzureAd")["ApplicationId"],
                    x509Certificate));
    }
}