using System.Text.Json.Serialization;

namespace VivaTestLambdaApi.Contracts.Dto
{
    public class UpdateProductRequest
    {
        public Guid Id { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public float Price { get; set; } = default!;


    }
}
