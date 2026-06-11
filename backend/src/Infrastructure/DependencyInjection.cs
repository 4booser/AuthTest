using Microsoft.EntityFrameworkCore;
using AuthTest.Src.Infrastructure.Persistence.DbContexts;
using AuthTest.Src.Infrastructure.Repositories.Commands;
using AuthTest.Src.Infrastructure.Repositories.Interfaces;
using AuthTest.Src.Infrastructure.Repositories.Queries;

namespace AuthTest.Src.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var tokens_db = configuration.GetConnectionString("TokensDb")
                ?? throw new InvalidOperationException("Connection string 'TokensDb' is missing.");

            services.AddDbContext<TokensDbContext>(options =>
                options.UseNpgsql(tokens_db));

            services.AddScoped<IJwtCommand, JwtCommand>();
            services.AddScoped<IJwtQuery, JwtQuery>();

            return services;
        }
    }
}