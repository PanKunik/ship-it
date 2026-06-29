namespace ShipIt.Api.Models;

public sealed class ApplicationDefinition
{
    public string Name { get; set; } = default!;
    public string DirectoryPath { get; set; } = default!;
    public string ComposeFile { get; set; } = default!;
}