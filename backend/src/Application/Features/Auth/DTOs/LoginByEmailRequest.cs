namespace AuthTest.Src.Application.Features.Auth.DTOs
{
    public record LoginByEmailRequest(
        string email,
        string password
    );
}