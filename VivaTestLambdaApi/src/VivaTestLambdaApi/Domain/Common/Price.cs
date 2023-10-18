using FluentValidation;
using FluentValidation.Results;
using ValueOf;

namespace VivaTestLambdaApi.Domain.Common;

public class Price : ValueOf<float, Price>
{
    protected override void Validate()
    {
        if (Value < 0)
        {
            var message = $"{Value} is not a valid price";
            throw new ValidationException(message, new[]
            {
                new ValidationFailure(nameof(Price), message)
            });
        }
    }
}
