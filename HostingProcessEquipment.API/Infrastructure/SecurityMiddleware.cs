namespace HostingProcessEquipment.API.Infrastructure;

public class SecurityMiddleware
{
    private readonly RequestDelegate _next;
    private readonly string _apiKey;

    public SecurityMiddleware(RequestDelegate next, IConfiguration configuration)
    {
        _next = next;
        _apiKey = configuration["SecurityKey"] ?? throw new InvalidOperationException("API key is not configured!");
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (!context.Request.Headers.TryGetValue("Security-Key", out var extractedApiKey) || extractedApiKey != _apiKey)
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            await context.Response.WriteAsJsonAsync(new { Message = "Unauthorized" });
            return;
        }

        await _next(context);
    }
}

