using AuthTest.Src.Domain.Entities;

namespace AuthTest.Src.Infrastructure.Repositories.Interfaces
{
    public interface IJwtQuery 
    {
        public Token? GetById(Guid id);
        public Token? GetByHash(string hash);
    }
}