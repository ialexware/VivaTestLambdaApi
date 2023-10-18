using ValueOf;

namespace VivaTestLambdaApi.Domain.Common;

public class ProductId : ValueOf<Guid, ProductId>
{
    protected override void Validate()
    {
        if (Value == Guid.Empty)
        {
            throw new ArgumentException("Product ID cannot be empty", nameof(ProductId));
        }
    }
}
