using AuthTest.Src.Api.Middlewares;

namespace AuthTest.Src.Api.Configurations;

public static class ExceptionMiddlewareConfiguration
{
    public static IApplicationBuilder UseGlobalExceptionMiddleware(
        this IApplicationBuilder app)
    {
        return app.UseMiddleware<GlobalExceptionMiddleware>();
    }
}