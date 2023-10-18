using VivaTestLambdaApi.Contracts.Models;

namespace VivaTestLambdaApi.Service
{
    public interface IProductService
    {
        Task<bool> CreateAsync(Product product);

        Task<Product?> GetAsync(Guid id);

        Task<bool> UpdateAsync(Product product);

        Task<bool> DeleteAsync(Guid id);
    }
}
