using MediatR;
using AuthTest.Src.Application.Features.Auth.DTOs;

namespace AuthTest.Src.Application.Features.Auth.Commands
{
    public record EmailLoginCommand(
        string Email,
        string Password
    ) : IRequest<LoginResponse> {}
}