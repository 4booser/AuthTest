using AuthTest.Src.Domain.Entities;
using AuthTest.Src.Infrastructure.Repositories.Interfaces;

namespace AuthTest.Src.Infrastructure.Repositories.Queries
{
    public class JwtQuery : IJwtQuery
    {
        public Token? GetById(Guid id)
        {
            // Implementation to retrieve a token by its ID from the database
            // This is a placeholder and should be replaced with actual database access code
            //return await Task.FromResult<Token?>(null);
            Token token = new Token
            {
                Id = id,
                UserId = Guid.NewGuid(),
                Hash = "sampleHash",
                ExpiresAt = DateTime.UtcNow.AddMinutes(60)
            };
            return token;
        }

        public Token? GetByHash(string hash)
        {
            // Implementation to retrieve a token by its hash from the database
            // This is a placeholder and should be replaced with actual database access code
            //return await Task.FromResult<Token?>(null);
            Token token = new Token
            {
                Id = Guid.NewGuid(),
                UserId = Guid.NewGuid(),
                Hash = hash,
                ExpiresAt = DateTime.UtcNow.AddMinutes(60)
            };
            return token;
        }
    }
}