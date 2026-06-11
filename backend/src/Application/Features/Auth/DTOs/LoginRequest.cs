namespace AuthTest.Src.Application.Features.Auth.DTOs
{
    public record LoginRequest(
        string email,
        string password
    );
}