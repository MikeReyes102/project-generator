using System.Text.Json;

using ProjectGenerator.Application.Pipeline;
using ProjectGenerator.Application.Pipeline.Stages;
using ProjectGenerator.Core.Domain;
using ProjectGenerator.Core.Enums;
using ProjectGenerator.Core.Pipeline.Context;
using ProjectGenerator.Core.Pipeline.Interfaces;
using ProjectGenerator.Infrastructure.Templates;
using ProjectGenerator.Tests.TestData;

namespace ProjectGenerator.Tests.Pipeline;

public class PipelineTests
{

    // Valid Test 
    [Theory]
    [MemberData(nameof(GetValidRequests))]
    public async Task Pipeline_Should_Handle_All_Valid_Inputs(TestRequestData data)
    {
        // Arrange
        var request = new ProjectRequest
        {
            ProjectName = data.ProjectName,
            ProjectType = ProjectType.BasicFrontend,
            IncludeReadme = true,
            PageConfig = new PageConfiguration
            {
                PageType = Enum.Parse<PageType>(data.PageType),
                PageCount = data.PageCount
            }
        };

        var context = new GenerationContext(request);

        var runner = new PipelineRunner(new IPipelineStage[]
        {
        new ValidationStage(),
        new TemplateResolutionStage(new BasicTemplateProvider()),
        new LogicalGenerationStage()
        });

        // Act
        var result = await runner.RunAsync(context);

        // Assert
        Assert.True(result.IsSuccess);

        Assert.NotNull(context.GeneratedProject);

        Assert.Equal(
            data.ExpectedFileCount,
            context.GeneratedProject!.Files.Count
        );
    }

    public static IEnumerable<object[]> GetValidRequests()
    {
        var path = Path.Combine(
            AppContext.BaseDirectory,
            "TestData",
            "validRequests.json"
        );

        var json = File.ReadAllText(path);

        var data = JsonSerializer.Deserialize<List<TestRequestData>>(json)!;

        return data.Select(d => new object[] { d });
    }

    // Invalid Test

    [Theory]
    [MemberData(nameof(GetInvalidRequests))]
    public async Task Pipeline_Should_Reject_Invalid_Inputs(TestRequestData data)
    {
        var request = new ProjectRequest
        {
            ProjectName = data.ProjectName,
            ProjectType = ProjectType.BasicFrontend,
            IncludeReadme = true,
            PageConfig = new PageConfiguration
            {
                PageType = Enum.Parse<PageType>(data.PageType),
                PageCount = data.PageCount
            }
        };

        var context = new GenerationContext(request);

        var runner = new PipelineRunner(new IPipelineStage[]
        {
        new ValidationStage()
        });

        var result = await runner.RunAsync(context);

        Assert.False(result.IsSuccess);

        if (!string.IsNullOrEmpty(data.ExpectedErrorContains))
        {
            Assert.Contains(
                result.Errors,
                e => e.Contains(data.ExpectedErrorContains)
            );
        }
    }

    public static IEnumerable<object[]> GetInvalidRequests()
    {
        var path = Path.Combine(
            AppContext.BaseDirectory,
            "TestData",
            "invalidRequests.json"
        );

        var json = File.ReadAllText(path);

        var data = JsonSerializer.Deserialize<List<TestRequestData>>(json)!;

        return data.Select(d => new object[] { d });
    }
}