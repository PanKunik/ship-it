using ShipIt.Api.Extensions;
using ShipIt.Api.Features.Applications;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddShipIt(builder.Configuration);

var app = builder.Build();

app.MapGetApplications();

app.Run();