using App.Core.Tracks;
using App.Infrastructure.Repositories;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace App.Infrastructure;

public static class DependencyInjection
{
    /// <summary>
    /// Registers database, repositories, and other external services.
    /// </summary>
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<ITrackRepository, InMemoryTrackRepository>();

        return services;
    }
}
