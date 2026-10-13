using App.Core.Tracks;

namespace App.Api.Extensions;

public static class ServiceCollectionExtensions
{
    public const string FrontendCorsPolicy = "Frontend";

    /// <summary>
    /// Registers the business-logic services from App.Core.
    /// </summary>
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<TrackService>();

        return services;
    }

    /// <summary>
    /// Allows the frontend (origins listed under Cors:AllowedOrigins in appsettings) to call the API.
    /// </summary>
    public static IServiceCollection AddFrontendCors(this IServiceCollection services, IConfiguration configuration)
    {
        var allowedOrigins = configuration.GetSection("Cors:AllowedOrigins").Get<string[]>() ?? [];

        services.AddCors(options =>
        {
            options.AddPolicy(FrontendCorsPolicy, policy =>
                policy.WithOrigins(allowedOrigins)
                    .AllowAnyHeader()
                    .AllowAnyMethod());
        });

        return services;
    }
}
