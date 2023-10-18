using System.Text.RegularExpressions;
using FluentValidation;
using FluentValidation.Results;
using ValueOf;

namespace VivaTestLambdaApi.Domain.Common;

public class Name : ValueOf<string, Name>
{
    private static readonly Regex FullNameRegex =
        new("^[A-Z]+[a-zA-Z\"\"'\\s-]*$", RegexOptions.Compiled | RegexOptions.IgnoreCase);

    protected override void Validate()
    {
        if (!FullNameRegex.IsMatch(Value))
        {
            var message = $"{Value} is not a valid name";
            throw new ValidationException(message, new []
            {
                new ValidationFailure(nameof(Name), message)
            });
        }
    }
}
