using System.Security.Claims;

namespace AuthTest.Src.Application.Features.Auth.Services.Interfaces
{
    public interface IJwtService
    {
        public string CreateAccessToken(Claim[] claims);
        public string CreateRefreshToken();
    }
}