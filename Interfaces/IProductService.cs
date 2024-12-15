using ProductApi.EFCoreWithCosmos.Models;

namespace ProductApi.EFCoreWithCosmos.Interfaces
{
    public interface IProductService
    {
        Task<Product> Add(Product product);
        Task<Product?> GetById(Guid productId);
        Task<Product?> Update(Product product);
        Task<bool> Delete(Guid productId);
    }
}
