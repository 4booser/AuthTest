using System.Security.Claims;
using AuthApi.Src.Domain.Entities;
using AuthTest.Src.Application.Common.Exceptions;
using AuthTest.Src.Application.Features.Auth.DTOs;
using AuthTest.Src.Application.Features.Auth.Services.Interfaces;
using MediatR;

namespace AuthTest.Src.Application.Features.Auth.Commands
{
    public class RegisterHandler : IRequestHandler<RegisterCommand, LoginResponse>
    {
        private readonly IHasher _hasher;
        private readonly IJwtService _jwtService;

        public RegisterHandler(IHasher hasher, IJwtService jwtService)
        {
            _hasher = hasher;
            _jwtService = jwtService;
        }
        public async Task<LoginResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
          Dictionary<string, string[]> errors = new Dictionary<string, string[]>();

            if (string.IsNullOrEmpty(request.Email))
                errors.Add("Email", new[] { "Email is required." });             
            
            if(string.IsNullOrEmpty(request.Password))
                errors.Add("Password", new[] { "Password is required." });

            if (errors.Any())
                throw new ValidationException(errors);

            string[] parts = request.Email.Split('@');

            if(parts.Length != 2)
                errors.Add("Email", new[] { "Email is not valid." });

            if(request.Email.Length < 8 || request.Email.Length > 20)
                errors.Add("Email", new[] { "Email must be between 8 and 20 characters." });

            if (errors.Any())
                throw new ValidationException(errors);
            
            User user = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                PasswordHash = _hasher.Hash(request.Password)
            };

            user.SetEmail(request.Email);
            user.SetPhone(request.Phone);
            user.SetLogin(request.Login);
            
            Claim[] claims = new Claim[]
            {
                new Claim(ClaimTypes.Name, user.FirstName)
            };

            return new LoginResponse(
                accessToken: _jwtService.CreateAccessToken(claims),
                refreshToken: _jwtService.CreateRefreshToken(),
                expiresAt: DateTime.UtcNow.AddMinutes(15)
            );
        }
    }
}