using ShipIt.Api.Models;
using ShipIt.Api.Services;

namespace ShipIt.Api.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddShipIt(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddOptions<ApplicationsOptions>()
            .Bind(configuration.GetSection(ApplicationsOptions.SectionName))
            .ValidateDataAnnotations()
            .ValidateOnStart();
        
        services.AddSingleton<ApplicationLoader>();
        
        return services;
    }
}