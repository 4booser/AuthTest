using System.Text.Json;
using AuthTest.Src.Application.Common.Exceptions;

namespace AuthTest.Src.Api.Middlewares;

public sealed class GlobalExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<GlobalExceptionMiddleware> _logger;
    private readonly IWebHostEnvironment _environment;

    public GlobalExceptionMiddleware(
        RequestDelegate next,
        ILogger<GlobalExceptionMiddleware> logger,
        IWebHostEnvironment environment)
    {
        _next = next;
        _logger = logger;
        _environment = environment;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception exception)
        {
            await HandleExceptionAsync(context, exception);
        }
    }

    private async Task HandleExceptionAsync(
        HttpContext context,
        Exception exception)
    {
        var statusCode = exception switch
        {
            AppException appException => appException.StatusCode,
            _ => StatusCodes.Status500InternalServerError
        };

        var message = exception switch
        {
            AppException appException => appException.Message,
            _ => "Internal server error"
        };

        _logger.LogError(
            exception,
            "Exception occurred. Method: {Method}, Path: {Path}, StatusCode: {StatusCode}",
            context.Request.Method,
            context.Request.Path,
            statusCode);

        context.Response.StatusCode = statusCode;
        context.Response.ContentType = "application/json";

        object response = exception switch
        {
            ValidationException validationException => new
            {
                statusCode,
                message,
                path = context.Request.Path.Value,
                method = context.Request.Method,
                traceId = context.TraceIdentifier,
                details = _environment.IsDevelopment()
                    ? exception.ToString()
                    : null
            },

            _ => new
            {
                statusCode,
                message,
                path = context.Request.Path.Value,
                method = context.Request.Method,
                traceId = context.TraceIdentifier,
                details = _environment.IsDevelopment()
                    ? exception.ToString()
                    : null
            }
        };

        var json = JsonSerializer.Serialize(response, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });

        await context.Response.WriteAsync(json);
    }
}