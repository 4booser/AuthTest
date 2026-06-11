using AuthApi.Src.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuthTest.Src.Infrastructure.Persistence.DbContexts
{
    public class UsersDbContext : DbContext
    {
        public UsersDbContext(DbContextOptions<UsersDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; } = null!;
    }
}