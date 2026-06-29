using ShipIt.Api.Models;
using ShipIt.Api.Services;

namespace ShipIt.Api.Tests.Services;

public class ComposeParserTests
{
    [Fact]
    public void Parse_ShouldParseSingleServiceCompose()
    {
        // Arrange
        var definition = CreateApplicationDefinition("simple.yml");

        // Act
        var application = ComposeParser.Parse(definition);
        
        // Assert
        Assert.Equal("crm", application.Name);
        Assert.Single(application.Services);
        Assert.Equal("api", application.Services[0].Name);
        Assert.Equal("nginx", application.Services[0].Image);
    }

    [Fact]
    public void Parse_WhenComposeContainsMultipleServices_ReturnsAllServices()
    {
        // Arrange
        var definition = CreateApplicationDefinition("multiple-services.yml");
        
        // Act
        var application = ComposeParser.Parse(definition);
        
        // Assert
        Assert.Equal("crm", application.Name);
        Assert.Equal(3, application.Services.Count);
        
        Assert.Equal("api", application.Services[0].Name);
        Assert.Equal("ghcr.io/pankunik/crm-api:latest", application.Services[0].Image);
        
        Assert.Equal("db", application.Services[1].Name);
        Assert.Equal("postgres:17", application.Services[1].Image);
        
        Assert.Equal("redis", application.Services[2].Name);
        Assert.Equal("redis:8", application.Services[2].Image);
    }

    [Fact]
    public void Parse_WhenComposeContainsNoServices_ReturnsEmptyApplication()
    {
        // Arrange
        var definition = CreateApplicationDefinition("empty.yml");
        
        // Act
        var application = ComposeParser.Parse(definition);
        
        // Assert
        Assert.Equal("crm", application.Name);
        Assert.Empty(application.Services);
    }

    [Fact]
    public void Parse_WhenServiceDoesNotDefineImage_IgnoresService()
    {
        // Arrange
        var definition = CreateApplicationDefinition("build-only.yml");
        
        // Act
        var application = ComposeParser.Parse(definition);
        
        // Assert
        Assert.Equal("crm", application.Name);
        Assert.Empty(application.Services);
    }

    [Fact]
    public void Parse_WhenComposeContainsUnknownProperties_IgnoresUnknownProperties()
    {
        // Arrange
        var definition = CreateApplicationDefinition("unknown-properties.yml");
        
        // Act
        var application = ComposeParser.Parse(definition);
        
        // Assert
        Assert.Equal("crm", application.Name);
        Assert.Single(application.Services);
        Assert.Equal("nginx", application.Services[0].Image);
    }

    private static ApplicationDefinition CreateApplicationDefinition(
        string fileName)
    {
        var path = Path.Combine(
            AppContext.BaseDirectory,
            "TestData",
            "Compose",
            fileName);

        return new ApplicationDefinition
        {
            Name = "crm",
            ComposeFile = path,
            DirectoryPath = Path.GetDirectoryName(path)!
        };
    }
}