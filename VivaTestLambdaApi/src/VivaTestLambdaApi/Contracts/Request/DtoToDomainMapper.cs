using System.Net.Mail;
using VivaTestLambdaApi.Contracts.Dto;
using VivaTestLambdaApi.Contracts.Models;
using VivaTestLambdaApi.Domain.Common;

namespace VivaTestLambdaApi.Contracts.Request
{
    public static class DtoToDomainMapper
    {
        public static Product ToProduct(this ProductDto productDto)
        {
            return new Product
            {
                Id = ProductId.From(Guid.Parse(productDto.Id)),
                Name = Name.From(productDto.Name),
                Description = Description.From(productDto.Description),
                Price = Price.From(productDto.Price)

            };
        }
    }
}
