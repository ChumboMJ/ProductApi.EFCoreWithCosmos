using ProductApi.EFCoreWithCosmos.Interfaces;
using ProductApi.EFCoreWithCosmos.Models;

namespace ProductApi.EFCoreWithCosmos.GraphQL
{
    public class ProductMutation
    {
        public async Task<Product> AddProductAsync(string name, string category, Dimensions dimensions,
            [Service] IProductService productService)
        {
            var product = new Product(Guid.NewGuid())
            {
                Category = category,
                Name = name,
                Dimensions = dimensions
            };

            return await productService.AddProductAsync(product);
        }
    }
}
