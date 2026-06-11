namespace AuthTest.Src.Application.Common.Exceptions;

public sealed class UnauthorizedException : AppException
{
    public UnauthorizedException(string message = "Unauthorized")
        : base(message, StatusCodes.Status401Unauthorized)
    {
    }
}