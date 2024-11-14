using Microsoft.EntityFrameworkCore;
using ProductApi.EFCoreWithCosmos.Interfaces;
using ProductApi.EFCoreWithCosmos.Models;

namespace ProductApi.EFCoreWithCosmos.Database
{
    public class ProductRepository : IProductRepository
    {
        private readonly CosmosDbContext _dbContext;

        public ProductRepository(CosmosDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(Product product)
        {
            _dbContext.Add(product);

            await _dbContext.SaveChangesAsync();
        }

        public Task<bool> Delete(Guid productId)
        {
            throw new NotImplementedException();
        }

        public async Task<Product?> GetById(Guid productId)
        {
            return await LoadProductWithReferences(productId);
        }

        private async Task<Product?> LoadProductWithReferences(Guid productId)
        {
            var product = await _dbContext
                .Products
                .FindAsync(productId);

            if (product == null) return null;

            var productEntry = _dbContext.Products.Entry(product);

            //Include Inventory from Inventory container
            await productEntry
                .Reference(p => p.Inventory)
                .LoadAsync();

            //Include Supplier from Suppliers container
            await productEntry
                .Reference(p => p.Suppliers)
                .LoadAsync();

            return product;
        }

        public Task<Product?> Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
