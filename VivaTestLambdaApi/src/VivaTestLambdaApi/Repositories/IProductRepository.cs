using VivaTestLambdaApi.Contracts.Dto;

namespace VivaTestLambdaApi.Repositories
{
    public interface IProductRepository
    {
        Task<bool> CreateAsync(ProductDto product);

        Task<ProductDto?> GetAsync(Guid id);

        Task<bool> UpdateAsync(ProductDto product);

        Task<bool> DeleteAsync(Guid id);
    }
}
