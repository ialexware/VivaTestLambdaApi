using VivaTestLambdaApi.Domain.Common;

namespace VivaTestLambdaApi.Contracts.Models
{
    public class Product
    {
        public ProductId Id { get; init; } = ProductId.From(Guid.NewGuid());
        public Name Name { get; set; } = default!;
        public Description Description { get; set; } = default!;
        public Price Price { get; set; } = default!;
    }
}
