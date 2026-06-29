namespace ShipIt.Api.Models.Compose;

public sealed class ComposeRoot
{
    public Dictionary<string, ComposeService> Services { get; init; } = [];
}