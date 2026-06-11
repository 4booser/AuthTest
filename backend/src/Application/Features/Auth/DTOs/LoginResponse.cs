namespace AuthTest.Src.Application.Features.Auth.DTOs
{
    public record LoginResponse(
        string accessToken,
        string refreshToken,
        DateTime expiresAt
    );
}