namespace AuthTest.Src.Application.Features.Auth.DTOs
{
    public record RegisterRequest(
        string email,
        string password
    );
}