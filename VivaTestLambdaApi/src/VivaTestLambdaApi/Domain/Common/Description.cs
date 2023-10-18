using System.Text.RegularExpressions;
using FluentValidation;
using FluentValidation.Results;
using ValueOf;

namespace VivaTestLambdaApi.Domain.Common;

public class Description : ValueOf<string, Description>
{
    private static readonly Regex UsernameRegex =
        new("^[A-Z]+[a-zA-Z\"\"'\\s-]*$", RegexOptions.Compiled | RegexOptions.IgnoreCase);

    protected override void Validate()
    {
        if (!UsernameRegex.IsMatch(Value))
        {
            var message = $"{Value} is not a valid description";
            throw new ValidationException(message, new []
            {
                new ValidationFailure(nameof(Description), message)
            });
        }
    }
}
