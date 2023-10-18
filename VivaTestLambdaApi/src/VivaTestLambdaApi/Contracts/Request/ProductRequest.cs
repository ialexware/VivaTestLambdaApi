using System.Text.Json.Serialization;

namespace VivaTestLambdaApi.Contracts.Request
{
    public class ProductRequest
    {

        public Guid Id { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public float Price { get; set; } = default!;

    }
}
