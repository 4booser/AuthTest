using AuthTest.Src.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuthTest.Src.Infrastructure.Persistence.DbContexts
{
    public class TokensDbContext : DbContext
    {
        public TokensDbContext(DbContextOptions<TokensDbContext> options) : base(options)
        {
        }

        public DbSet<Token> Tokens { get; set; } = null!;
    }
}