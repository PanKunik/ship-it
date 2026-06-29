using System.ComponentModel.DataAnnotations;

namespace ShipIt.Api.Models;

public sealed class ApplicationsOptions
{
    public const string SectionName = "Applications";
    
    [Required]
    public string Path { get; init; } = "./applications";
}