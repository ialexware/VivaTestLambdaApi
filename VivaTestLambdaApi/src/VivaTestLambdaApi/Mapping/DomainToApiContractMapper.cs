using VivaTestLambdaApi.Contracts.Models;
using VivaTestLambdaApi.Contracts.Request;

namespace VivaTestLambdaApi.Mapping
{
    public static class DomainToApiContractMapper
    {
        public static ProductRequest ToCustomerResponse(this Product product)
        {
            return new ProductRequest
            {
                Id = product.Id.Value,
                Name = product.Name.Value,
                Description = product.Description.Value,
                Price = product.Price.Value

            };
        }

    }
}
