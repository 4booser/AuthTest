namespace AuthTest.Src.Application.Features.Auth.DTOs
{
    public record EmailLoginRequest(
        string email,
        string password
    );
}