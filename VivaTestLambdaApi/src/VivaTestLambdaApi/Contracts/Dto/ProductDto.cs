using System.Text.Json.Serialization;

namespace VivaTestLambdaApi.Contracts.Dto
{
    public class ProductDto
    {
        [JsonPropertyName("pk")]
        public string Pk => Id;
        [JsonPropertyName("sk")]
        public string Sk => Id;
        public string Id { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public float Price { get; set; } = default!;

    }
}
