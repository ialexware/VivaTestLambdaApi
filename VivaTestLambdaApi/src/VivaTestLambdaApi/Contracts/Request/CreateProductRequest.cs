namespace VivaTestLambdaApi.Contracts.Request
{
    public class CreateProductRequest
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public float Price { get; set; } = default!;
    }
}
