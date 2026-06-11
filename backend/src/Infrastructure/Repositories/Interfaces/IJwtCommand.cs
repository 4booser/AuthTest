using AuthTest.Src.Domain.Entities;

namespace AuthTest.Src.Infrastructure.Repositories.Interfaces
{
    public interface IJwtCommand
    {
        public Task<bool> AddAsync(Token token);
        public Task<bool> UpdateAsync(Token token);
        public Task<bool> DeleteAsync(Guid id);
    }
}