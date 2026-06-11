using MediatR;
using AuthTest.Src.Application.Features.Auth.DTOs;
using AuthTest.Src.Application.Common.Exceptions;
using AuthApi.Src.Domain.Entities;

namespace AuthTest.Src.Application.Features.Auth.Commands
{
    public class LoginHandler : IRequestHandler<LoginCommand, LoginResponse>
    {
        public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
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

            if (errors.Any())
                throw new ValidationException(errors);
            
            User user = new User
            {
                Email = request.Email,
                PasswordHash = "hashedpassword" // In a real application, you would hash the password
            };
            // Here you would typically validate the user's credentials against a database
            // For this example, we'll just return a dummy token if the email and password are not empty
            
            Console.WriteLine($"Attempting login for email: {request.Email}");
            
            return new LoginResponse(
                accessToken: "1234567890abcdef",
                refreshToken: "abcdef1234567890",
                expiresAt: DateTime.UtcNow.AddMinutes(15)
            );
        }
    }
}
