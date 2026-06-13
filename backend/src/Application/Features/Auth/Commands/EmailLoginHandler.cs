using MediatR;
using AuthTest.Src.Application.Features.Auth.DTOs;
using AuthTest.Src.Application.Common.Exceptions;
using AuthApi.Src.Domain.Entities;
using AuthTest.Src.Application.Features.Auth.Services.Interfaces;
using System.Security.Claims;

namespace AuthTest.Src.Application.Features.Auth.Commands
{
    public class EmailLoginHandler : IRequestHandler<EmailLoginCommand, LoginResponse>
    {
        private readonly IHasher _hasher;
        private readonly IJwtService _jwtService;

        public EmailLoginHandler(IHasher hasher, IJwtService jwtService)
        {
            _hasher = hasher;
            _jwtService = jwtService;
        }

        public async Task<LoginResponse> Handle(EmailLoginCommand request, CancellationToken cancellationToken)
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

            if(request.Email.Length < 8 || request.Email.Length > 25)
                errors.Add("Email", new[] { "Email must be between 8 and 25 characters." });

            if(request.Password.Length < 8 || request.Password.Length > 20)
                errors.Add("Password", new[] { "Password must be between 8 and 20 characters." });

            if (errors.Any())
                throw new ValidationException(errors);


            string passwordHash = _hasher.Hash(request.Password);

            // Here you would typically validate the user's credentials against a database
            // For this example, we'll just return a dummy token if the email and password are not empty
            
            Claim[] claims = new Claim[]
            {
                new Claim(ClaimTypes.Email, request.Email)
            };
            
            return new LoginResponse(
                accessToken: _jwtService.CreateAccessToken(claims),
                refreshToken: _jwtService.CreateRefreshToken(),
                expiresAt: DateTime.UtcNow.AddMinutes(15)
            );
        }
    }
}
