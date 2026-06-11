namespace AuthTest.Src.Application.Common.Exceptions;

public sealed class ValidationException : AppException
{
    public IReadOnlyDictionary<string, string[]> Errors { get; }

    public ValidationException(IReadOnlyDictionary<string, string[]> errors)
        : base("Validation failed", StatusCodes.Status400BadRequest)
    {
        Errors = errors;
    }
}