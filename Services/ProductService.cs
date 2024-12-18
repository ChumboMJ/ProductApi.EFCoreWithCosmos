using ProductApi.EFCoreWithCosmos.Interfaces;
using ProductApi.EFCoreWithCosmos.Models;

namespace ProductApi.EFCoreWithCosmos.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> AddProductAsync(Product product)
        {
            await _productRepository.Add(product);

            return product;
        }

        public async Task<bool> DeleteProductAsync(Guid productId)
        {
            return await _productRepository.Delete(productId);
        }

        public async Task<Product?> GetProductByIdAsync(Guid productId)
        {
            return await _productRepository.GetById(productId);
        }

        public async Task<Product?> UpdateProductAsync(Product product)
        {
            return await _productRepository.Update(product);
        }
    }
}
