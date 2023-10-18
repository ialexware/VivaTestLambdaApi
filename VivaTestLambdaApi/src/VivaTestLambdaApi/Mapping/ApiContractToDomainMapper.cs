using System.Net.Mail;
using VivaTestLambdaApi.Contracts.Dto;
using VivaTestLambdaApi.Contracts.Models;
using VivaTestLambdaApi.Contracts.Request;
using VivaTestLambdaApi.Domain.Common;

namespace VivaTestLambdaApi.Mapping
{
    public static class ApiContractToDomainMapper
    {
        public static Product ToProduct(this CreateProductRequest request)
        {
            return new Product
            {
                Id = ProductId.From(Guid.NewGuid()),
                Name = Name.From(request.Name),
                Description = Description.From(request.Description),
                Price = Price.From(request.Price)
            };
        }

        public static Product ToProduct(this UpdateProductRequest request)
        {
            return new Product
            {
                Id = ProductId.From(request.Id),
                Name = Name.From(request.Name),
                Description = Description.From(request.Description),
                Price = Price.From(request.Price)

            };
        }
    }
}
