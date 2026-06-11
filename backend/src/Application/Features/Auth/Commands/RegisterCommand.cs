using MediatR;
using AuthTest.Src.Application.Features.Auth.DTOs;

namespace AuthTest.Src.Application.Features.Auth.Commands
{
    public record RegisterCommand(
        string FirstName,
        string LastName,
        string login,
        string Email,
        string Password
    ) : IRequest<LoginResponse> {}

}