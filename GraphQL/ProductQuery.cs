using ProductApi.EFCoreWithCosmos.Database;
using ProductApi.EFCoreWithCosmos.Models;

namespace ProductApi.EFCoreWithCosmos.GraphQL
{
    /// <summary>
    /// Contains the Query resolvers for the Products
    /// 
    /// Note: Fields in the Query type are entry points into the schema. These are
    /// the top-level fields that can be queried by the GraphQL client.
    /// 
    /// A resolver is a function that populates the data for a field in our schema.
    /// </summary>
    public class ProductQuery
    {
        public IQueryable<Product> GetProducts([Service] CosmosDbContext context) =>
               context.Products;
    }
}
