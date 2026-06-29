namespace ShipIt.Api.Models.Compose;

public sealed class ComposeApplication
{
    public required string Name { get; init; }
    public required IReadOnlyList<ComposeServiceInfo> Services { get; init; }
}