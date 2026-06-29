using Microsoft.AspNetCore.Mvc;
using ShipIt.Api.Services;

namespace ShipIt.Api.Features.Applications;

public static class GetApplications
{
    public static IEndpointRouteBuilder MapGetApplications(
        this IEndpointRouteBuilder app)
    {
        app.MapGet("/applications", (
                [FromServices] ApplicationLoader loader) =>
            {
                var applications = loader
                    .Load()
                    .Select(ComposeParser.Parse)
                    .ToList();
                
                return Results.Ok(applications);
            });
        
        return app;
    }
}