using ProductApi.EFCoreWithCosmos.Interfaces;
using ProductApi.EFCoreWithCosmos.Models;

namespace ProductApi.EFCoreWithCosmos.Database
{
    public class ProductRepository : IProductRepository
    {
        public Task Add(Product product)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Guid productId)
        {
            throw new NotImplementedException();
        }

        public Task<Product?> GetById(Guid productId)
        {
            throw new NotImplementedException();
        }

        public Task<Product?> Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
