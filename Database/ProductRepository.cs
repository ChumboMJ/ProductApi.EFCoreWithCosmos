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

        public async Task<Product?> GetById(Guid productId)
        {
            return await LoadProductWithReferences(productId);
        }

        //This will update the Product along with related data in other containers
        //We must also load the related data from the Inventory and Suppliers containers
        public async Task<Product?> Update(Product product)
        {
            var existingProduct = await LoadProductWithReferences(product.ProductId);

            if (existingProduct == null) return null;

            existingProduct.Name = product.Name;
            existingProduct.Category = product.Category;
            existingProduct.Dimensions = product.Dimensions;
            existingProduct.ShippingOptions = product.ShippingOptions;
            existingProduct.Suppliers = product.Suppliers;
            existingProduct.Inventory = product.Inventory;

            await _dbContext.SaveChangesAsync();

            return product;
        }

        public Task<bool> Delete(Guid productId)
        {
            throw new NotImplementedException();
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
    }
}
