using AuthTest.Src.Infrastructure.Repositories.Interfaces;
using AuthTest.Src.Infrastructure.Repositories.Queries;
using AuthTest.Src.Application.Features.Auth.Services.Interfaces;
using AuthTest.Src.Application.Features.Auth.Services;

namespace AuthTest.Src.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddScoped<IHasher, Hasher>();

            services.AddScoped<IJwtService, JwtService>();
  

            return services;
        }
    }
}