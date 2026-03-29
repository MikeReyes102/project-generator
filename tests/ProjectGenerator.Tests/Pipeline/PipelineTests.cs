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

// Contains integration tests for the project generation pipeline.
// These tests use parameterized data to verify both valid and invalid scenarios.
public class PipelineTests
{
    // Test: The pipeline should handle all valid input requests successfully.
    // Uses data from validRequests.json to test multiple valid scenarios.
    [Theory]
    [MemberData(nameof(GetValidRequests))]
    public async Task Pipeline_Should_Handle_All_Valid_Inputs(TestRequestData data)
    {
        // Arrange: Build a request from test data
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

        // The pipeline includes validation, template resolution, and logical generation
        var runner = new PipelineRunner(new IPipelineStage[]
        {
            new ValidationStage(),
            new TemplateResolutionStage(new BasicTemplateProvider()),
            new LogicalGenerationStage()
        });

        // Act: Run the pipeline
        var result = await runner.RunAsync(context);

        // Assert: The result should be a success, and the expected number of files should be generated
        Assert.True(result.IsSuccess);
        Assert.NotNull(context.GeneratedProject);
        Assert.Equal(
            data.ExpectedFileCount,
            context.GeneratedProject!.Files.Count
        );
    }

    // Loads valid test cases from validRequests.json
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

    // Test: The pipeline should reject invalid input requests.
    // Uses data from invalidRequests.json to test multiple invalid scenarios.
    [Theory]
    [MemberData(nameof(GetInvalidRequests))]
    public async Task Pipeline_Should_Reject_Invalid_Inputs(TestRequestData data)
    {
        // Arrange: Build a request from test data
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

        // The pipeline only includes the validation stage for this test
        var runner = new PipelineRunner(new IPipelineStage[]
        {
            new ValidationStage()
        });

        // Act: Run the pipeline
        var result = await runner.RunAsync(context);

        // Assert: The result should be a failure, and the error message should match expectations
        Assert.False(result.IsSuccess);
        if (!string.IsNullOrEmpty(data.ExpectedErrorContains))
        {
            Assert.Contains(
                result.Errors,
                e => e.Contains(data.ExpectedErrorContains)
            );
        }
    }

    // Loads invalid test cases from invalidRequests.json
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