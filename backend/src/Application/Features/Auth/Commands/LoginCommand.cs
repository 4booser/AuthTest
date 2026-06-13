using MediatR;
using AuthTest.Src.Application.Features.Auth.DTOs;

namespace AuthTest.Src.Application.Features.Auth.Commands
{
    public record LoginCommand(
        string Login,
        string Password
    ) : IRequest<LoginResponse> {}
}