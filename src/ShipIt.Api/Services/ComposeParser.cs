using ShipIt.Api.Models;
using ShipIt.Api.Models.Compose;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace ShipIt.Api.Services;

public static class ComposeParser
{
    private static readonly IDeserializer Deserializer =
        new DeserializerBuilder()
            .IgnoreUnmatchedProperties()
            .WithNamingConvention(CamelCaseNamingConvention.Instance)
            .Build();
    
    public static ComposeApplication Parse(
        ApplicationDefinition applicationDefinition)
    {
        using var streamReader = File.OpenText(applicationDefinition.ComposeFile);
        var root = Deserializer.Deserialize<ComposeRoot>(streamReader);
        
        var services = root.Services?
            .Where(s => !string.IsNullOrWhiteSpace(s.Value.Image))
            .Select(s => new ComposeServiceInfo
            {
                Image = s.Value.Image!,
                Name = s.Key
            })?
            .ToList() ?? [];

        return new ComposeApplication
        {
            Name = applicationDefinition.Name,
            Services = services
        };
    }
}