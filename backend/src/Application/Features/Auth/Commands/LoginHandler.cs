using MediatR;
using AuthTest.Src.Application.Features.Auth.DTOs;

namespace AuthTest.Src.Application.Features.Auth.Commands
{
    public class LoginHandler : IRequestHandler<LoginCommand, LoginResponse>
    {
        public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            if(string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Password))
                throw new ArgumentException("Email and password must be provided.");

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
