using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using AuthTest.Src.Application.Features.Auth.Services.Interfaces;
using AuthTest.Src.Domain.Entities;

namespace AuthTest.Src.Application.Features.Auth.Services
{
    public class JwtService : IJwtService
    {
        private readonly IConfiguration _config;
        private readonly IHasher _tokenHasher;
        public JwtService(
            IConfiguration config,
            IHasher tokenHasher)
        {
            _config = config;
            _tokenHasher = tokenHasher;
        }

        public string CreateAccessToken(Claim[] claims)
        {
            var jwtKey = _config["TokenOptions:Key"]
                ?? throw new InvalidOperationException("TokenOptions:Key is missing.");

            var issuer = _config["TokenOptions:Issuer"]
                ?? throw new InvalidOperationException("TokenOptions:Issuer is missing.");

            var audience = _config["TokenOptions:Audience"]
                ?? throw new InvalidOperationException("TokenOptions:Audience is missing.");

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(15),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string CreateRefreshToken()
        {
            var randomBytes = RandomNumberGenerator.GetBytes(64);
            var refreshToken = Convert.ToBase64String(randomBytes);

            return refreshToken;
        }

        /*
       public async Task<bool> RevokeTokenAsync(string token)
        {
            if (string.IsNullOrWhiteSpace(token))
                return false;

            Token? refreshToken = await _tokensRepo.GetByHashAsync(token);

            if (refreshToken is null)
                return false;

            if (refreshToken.is_revoked)
                return true;

            if (refreshToken.expires_at < DateTime.UtcNow)
                return true;

            refreshToken.is_revoked = true;

            await _tokensRepo.UpdateAsync(refreshToken);

            return true;
        } */
    }
}
