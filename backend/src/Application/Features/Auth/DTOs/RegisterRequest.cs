namespace AuthTest.Src.Application.Features.Auth.DTOs
{
    public record RegisterRequest(
        string firstName,
        string lastName,
        string login,
        string phone,
        string email,
        string password
    );
}