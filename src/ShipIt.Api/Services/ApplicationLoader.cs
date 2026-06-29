using Microsoft.Extensions.Options;
using ShipIt.Api.Models;

namespace ShipIt.Api.Services;

public sealed class ApplicationLoader(
    IOptions<ApplicationsOptions> options)
{
    private const SearchOption DirectorySearchOptions = SearchOption.AllDirectories;
    
    public IReadOnlyList<ApplicationDefinition> Load()
    {
        var applicationsPath = options.Value.Path;

        if (!Directory.Exists(applicationsPath))
            return [];

        return FindComposeFiles(applicationsPath)
            .Select(file =>
            {
                var directory = Path.GetDirectoryName(file)!;
                return new ApplicationDefinition
                {
                    Name = Path.GetFileName(directory),
                    DirectoryPath = directory,
                    ComposeFile = file
                };
            })
            .ToArray();
    }

    private IEnumerable<string> FindComposeFiles(string applicationsPath)
        => Directory
            .EnumerateFiles(applicationsPath, "compose.yml", DirectorySearchOptions)
            .Concat(
                Directory.EnumerateFiles(applicationsPath, "docker-compose.yml", DirectorySearchOptions));
}