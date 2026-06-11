using AuthTest.Src.Application.Features.Auth.DTOs;
using MediatR;

namespace AuthTest.Src.Application.Features.Auth.Commands
{
    public class RegisterHandler : IRequestHandler<RegisterCommand, LoginResponse>
    {
        public async Task<LoginResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            if(string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Password))
                throw new ArgumentException("Email and password must be provided.");
            
            if(request.Email.Length > 25 || request.Email.Length < 5)
                throw new ArgumentException("Email must be between 5 and 25 characters.");

            string[] parts = request.Email.Split('@');
            
            if(parts.Length != 2)
                throw new ArgumentException("Invalid email format.");


            if(request.Password.Length < 8 || request.Password.Length > 20)
                throw new ArgumentException("Password must be between 8 and 20 characters.");

            if (request.Password.Any(char.IsWhiteSpace))
                throw new ArgumentException("Password cannot contain whitespace characters.");
            
            if(!request.Password.Any(char.IsSymbol))
                throw new ArgumentException("Password must contain at least one special character.");

            if(!request.Password.Any(char.IsDigit))
                throw new ArgumentException("Password must contain at least one digit.");
            
            // Here you would typically add code to save the user to a database

            return await Task.FromResult(new LoginResponse(
                "1234567890abcdef", 
                "abcdef1234567890", 
                DateTime.UtcNow.AddMinutes(15)));
        }
    }
}