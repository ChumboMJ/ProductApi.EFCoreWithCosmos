using ProductApi.EFCoreWithCosmos.Models;

namespace ProductApi.EFCoreWithCosmos.Interfaces
{
    public interface IProductRepository
    {
        public interface IProductRepository
        {
            Task Add(Product product);
            Task<Product?> GetById(Guid productId);
            Task<Product?> Update(Product product);
            Task<bool> Delete(Guid productId);
        }
    }
}
