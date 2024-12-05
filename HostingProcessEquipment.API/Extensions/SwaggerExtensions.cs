namespace HostingProcessEquipment.API.Extensions;
public static class SwaggerExtensions
{
    public static IServiceCollection AddSwaggerWithSecurityKey(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.AddSecurityDefinition("SecurityKey", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                In = Microsoft.OpenApi.Models.ParameterLocation.Header,
                Name = "Security-Key",
                Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
                Description = "API Security Key needed to access endpoints"
            });

            c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
            {
                {
                    new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                    {
                            Reference = new Microsoft.OpenApi.Models.OpenApiReference
                            {
                                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                                    Id = "SecurityKey"
                            }
                    },
                    Array.Empty<string>()
                }
            });
        });

        return services;
    }
}