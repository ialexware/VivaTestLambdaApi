using VivaTestLambdaApi.Contracts.Dto;
using VivaTestLambdaApi.Contracts.Models;

namespace VivaTestLambdaApi.Mapping
{
    public static class DomainToDtoMapper
    {
        public static ProductDto ToProductDto(this Product customer)
        {
            return new ProductDto
            {
                Id = customer.Id.Value.ToString(),
                Name = customer.Name.Value,
                Description = customer.Description.Value,
                Price = customer.Price.Value
            };
        }
    }
}
